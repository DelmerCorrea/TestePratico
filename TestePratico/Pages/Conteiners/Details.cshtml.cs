using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Pages.Conteiners
{
    public class DetailsModel : PageModel
    {
        private readonly TestePratico.Data.DatabaseContext _context;

        public DetailsModel(TestePratico.Data.DatabaseContext context)
        {
            _context = context;
        }

      public Conteiner Conteiner { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Conteiner == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiner.FirstOrDefaultAsync(m => m.Id == id);
            if (conteiner == null)
            {
                return NotFound();
            }
            else 
            {
                Conteiner = conteiner;
            }
            return Page();
        }
    }
}
