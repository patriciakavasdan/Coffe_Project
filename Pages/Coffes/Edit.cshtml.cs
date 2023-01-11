using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;
using System.Security.Policy;

namespace Coffe_Project.Pages.Coffes
{
    public class EditModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public EditModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coffe Coffe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coffe == null)
            {
                return NotFound();
            }

            var coffe =  await _context.Coffe.FirstOrDefaultAsync(m => m.ID == id);
            if (coffe == null)
            {
                return NotFound();
            }
            Coffe = coffe;
            ViewData["DistribuitorName"] = new SelectList(_context.Set<Publisher>(), "ID","DistribuitorName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coffe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeExists(Coffe.ID))
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

        private bool CoffeExists(int id)
        {
          return _context.Coffe.Any(e => e.ID == id);
        }
    }
}
