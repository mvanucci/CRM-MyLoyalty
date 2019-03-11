using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyLoyalty.Models
{
    public class MyLoyaltyContext : DbContext
    {
        public MyLoyaltyContext (DbContextOptions<MyLoyaltyContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pesquisa> Pesquisa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
