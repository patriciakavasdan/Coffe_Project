namespace Coffe_Project.Models
{
    public class CoffeCategory
    {
        public int ID { get; set; }
        public int CoffeID { get; set; }
        public Coffe Coffe{ get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
