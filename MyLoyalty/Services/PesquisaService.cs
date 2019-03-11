using MyLoyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLoyalty.Services
{
    public class PesquisaService
    {
        private readonly MyLoyaltyContext _context;

        public PesquisaService(MyLoyaltyContext context)
        {
            _context = context;
        }

        public int CreatePesquisaNull(Cliente cliente)
        {
            var pesquisa = new Pesquisa();
            pesquisa.cliente = cliente;
            _context.Add(pesquisa);
            _context.SaveChanges();

            return pesquisa.id;
        }

        public List<Cliente> Find(int? id)
        {
            return _context.Cliente.Where(x => x.id == id).ToList();
        }

        public List<Cliente> FindALL()
        {
            return _context.Cliente.ToList();
        }
    }
}
