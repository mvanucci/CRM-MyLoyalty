using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLoyalty.Models;

namespace MyLoyalty.Services
{
    public class ProdutoService
    {
        private readonly MyLoyaltyContext _context;

        public ProdutoService(MyLoyaltyContext context)
        {
            _context = context; 
        }

        public List<Produto> FindAll()
        {
            return _context.Produto.OrderBy(x => x.nome).ToList();
        }

        public Cliente Insert(Cliente c)
        {
            _context.Add(c);
            _context.SaveChanges();
            return c;
        }


    }
}
