using Microsoft.AspNetCore.Mvc;
using MiePieShop.Models;
using MiePieShop.ViewModels;

namespace MiePieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var pies = pieRepository.GetAllPies().OrderBy(p => p.Id);
            var homeViewModel = new HomeViewModel() { Title = "Welcome to MiePieShop", Pies = pies.ToList() };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = pieRepository.GetPieById(id);
            
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
