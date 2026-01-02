using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestorReclamacao;
using Projeto_Net.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projeto_Net.Pages_Reclamacoes
{
    public class IndexModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public IndexModel(Projeto_Net.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reclamacao> Reclamacao { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var email = User.Identity?.Name; // Este valor é gerado automáticamente pelo .Net com o info do login 

            Reclamacao = await _context.Reclamacao.Where(r => r.NomeConsumidor == email).ToListAsync(); //Aqui filtramos os contexts
            // para mostrar apenas os que têm o Email do usuário no user.identity. 
        }
    }
}
