using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestorReclamacao;
using Projeto_Net.Data;

// Apenas mostrar o que o usuario pode ver dado que este é o folder do user. 

namespace Projeto_Net.Pages_Reclamacoes
{
    public class CreateModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public CreateModel(Projeto_Net.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Reclamacao = new Reclamacao {
                NomeConsumidor = User.Identity?.Name ?? "Anon"
            };
            return Page();
        }

        [BindProperty]
        public Reclamacao Reclamacao { get; set; } = new Reclamacao();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Preenche a data e nome automaticamente
            Reclamacao.NomeConsumidor = User.Identity?.Name ?? "Anon";
            Reclamacao.DataEntrada = DateTime.Now; // Aplica a hora atual automaticamente

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reclamacao.Add(Reclamacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
