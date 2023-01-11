using Microsoft.AspNetCore.Mvc.RazorPages;
using Coffe_Project.Data;

namespace Coffe_Project.Models
{
    public class CoffeCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Coffe_ProjectContext context, Coffe coffe)
        {
            var allCategories = context.Category;
            var coffeCategories = new HashSet<int>(
            coffe.CoffeCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = coffeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCoffeCategories(Coffe_ProjectContext context,
 string[] selectedCategories, Coffe coffeToUpdate)
        {
            if (selectedCategories == null)
            {
                coffeToUpdate.CoffeCategories = new List<CoffeCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var coffeCategories = new HashSet<int>
            (coffeToUpdate.CoffeCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!coffeCategories.Contains(cat.ID))
                    {
                        coffeToUpdate.CoffeCategories.Add(
                        new CoffeCategory
                        {
                            CoffeID = coffeToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (coffeCategories.Contains(cat.ID))
                    {
                        CoffeCategory courseToRemove
                        = coffeToUpdate
                        .CoffeCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
 }

