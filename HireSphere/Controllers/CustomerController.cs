using BusinessLogic.DTOs;
using BusinessLogic.Services.Classes;
using BusinessLogic.Services.Interfaces;
using DataAccess.Contexts;
using HireSphere.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HireSphere.Controllers
{
    public class CustomerController(ICustomerService _customerService, ILogger<CustomerController> logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _customerService.GetCustomerByID(id.Value);
            return employee is null ? NotFound() : View(employee);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var customer = _customerService.GetCustomerByID(id.Value);
            var customerVM = new AccountViewModel
            {
                FullName = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNum
            };
            return View(customerVM);
        }
        [HttpPost]
        public IActionResult Update([FromRoute] int? id, AccountViewModel viewModel)
        {
            if (!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updateCustomerDTO = new UpdateCustomerDTO
                {
                    Name = viewModel.FullName,
                    Email = viewModel.Email,
                    PhoneNum = viewModel.PhoneNumber
                };
                var result = _customerService.UpdateCustomer(updateCustomerDTO, id.Value);
                if (result > 0)
                {
                    logger.LogInformation($"Customer with ID {id} updated successfully.");
                    return RedirectToAction("Index", new { id });
                }
                else
                {
                    logger.LogError($"Failed to update customer with ID {id}.");
                    ModelState.AddModelError(string.Empty, "Failed to update customer.");
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

                var isDeleted = _customerService.DeleteCustomer(id);
                if (isDeleted) return RedirectToAction("Login","Account");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't Be Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
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
