using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Net.Models;

namespace RazorPagesProducts.Data
{
    public class RazorPagesProductsContext : DbContext
    {
        public RazorPagesProductsContext (DbContextOptions<RazorPagesProductsContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto_Net.Models.Product> Products { get; set; } = default!;
    }
}
