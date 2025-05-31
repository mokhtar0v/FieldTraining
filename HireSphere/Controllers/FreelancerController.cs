using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using HireSphere.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HireSphere.Controllers
{
    public class FreelancerController(IFreelancerService _freelancerService, ILogger<FreelancerController> logger, IWebHostEnvironment _environment) : Controller
    {
        // GET: FreelancerController
        public IActionResult Index(int id)
        {
            if (id == 0) return BadRequest();

            var freelancerDto = _freelancerService.GetFreelancerByID(id); // Should return FreelancerDTO

            if (freelancerDto == null)
            {
                return NotFound();
            }

            return View(freelancerDto);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var freelancer = _freelancerService.GetFreelancerByID(id.Value);
            var freelancerVM = new AccountViewModel
            {
                FullName = freelancer.Name,
                Email = freelancer.Email,
                PhoneNumber = freelancer.PhoneNum
            };
            return View(freelancerVM);
        }
        [HttpPost]
        public IActionResult Update([FromRoute] int? id, AccountViewModel viewModel)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updateFreelancerDTO = new UpdateFreelancerDTO
                {
                    Name = viewModel.FullName,
                    Email = viewModel.Email,
                    PhoneNum = viewModel.PhoneNumber
                };
                var result = _freelancerService.UpdateFreelancer(updateFreelancerDTO, id.Value);
                if (result > 0)
                {
                    logger.LogInformation($"Freelancer with ID {id} updated successfully.");
                    return RedirectToAction("Index", new { id });
                }
                else
                {
                    logger.LogError($"Failed to update freelancer with ID {id}.");
                    ModelState.AddModelError(string.Empty, "Failed to update freelancer.");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment()) ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message);
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {

                var isDeleted = _freelancerService.DeleteFreelancer(id);
                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't Be Deleted");
                    return RedirectToAction("Login","Account");
                }
            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    logger.LogError(ex.Message);

                }
            }
            return View("Error");

        }
    }
}
