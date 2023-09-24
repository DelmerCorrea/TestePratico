using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Pages.Movimentacaos
{
    public class EditModel : PageModel
    {
        private readonly TestePratico.Data.DatabaseContext _context;

        public EditModel(TestePratico.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movimentacao Movimentacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimentacao == null)
            {
                return NotFound();
            }

            var movimentacao =  await _context.Movimentacao.FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            Movimentacao = movimentacao;
            ViewData["ConteinerId"] = new SelectList(_context.Set<Conteiner>(), "Id", "Numero");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Movimentacao movimentacaoBanco = await _context.Movimentacao.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Movimentacao.Id);

            if (movimentacaoBanco == null)
            {
                ModelState.AddModelError("Movimentacao.Id", "Nao foi possível realizar a operação!");
                return Page(); 
            }

            Movimentacao.Inicio = movimentacaoBanco.Inicio;
            Movimentacao.Fim = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movimentacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentacaoExists(Movimentacao.Id))
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

        private bool MovimentacaoExists(int id)
        {
          return (_context.Movimentacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
