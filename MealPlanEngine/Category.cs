using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanEngine
{
    public class Category
    {
        public List<FoodGroup> groups;
        public float servings;

        public Category(List<FoodGroup> groups, float servings)
        {
            this.groups = groups;
            this.servings = servings;
        }
    }

    public enum FoodGroup
    {
        Fruit,
        Vegetable,
        Protein,
        Grain,
        Dairy
    }
}
