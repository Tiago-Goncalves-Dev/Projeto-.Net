using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;
using Projeto_Net.Data;

namespace Projeto_Net.Pages_Reclamacoes
{
    public class DetailsModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public DetailsModel(Projeto_Net.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Reclamacao Reclamacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao.FirstOrDefaultAsync(m => m.ReclamacaoID == id);

            if (reclamacao is not null)
            {
                Reclamacao = reclamacao;

                return Page();
            }

            return NotFound();
        }
    }
}
