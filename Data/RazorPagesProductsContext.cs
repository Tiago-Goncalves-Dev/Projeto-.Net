using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Net.Models;
using GestorReclamacao;


namespace RazorPagesProducts.Data
{
    public class RazorPagesProductsContext : DbContext
    {
        public RazorPagesProductsContext(DbContextOptions<RazorPagesProductsContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Reclamacao> Reclamacoes { get; set; } = default!;

    }
    
}
