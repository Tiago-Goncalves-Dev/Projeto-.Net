using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;
using Projeto_Net.Models;

namespace Projeto_Net.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<GestorReclamacao.Reclamacao> Reclamacao { get; set; } = default!;
}
