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
    public class IndexModel : PageModel
    {
        private readonly TestePratico.Data.DatabaseContext _context;

        public IndexModel(TestePratico.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Conteiner> Conteiner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Conteiner != null)
            {
                Conteiner = await _context.Conteiner.ToListAsync();
            }
        }
    }
}
