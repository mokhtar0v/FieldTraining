using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireSphere.Controllers
{
    //[Authorize]
    public class CustomerController(ICustomerService _customerService,
                                    ILogger<CustomerController> _logger,
                                    IWebHostEnvironment _environment) : Controller
    {
        // GET: CustomerController
        #region Index
        public ActionResult Index(int? id)
        {
            if (!id.HasValue) return BadRequest("Invalid customer ID.");
            var customer = _customerService.GetCustomerByID(id.Value);
            if (customer == null)
            {
                _logger.LogWarning($"Customer with ID {id} not found.");
                return NotFound("Customer not found.");
            }
            return View(customer);
        }
        #endregion

        // GET: CustomerController/Create
        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _customerService.AddCustomer(customerDTO);

                    var message = string.Empty;
                    if (res > 0)
                        message = "Customer Created Successfully";
                    else
                        message = "Customer Can't Be Created";

                    // Optionally show message
                    // TempData["ResultMessage"] = message;

                    return RedirectToAction(nameof(Index), new { id = res });
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        ModelState.AddModelError(string.Empty, "An error occurred while creating the customer.");
                    }
                }
            }
            return View(customerDTO);
        } 
        #endregion

        // GET: CustomerController/Edit/5
        [HttpGet]
        #region Edit
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var customer = _customerService.GetCustomerByID(id.Value);
            if (customer is null) return NotFound();

            // Map to UpdateCustomerDto (or a viewmodel if you had one)
            var updateCustomerDto = new UpdateCustomerDTO()
            {
                Id = customer.ID,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNum = customer.PhoneNum
                // Add more properties if needed
            };

            return View(updateCustomerDto);
        }

        // POST: CustomerController/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(UpdateCustomerDTO dto)
        {
            if (dto.Id == 0) return BadRequest();

            if (!ModelState.IsValid) return View(dto);

            try
            {
                var result = _customerService.UpdateCustomer(dto, dto.Id);
                if (result > 0)
                    return RedirectToAction(nameof(Index), new { id = dto.Id });

                ModelState.AddModelError(string.Empty, "Customer can't be updated.");
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                {
                    _logger.LogError(ex.Message);
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the customer.");
                }
            }

            return View(dto);
        }
        #endregion


        // GET: CustomerController/Delete/5
        #region Delete
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                var isDeleted = _customerService.DeleteCustomer(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Department can't be deleted.");
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    _logger.LogError(ex.Message);
            }

            // Optionally you could show a "Delete failed" view or details again.
            return RedirectToAction(nameof(Delete), new { id });
        } 
        #endregion

    }
}
