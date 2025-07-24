using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        //private ProductSum productSum;
        public HomeController(IRepository repo)//,ProductSum psum)
        {
            repository = repo;
            //productSum = psum;
        }
        public IActionResult Index([FromServices] ProductSum productSum)
        {
            //ViewBag.Total = productSum.Total;
            ViewBag.HomeControllerGuid = repository.ToString();
            ViewBag.TotalGuid = productSum.Repository.ToString();

            return View(repository.Products);
        }
    }
}
