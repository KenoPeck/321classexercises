// <copyright file="PlanHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Class to handle meal plans.
    /// </summary>
    public class PlanHandler
    {
        /// <summary>
        /// List of daily goals for food categories.
        /// </summary>
        private List<Category> dailyGoals;

        /// <summary>
        /// List of meal plans.
        /// </summary>
        private List<Plate> mealPlans;

        /// <summary>
        /// List of available food items.
        /// </summary>
        private List<FoodItem> availableFoods;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanHandler"/> class.
        /// </summary>
        public PlanHandler()
        {
            this.dailyGoals = new List<Category>();
            this.mealPlans = new List<Plate>();
            this.availableFoods = new List<FoodItem>();
        }

        /// <summary>
        /// Set daily goal for a selected food category.
        /// </summary>
        /// <param name="category">category the goal is for.</param>
        public void SetDailyGoal(Category category)
        {
            if (this.dailyGoals.All(x => x.Groups[0] != category.Groups[0]))
            {
                this.dailyGoals.Add(category);
            }
            else
            {
                foreach (Category goal in this.dailyGoals)
                {
                    if (goal.Groups[0] == category.Groups[0])
                    {
                        goal.Groups = category.Groups;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get the daily goal for a selected food group.
        /// </summary>
        /// <param name="foodGroup">group.</param>
        /// <returns>goal servingsize.</returns>
        public float GetDailyGoal(FoodGroup foodGroup)
        {
            foreach (Category goal in this.dailyGoals)
            {
                if (goal.Groups[0] == foodGroup)
                {
                    return goal.Servings;
                }
            }

            return 0;
        }

        /// <summary>
        /// Add a new FoodItem to the list of available foods.
        /// </summary>
        /// <param name="name">name of the food item being created.</param>
        /// <param name="category">category of the food item being created.</param>
        /// <exception cref="System.ArgumentException">Thrown when the food item already exists.</exception>
        public void CreateFoodItem(string name, Category category)
        {
            if (this.availableFoods.All(x => x.Name != name))
            {
                this.availableFoods.Add(new FoodItem(name, category));
            }
            else
            {
                throw new System.ArgumentException("Food item already exists.");
            }
        }

        /// <summary>
        /// Remove a FoodItem from the list of available foods.
        /// </summary>
        /// <param name="name">Name of the food item being deleted.</param>
        public void DeleteFoodItem(string name)
        {
            this.availableFoods.RemoveAll(x => x.Name == name);
        }

        /// <summary>
        /// Change the servings of a food item.
        /// </summary>
        /// <param name="name">name of the food item to be edited.</param>
        /// <param name="newServings">new servings of the food item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the food item does not exist.</exception>
        public void ChangeFoodItemServings(string name, float newServings)
        {
            foreach (FoodItem food in this.availableFoods)
            {
                if (food.Name == name)
                {
                    food.ChangeServings(newServings);
                    break;
                }
            }
        }

        /// <summary>
        /// Change the food groups of a food item.
        /// </summary>
        /// <param name="name">name of the food item to change.</param>
        /// <param name="groups">list of new food groups.</param>
        public void ChangeFoodItemGroups(string name, List<FoodGroup> groups)
        {
            foreach (FoodItem food in this.availableFoods)
            {
                if (food.Name == name)
                {
                    food.ChangeFoodGroups(groups);
                    break;
                }
            }
        }
    }
}
