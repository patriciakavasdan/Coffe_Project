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
    public class EditModel : CoffeCategoriesPageModel
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
            if (id == null)
            {
                return NotFound();
            }
            Coffe = await _context.Coffe
            .Include(b => b.Distribuitor)
            .Include(b => b.CoffeCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Coffe == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Coffe);
            
            ViewData["DistribuitorName"] = new SelectList(_context.Set<Publisher>(), "ID","DistribuitorName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var coffeToUpdate = await _context.Coffe
            .Include(i => i.Distribuitor)
            .Include(i => i.CoffeCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (coffeToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Coffe>(coffeToUpdate, "Coffe",i => i.Denumire, i => i.Origine,i => i.Pret, i => i.DataFabricatiei, i => i.DistribuitorID))
            {
                UpdateCoffeCategories(_context, selectedCategories, coffeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCoffeCategories(_context, selectedCategories, coffeToUpdate);
            PopulateAssignedCategoryData(_context, coffeToUpdate);
            return Page();
        }

    }
}
