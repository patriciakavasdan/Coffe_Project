namespace Coffe_Project.Models
{
    public class CoffeData
    {
        public IEnumerable<Coffe> Coffe { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CoffeCategory> CoffeCategories { get; set; }
    }
}
