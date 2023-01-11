using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;

namespace Coffe_Project.Pages.Cumparaturi
{
    public class IndexModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public IndexModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        public IList<Cumparare> Cumparare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cumparare != null)
            {
                Cumparare = await _context.Cumparare
                .Include(c => c.Cofee)
                .Include(c => c.Cumparator).ToListAsync();
            }
        }
    }
}
