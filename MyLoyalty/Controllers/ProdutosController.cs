using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLoyalty.Models;
using MyLoyalty.Models.ViewModels;

namespace MyLoyalty.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly MyLoyaltyContext _context;
      

        public ProdutosController(MyLoyaltyContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (ModelState.IsValid)
            {
                _context.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("login");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.id == id);
        }
    }
}
