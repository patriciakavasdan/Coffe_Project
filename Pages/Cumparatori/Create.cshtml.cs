﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coffe_Project.Data;
using Coffe_Project.Models;

namespace Coffe_Project.Pages.Cumparatori
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
            return Page();
        }

        [BindProperty]
        public Cumparator Cumparator { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cumparator.Add(Cumparator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
