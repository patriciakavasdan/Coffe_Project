using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coffe_Project.Models;

namespace Coffe_Project.Data
{
    public class Coffe_ProjectContext : DbContext
    {
        public Coffe_ProjectContext (DbContextOptions<Coffe_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Coffe_Project.Models.Coffe> Coffe { get; set; } = default!;

        public DbSet<Coffe_Project.Models.Distribuitor> Distribuitor { get; set; }
    }
}
