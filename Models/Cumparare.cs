using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Coffe_Project.Models
{
    public class Cumparare
    {
        public int ID { get; set; }
        public int? CumparatorID { get; set; }
        public Cumparator? Cumparator { get; set; }
        public int? CoffeID { get; set; }
        public Coffe? Cofee { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
