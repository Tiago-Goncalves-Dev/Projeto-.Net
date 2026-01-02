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

namespace Projeto_Net.Pages_Reclamacoes_Admin
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

            var reclamacao =  await _context.Reclamacao.FirstOrDefaultAsync(m => m.ReclamacaoID == id);
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reclamacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReclamacaoExists(Reclamacao.ReclamacaoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReclamacaoExists(int id)
        {
            return _context.Reclamacao.Any(e => e.ReclamacaoID == id);
        }
    }
}
