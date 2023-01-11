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
using Microsoft.EntityFrameworkCore;

namespace Coffe_Project.Pages.Coffes
{
    public class CreateModel : CoffeCategoriesPageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public CreateModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Publisher>(), "ID","DistribuitorName");
            var coffe = new Coffe();
            coffe.CoffeCategories = new List<CoffeCategory>();
            PopulateAssignedCategoryData(_context, coffe);
            return Page();
        }

        [BindProperty]
        public Coffe Coffe { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCoffe = new Coffe();
            if (selectedCategories != null)
            {
                newCoffe.CoffeCategories = new List<CoffeCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CoffeCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCoffe.CoffeCategories.Add(catToAdd);
                }
            }
            Coffe.CoffeCategories = newCoffe.CoffeCategories;
            _context.Coffe.Add(Coffe);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newCoffe);
            return Page();
        }
    }
}
