using BusinessLogic.DTOs;
using BusinessLogic.Services.Classes;
using HireSphere.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HireSphere.Controllers
{
    public class JobController(IJobService _jobService, ILogger<JobController> _logger,
                                     IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<JobDTO> jobs = _jobService.GetAllJobs();
            return View(jobs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(JobViewModel jobVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var createJobDTO = new CreateJobDTO()
                    {
                        Title = jobVM.Title,
                        Description = jobVM.Description,
                        CustomerId = jobVM.CustomerId,
                        Status = jobVM.Status
                    };
                    int res = _jobService.AddJob(createJobDTO);
                    if (res > 0) return RedirectToAction(nameof(Index));//Back To List
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Created");
                    }
                }
                catch (Exception ex)
                {

                    //Log Exception
                    //2) Deployment    => File / Table In Data Base

                    if (_environment.IsDevelopment())
                    {
                        //1) Developement  => Console
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(jobVM);
        }

    }
}
