using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;
using Projeto_Net.Data;

namespace Projeto_Net.Pages_Reclamacoes_Admin
{
    public class DeleteModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public DeleteModel(Projeto_Net.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacao.FindAsync(id);
            if (reclamacao != null)
            {
                Reclamacao = reclamacao;
                _context.Reclamacao.Remove(Reclamacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
