using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Pages.Movimentacaos
{
    public class CreateModel : PageModel
    {
        private readonly TestePratico.Data.DatabaseContext _context;

        public CreateModel(TestePratico.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ConteinerId"] = new SelectList(_context.Set<Conteiner>(), "Id", "Numero");
            return Page();
        }

        [BindProperty]
        public Movimentacao Movimentacao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Movimentacao.Inicio = DateTime.Now;

            if (!ModelState.IsValid || _context.Movimentacao == null || Movimentacao == null)
            {
                return Page();
            }

            _context.Movimentacao.Add(Movimentacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
