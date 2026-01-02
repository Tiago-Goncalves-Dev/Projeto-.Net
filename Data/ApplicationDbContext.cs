using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;

namespace Projeto_Net.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{

public DbSet<GestorReclamacao.Reclamacao> Reclamacao { get; set; } = default!;
}
