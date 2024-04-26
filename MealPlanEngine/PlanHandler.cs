namespace MealPlanEngine
{
    public class PlanHandler
    {
        private List<Category> dailyGoals;
        private List<Plate> mealPlans;
        private List<FoodItem> availableFoods;

        public PlanHandler()
        {
            dailyGoals = new List<Category>();
            mealPlans = new List<Plate>();
            availableFoods = new List<FoodItem>();
        }

        /// <summary>
        /// Create a new daily goal for a selected food category.
        /// </summary>
        /// <param name="goal"></param>
        public void CreateDailyGoal(Category category)
        {
            if (dailyGoals.All(x => x.groups[0] != category.groups[0]))
            {
                dailyGoals.Add(category);
            }
            else
            {
                foreach (Category goal in dailyGoals)
                {
                    if (goal.groups[0] == category.groups[0])
                    {
                        goal.servings = category.servings;
                        break;
                    }
                }
            }
        }
    }
}
