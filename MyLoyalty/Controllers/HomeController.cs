using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLoyalty.Models;
using MyLoyalty.Models.ViewModels;
using CryptSharp;

namespace MyLoyalty.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyLoyaltyContext _context;

        public HomeController(MyLoyaltyContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario u)
        {
            if (ModelState.IsValid)
            {
                var usrCad = _context.Usuario.Where(usuario => usuario.Login.Equals(u.Login)).FirstOrDefault();
                if (usrCad != null)
                {
                    if (EncryptHash.CheckPass(u.Password, usrCad.Password))
                    {
                        HttpContext.Session.SetString("id", usrCad.Id.ToString());
                        HttpContext.Session.SetString("name", usrCad.Nome.ToString());
                        HttpContext.Session.SetString("login", usrCad.Login.ToString());
                        HttpContext.Session.SetString("is_adm", usrCad.adm.ToString());
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("id", "");
            HttpContext.Session.SetString("name", "");
            HttpContext.Session.SetString("login", "");
            HttpContext.Session.SetString("is_adm", "");
            return RedirectToAction("Login");
        }
    }
}
