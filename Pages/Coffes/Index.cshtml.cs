using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;
using System.Net;

namespace Coffe_Project.Pages.Coffes
{
    public class IndexModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public IndexModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        public IList<Coffe> Coffe { get; set; }
        public CoffeData CoffeD { get; set; }
        public int CoffeID { get; set; }
        public int CategoryID { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CoffeD = new CoffeData();

            CoffeD.Coffe = await _context.Coffe
            .Include(b => b.Distribuitor)
            .Include(b => b.CoffeCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                CoffeID = id.Value;
                Coffe coffe = CoffeD.Coffe
                .Where(i => i.ID == id.Value).Single();
                CoffeD.Categories = coffe.CoffeCategories.Select(s => s.Category);
            }
        }
    }
}
