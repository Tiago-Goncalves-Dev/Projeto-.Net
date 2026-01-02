using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;
using Projeto_Net.Data;

namespace Projeto_Net.Pages_Reclamacoes
{
    public class EditModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public EditModel(Projeto_Net.Data.ApplicationDbContext context)
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
            if (reclamacao == null)
            {
                return NotFound();
            }
            Reclamacao = reclamacao;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate only the editable fields (Assunto and TextoReclamacao)
            if (string.IsNullOrWhiteSpace(Reclamacao?.Assunto))
            {
                ModelState.AddModelError("Reclamacao.Assunto", "O campo Assunto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(Reclamacao?.TextoReclamacao))
            {
                ModelState.AddModelError("Reclamacao.TextoReclamacao", "O campo Texto é obrigatório.");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entity = await _context.Reclamacao.FindAsync(Reclamacao.ReclamacaoID);
            if (entity == null)
            {
                return NotFound();
            }

            if (entity.Estado == "Fechada")
            {
                ModelState.AddModelError(string.Empty, "Não é possível editar uma reclamação fechada.");
                return Page(); // Literalmente valida a string do estado (não visivel mas existente) e se estiver Fechada dá pop up do aviso
                //Acrescentei também um botão de Back to List porque não existia no Edit 
            }

            // update only editable fields
            entity.Assunto = Reclamacao.Assunto;
            entity.TextoReclamacao = Reclamacao.TextoReclamacao;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool ReclamacaoExists(int id)
        {
            return _context.Reclamacao.Any(e => e.ReclamacaoID == id);
        }
    }
}
