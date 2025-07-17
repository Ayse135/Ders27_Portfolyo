using System.Diagnostics;
using Ders27_Portfolyo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders27_Portfolyo.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult KullaniciKayit()
        {
            if (true)
                return RedirectToAction("Profil","BaskaController");
            else 
                return View("Kayit"); // bunun controller'ý otomatik olarak "home" okunur.
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
