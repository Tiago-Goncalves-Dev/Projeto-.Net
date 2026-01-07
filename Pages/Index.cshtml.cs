using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProducts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Projeto_Net.Pages;

public class IndexModel : PageModel
{
    private readonly RazorPagesProductsContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;


    public IndexModel(RazorPagesProductsContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    public IList<Models.Product> Products { get; set; } = new List<Models.Product>();

     public string RedirectPage { get; set; } = "/Reclamacoes/Index";
    public async Task OnGetAsync()
    {
        Products = await _context.Products.ToListAsync();

        if (_signInManager.IsSignedIn(User))
        {
            RedirectPage = "/Reclamacoes/Create";
        }
    }
}
