using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;

namespace Coffe_Project.Pages.Coffes
{
    public class DeleteModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public DeleteModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coffe Coffe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coffe == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe.FirstOrDefaultAsync(m => m.ID == id);

            if (coffe == null)
            {
                return NotFound();
            }
            else 
            {
                Coffe = coffe;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coffe == null)
            {
                return NotFound();
            }
            var coffe = await _context.Coffe.FindAsync(id);

            if (coffe != null)
            {
                Coffe = coffe;
                _context.Coffe.Remove(Coffe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
