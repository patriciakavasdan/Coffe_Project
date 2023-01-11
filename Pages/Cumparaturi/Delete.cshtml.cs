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
    public class DeleteModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public DeleteModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cumparare Cumparare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }

            var cumparare = await _context.Cumparare.FirstOrDefaultAsync(m => m.ID == id);

            if (cumparare == null)
            {
                return NotFound();
            }
            else 
            {
                Cumparare = cumparare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cumparare == null)
            {
                return NotFound();
            }
            var cumparare = await _context.Cumparare.FindAsync(id);

            if (cumparare != null)
            {
                Cumparare = cumparare;
                _context.Cumparare.Remove(Cumparare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
