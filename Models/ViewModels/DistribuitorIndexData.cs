using Coffe_Project.Models;
using System.Security.Policy;

namespace Coffe_Project.Models.ViewModels
{
    public class DistribuitorIndexData
    {
        public IEnumerable<Distribuitor> Distribuitori { get; set; }
        public IEnumerable<Coffe> Coffes { get; set; }

    }
}
