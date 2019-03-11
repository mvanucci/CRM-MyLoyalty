using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLoyalty.Models;
using MyLoyalty.Services;
using MyLoyalty.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MyLoyalty.Controllers
{
    public class PesquisasController : Controller
    {
        private readonly MyLoyaltyContext _context;
        private readonly PesquisaService _pesquisa;

        public PesquisasController(MyLoyaltyContext context, PesquisaService pesquisa)
        {
            _context = context;
            _pesquisa = pesquisa;
        }

        // GET: Pesquisas
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View(await _context.Pesquisa.Include(obj => obj.cliente).ToListAsync());
        }

        // GET: Pesquisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");

            if (id == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.Pesquisa.Include(obj => obj.cliente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (pesquisa == null)
            {
                return NotFound();
            }

            return View(pesquisa);
        }
      
        // GET: Pesquisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.Pesquisa.FindAsync(id);

            if (pesquisa == null)
            {
                return NotFound();
            }

            if (pesquisa.resp == 1)
            {
                return View("ErrorPesquisa");
            }

            return View(pesquisa);
        }

        // POST: Pesquisas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pesquisa pesquisa)
        {
            if (pesquisa.id != pesquisa.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesquisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                    
                }
                return Redirect("https://www.google.com.br");
            }
            return View(pesquisa);
        }
       
       
    }
}
