using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Pages.Conteiners
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
            return Page();
        }

        [BindProperty]
        public Conteiner Conteiner { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Conteiner == null || Conteiner == null)
            {
                return Page();
            }

            _context.Conteiner.Add(Conteiner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
