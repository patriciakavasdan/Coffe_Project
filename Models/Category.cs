namespace Coffe_Project.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<CoffeCategory>? CoffeCategories { get; set; }
    }
}
