using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Data;
using Coffe_Project.Models;
using System.Security.Policy;
using Coffe_Project.Models.ViewModels;


namespace Coffe_Project.Pages.Distribuitori
{
    public class IndexModel : PageModel
    {
        private readonly Coffe_Project.Data.Coffe_ProjectContext _context;

        public IndexModel(Coffe_Project.Data.Coffe_ProjectContext context)
        {
            _context = context;
        }

        public IList<Distribuitor> Distribuitor { get;set; } = default!;

        public DistribuitorIndexData DistribuitorData { get; set; }
        public int DistribuitorID { get; set; }
        public int CoffeID { get; set; }
        public async Task OnGetAsync(int? id, int? coffeID)
        {
            DistribuitorData = new DistribuitorIndexData();
            DistribuitorData.Distribuitori = await _context.Distribuitor
            .Include(i => i.Coffes)
            .OrderBy(i => i.DistribuitorName)
            .ToListAsync();
            if (id != null)
            {
                DistribuitorID = id.Value;
                Distribuitor distribuitor = DistribuitorData.Distribuitori
                .Where(i => i.ID == id.Value).Single();
                DistribuitorData.Coffes = distribuitor.Coffes;
            }
        }
    }
}
