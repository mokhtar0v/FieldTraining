using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HireSphere.Models;
using DataAccess.Models;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Services.Classes;

namespace HireSphere.Controllers;

public class HomeController(IJobService _jobService ,ILogger<HomeController> _logger) : Controller
{

    public IActionResult Index()
    {
        List<JobDTO> jobs = _jobService.GetAllJobs().ToList();
        return View(jobs);
    }
}
