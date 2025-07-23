using System.Diagnostics;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ProductSum productSum;
        public HomeController(IRepository repo,ProductSum psum)
        {
            repository = repo;
            productSum = psum;
        }
        public IActionResult Index()
        {
            ViewBag.Total = productSum.Total;
            return View(repository.Products);
        }
    }
}
