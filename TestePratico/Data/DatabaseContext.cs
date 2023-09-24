using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestePratico.Models;

namespace TestePratico.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TestePratico.Models.Movimentacao> Movimentacao { get; set; } = default!;

        public DbSet<TestePratico.Models.Conteiner>? Conteiner { get; set; }
    }
}
