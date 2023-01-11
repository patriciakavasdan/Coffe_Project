using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coffe_Project.Data;
using Coffe_Project.Models;
using System.Security.Policy;

namespace Coffe_Project.Pages.Coffes
{
    public class CreateModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public CreateModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Publisher>(), "ID","DistribuitorName");
            return Page();
        }

        [BindProperty]
        public Coffe Coffe { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coffe.Add(Coffe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
