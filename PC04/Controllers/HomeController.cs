using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC04.Data;
using PC04.Models;

namespace PC04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(Foto f)
        {
            var fotos = _context.Fotos.OrderByDescending(f => f.Fecha).ToList();
            return View(fotos);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Foto f)
        {
            if (ModelState.IsValid) {
                _context.Add(f);
                _context.SaveChanges();
                return RedirectToAction("RegistrarConfirmacion");
            }
            return View(f);
        }

        public IActionResult RegistrarConfirmacion(){
            return View();
        }
        public IActionResult Imagen(int Id){
            var imagen = _context.Fotos.Find(Id);
            return View(imagen);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
