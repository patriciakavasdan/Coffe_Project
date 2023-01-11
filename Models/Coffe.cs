using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Coffe_Project.Models
{
    public class Coffe
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Cafea")]
        public string Denumire { get; set; }
        public string Origine { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFabricatiei { get; set; }
        public int? DistribuitorID { get; set; }
        public Distribuitor? Distribuitor { get; set; }
    }
}
