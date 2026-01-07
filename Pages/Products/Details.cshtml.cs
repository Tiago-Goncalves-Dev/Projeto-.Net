using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_Net.Models;
using RazorPagesProducts.Data;

namespace Projeto_Net.Pages_Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesProducts.Data.RazorPagesProductsContext _context;

        public DetailsModel(RazorPagesProducts.Data.RazorPagesProductsContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (products is not null)
            {
                Product = products;

                return Page();
            }

            return NotFound();
        }
    }
}
