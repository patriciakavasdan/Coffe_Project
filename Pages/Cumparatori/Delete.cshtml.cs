using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;

namespace Coffe_Project.Pages.Cumparatori
{
    public class DeleteModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public DeleteModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cumparator Cumparator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparator == null)
            {
                return NotFound();
            }

            var cumparator = await _context.Cumparator.FirstOrDefaultAsync(m => m.ID == id);

            if (cumparator == null)
            {
                return NotFound();
            }
            else 
            {
                Cumparator = cumparator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cumparator == null)
            {
                return NotFound();
            }
            var cumparator = await _context.Cumparator.FindAsync(id);

            if (cumparator != null)
            {
                Cumparator = cumparator;
                _context.Cumparator.Remove(Cumparator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
