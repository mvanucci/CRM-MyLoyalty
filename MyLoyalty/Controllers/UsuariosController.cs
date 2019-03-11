using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLoyalty.Models;
using CryptSharp;

namespace MyLoyalty.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly MyLoyaltyContext _context;

        public UsuariosController(MyLoyaltyContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Login,Password,adm")] Usuario usuario)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Password = EncryptHash.Encript(usuario.Password),
                    adm = usuario.adm
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Login,Password,adm")] Usuario usuario)
        {

            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Usuario user = new Usuario
                    {
                        Nome = usuario.Nome,
                        Login = usuario.Login,
                        Password = EncryptHash.Encript(usuario.Password),
                        adm = usuario.adm
                    };
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
