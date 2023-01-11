namespace Coffe_Project.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        public string DistribuitorName { get; set; }
        public ICollection<Coffe>? Coffes { get; set; }
    }
}
