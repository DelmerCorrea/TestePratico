using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Pages.Movimentacaos
{
    public class DetailsModel : PageModel
    {
        private readonly TestePratico.Data.DatabaseContext _context;

        public DetailsModel(TestePratico.Data.DatabaseContext context)
        {
            _context = context;
        }

      public Movimentacao Movimentacao { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimentacao == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao.FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            else 
            {
                Movimentacao = movimentacao;
            }
            return Page();
        }
    }
}
