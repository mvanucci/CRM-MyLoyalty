using Microsoft.EntityFrameworkCore;
using MyLoyalty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLoyalty.Services
{
    public class ClienteService
    {
        public readonly MyLoyaltyContext _context;

        public ClienteService(MyLoyaltyContext context)
        {
            _context = context;
        }

        public List<Cliente> GetByVendasRealizadasSim()
        {
            return _context.Cliente.Include(obj => obj.produto).Where(venda => venda.vendaRealizada == "Sim").ToList();
        }

        public List<Cliente> GetByVendasRealizadasNao()
        {
            return _context.Cliente.Include(obj => obj.produto).Where(venda => venda.vendaRealizada == "Não").ToList();
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }
    }
}
