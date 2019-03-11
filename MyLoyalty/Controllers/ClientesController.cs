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
    public class ClientesController : Controller
    {
        private readonly MyLoyaltyContext _context;
        private readonly ProdutoService _product;
        private readonly ClienteService _client;
        private readonly PesquisaService _pesquisa;

        public ClientesController(MyLoyaltyContext context, ProdutoService product, ClienteService client, PesquisaService pesquisa)
        {
            _context = context;
            _product = product;
            _client = client;
            _pesquisa = pesquisa;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            return View(await _context.Cliente.Include(obj => obj.produto).ToListAsync());
        }

        public IActionResult VendaSim()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            var venda = _client.GetByVendasRealizadasSim().ToList();
            return View(venda);
        }

        public IActionResult VendaNao()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            var venda = _client.GetByVendasRealizadasNao().ToList();
            return View(venda);
        }

        // GET: Clientes/Details/5
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

            var cliente = await _context.Cliente
                .Include(obj => obj.produto).FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            var produto = _product.FindAll();
            var option = new List<SelectListItem>
            {
                new SelectListItem {Text = "Sim", Value = "Sim"},
                new SelectListItem {Text = "Não", Value = "Não"}
            };
            var viewModel = new ProdutoFormViewModel
            {
                produtos = produto,
                options = option  
            };

            return View(viewModel);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (ModelState.IsValid)
            {
                var client= _product.Insert(cliente);
                var novaPesquisa = _pesquisa.CreatePesquisaNull(client);
                cliente.sendPesquisa(novaPesquisa);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
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
            var produto = _product.FindAll();
           

            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            var viewModel = new ProdutoFormViewModel {cliente = cliente, produtos = produto };
            return View(viewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {

            if (HttpContext.Session.GetString("login") == null || HttpContext.Session.GetString("login") == "")
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["usuario"] = HttpContext.Session.GetString("name");
            ViewData["isAdm"] = HttpContext.Session.GetString("is_adm");

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
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

            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.id == id);
        }
    }
}
