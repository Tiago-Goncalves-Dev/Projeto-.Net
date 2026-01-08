using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProducts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GestorReclamacao;
using RazorPagesProducts;


namespace Projeto_Net.Pages;

public class IndexModel : PageModel
{
    private readonly RazorPagesProductsContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;
    [BindProperty(SupportsGet = true)]
    public string? searchNome { get; set; }

    public IndexModel(RazorPagesProductsContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    public IList<Models.Product> Products { get; set; } = new List<Models.Product>();
    public IList<Reclamacao> Reclamacoes { get; set; } = new List<Reclamacao>();

    public string RedirectPage { get; set; } = "/Reclamacoes/Index";
    public async Task OnGetAsync()
    {
        var query = from r in _context.Products select r;

        if (_signInManager.IsSignedIn(User))
        {
            RedirectPage = "/Reclamacoes/Create";
        }

        if (!string.IsNullOrEmpty(searchNome))
        {
            query = query.Where(r =>
                EF.Functions.Like(r.NomeDoProduto, $"%{searchNome}%"));
        }

        Products = await query.ToListAsync();
        Reclamacoes = await _context.Reclamacoes.ToListAsync();
    }
}
