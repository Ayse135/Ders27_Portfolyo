using System.Diagnostics;
using Ders27_Portfolyo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public IActionResult Contact(string name)
        {
            string tiklanmaSayisi = "152";
            ViewBag.kullaniciAdi = name;
            ViewBag.kullaniciListesi = new List<string>();
            return View("Contact",tiklanmaSayisi);
        }
        public IActionResult KullaniciKayit()
        {
            if (true)
                return RedirectToAction("Profil","BaskaControllerAdi");
            else 
                return View("Kayit"); // bunun controller'ý otomatik olarak "home" okunur.
        }
        [HttpPost]
        public async Task<IActionResult> ContactSave()
        {
            var gRepactchaResponse = Request.Form["g-recaptcha-response"];
            if (await VerifyCaptcha(gRepactchaResponse) == false)
            {
                return Json(new { status = false, desc = "Captcha verification failed." });
            }
            return Ok();
        }
        private async Task<bool> VerifyCaptcha(string captchaToken)
        {
            var client = new HttpClient();
            var recaptchaSecretKey = "6LfN-I0rAAAAABiKxyhRzrwP0bLU7PyrCb2RSuLt";
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={recaptchaSecretKey}&response={captchaToken}");

            var captchaResult = JObject.Parse(response);
            bool success = captchaResult["success"].Value<bool>();
            float score = captchaResult["score"].Value<float>();

            return success && score > 0.5;
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
