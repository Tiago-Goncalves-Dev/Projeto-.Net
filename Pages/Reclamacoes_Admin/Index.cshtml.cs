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

namespace Projeto_Net.Pages_Reclamacoes_Admin
{
    [Authorize(Roles="Admin")] //Determina que apenas Admins podem aceder a esta página. *** Usar a conta Admin para vizualizar *** 
    public class IndexModel : PageModel
    {
        private readonly Projeto_Net.Data.ApplicationDbContext _context;

        public IndexModel(Projeto_Net.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reclamacao> Reclamacao { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reclamacao = await _context.Reclamacao.ToListAsync();
        }
    }
}
