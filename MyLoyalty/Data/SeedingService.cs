using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLoyalty.Models;
namespace MyLoyalty.Data
{
    public class SeedingService
    {
        private MyLoyaltyContext _context;

        public SeedingService(MyLoyaltyContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Cliente.Any() || 
                _context.Pesquisa.Any() || 
                _context.Produto.Any())
            {
                return; // O banco de dados já foi populado
            }


            Produto p1 = new Produto(1, "Carrinho", "Brinquedo", 10, "marrom", 5, "Criança", 10);
            Produto p2 = new Produto(2, "Camiseta", "Roupa", 10, "azul", 5, "Vestimento", 3);
            Produto p3 = new Produto(3, "Blusa", "Manga comprida", 10, "Preto", 10, "Roupa", 12);
            Cliente c1 = new Cliente(1, "Murilo", "murilo@murilo.com.br", "12345678999", new DateTime(2012, 12, 10), "123456789", "Não", "Não", p1);
            Cliente c2 = new Cliente(2, "Renato", "murilo@murilo.com.br", "12345678999", new DateTime(2012, 12, 10), "123456789", "Sim", "Não", p2);

            Usuario u = new Usuario(1, "Administrador", "admin", EncryptHash.Encript("1234"), "Sim");

            _context.Cliente.AddRange(c1, c2);
            _context.Produto.AddRange(p1, p2, p3);
            _context.Usuario.AddRange(u);
            _context.SaveChanges();
        }
    }
}
