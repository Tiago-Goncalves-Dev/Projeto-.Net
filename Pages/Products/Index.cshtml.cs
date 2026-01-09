using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_Net.Models;
using RazorPagesProducts.Data;
using Microsoft.AspNetCore.Authorization;


namespace Projeto_Net.Pages_Products
{
    [Authorize(Roles = "Admin")] //Determina que apenas Admins podem aceder a esta página. *** Usar a conta Admin para vizualizar *** 

    public class IndexModel : PageModel
    {
        private readonly RazorPagesProducts.Data.RazorPagesProductsContext _context;

        public IndexModel(RazorPagesProducts.Data.RazorPagesProductsContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
