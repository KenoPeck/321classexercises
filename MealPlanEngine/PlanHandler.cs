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
        private Dictionary<(string, DateTime), int> mealTypeCounts = new Dictionary<(string, DateTime), int>();

        /// <summary>
        /// List of daily goals for food categories.
        /// </summary>
        private Dictionary<FoodGroup, float> dailyGoals;

        /// <summary>
        /// List of meal plans.
        /// </summary>
        private List<Plate> mealPlans;

        /// <summary>
        /// List of available food items.
        /// </summary>
        private List<FoodItem> availableFoods;

        private PlateFactory plateFactory = new (DateTime.Now, "Plate Factory");

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanHandler"/> class.
        /// </summary>
        public PlanHandler()
        {
            this.dailyGoals = new Dictionary<FoodGroup, float> { { FoodGroup.Fruit, 0 }, { FoodGroup.Vegetable, 0 }, { FoodGroup.Protein, 0 }, { FoodGroup.Grain, 0 }, { FoodGroup.Dairy, 0 } };
            this.mealPlans = new List<Plate>();
            this.availableFoods = new List<FoodItem>();
        }

        /// <summary>
        /// Create a new plate.
        /// </summary>
        /// <param name="date">date the meal is planned for.</param>
        /// <param name="mealType">type of meal.</param>
        /// <returns>returns the created plate.</returns>
        public Plate CreatePlate(DateTime date, string mealType)
        {
            if (this.mealTypeCounts.ContainsKey((mealType, date)))
            {
                this.mealTypeCounts[(mealType, date)]++;
                Plate plate = this.plateFactory.CreatePlate(mealType, date, mealType + this.mealTypeCounts[(mealType, date)].ToString());
                this.mealPlans.Add(plate);
                return plate;
            }
            else
            {
                this.mealTypeCounts.Add((mealType, date), 1);
                Plate plate = this.plateFactory.CreatePlate(mealType, date, mealType);
                this.mealPlans.Add(plate);
                return plate;
            }
        }

        /// <summary>
        /// Add a food item to a plate.
        /// </summary>
        /// <param name="plate">plate the food is being added to.</param>
        /// <param name="foodItem">food item being added to plate.</param>
        public void AddFoodToPlate(Plate plate, FoodItem foodItem)
        {
            plate.AddFoodItem(foodItem);
        }

        /// <summary>
        /// Remove a food item from a plate.
        /// </summary>
        /// <param name="plate">plate food is being removed from.</param>
        /// <param name="foodItem">food item being removed from plate.</param>
        public void RemoveFoodFromPlate(Plate plate, FoodItem foodItem)
        {
            plate.RemoveFoodItem(foodItem);
        }

        /// <summary>
        /// Set daily goal for a selected food category.
        /// </summary>
        /// <param name="category">category the goal is for.</param>
        public void SetDailyGoal(Category category)
        {
            this.dailyGoals[category.Groups[0]] = category.Servings;
        }

        /// <summary>
        /// Get the daily goal for a selected food group.
        /// </summary>
        /// <param name="foodGroup">group.</param>
        /// <returns>goal servingsize.</returns>
        public float GetDailyGoal(FoodGroup foodGroup)
        {
            return this.dailyGoals[foodGroup];
        }

        /// <summary>
        /// Get the daily servings from all meals for a selected food group.
        /// </summary>
        /// <param name="foodGroup">food group to get servings for.</param>
        /// <param name="date">date to get servings for.</param>
        /// <returns>float of servings for food group from all plates on selected date.</returns>
        public float GetDailyServings(FoodGroup foodGroup, DateTime date)
        {
            float servings = 0;
            foreach (Plate plate in this.mealPlans)
            {
                if (plate.Date == date)
                {
                    foreach (FoodItem food in plate.Foods)
                    {
                        if (food.Category.Groups.Contains(foodGroup))
                        {
                            servings += food.Category.Servings;
                        }
                    }
                }
            }

            return servings;
        }

        /// <summary>
        /// Get the servings of a food item.
        /// </summary>
        /// <param name="mealName">name of the plate to retrieve servings for.</param>
        /// <param name="date">date of meal to retrieve servings for.</param>
        /// <param name="group">foodgroup of meal to retrieve servings for.</param>
        /// <returns>float representing servings of the inputted foodgroup for the selected plate on the selected date.</returns>
        public float GetPlateServings(string mealName, DateTime date, int group)
        {
            foreach (Plate plate in this.mealPlans)
            {
                if (plate.MealName == mealName && plate.Date == date)
                {
                    foreach (Category category in plate.FoodCategories)
                    {
                        if (category.Groups[0] == (FoodGroup)group)
                        {
                            return category.Servings;
                        }
                    }
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
        /// Get the list of available foods.
        /// </summary>
        /// <returns>List of available foods in mealplan.</returns>
        public List<(string, Category)> GetAvailableFoods()
        {
            List<(string, Category)> availableFoods = new List<(string, Category)>();
            foreach (FoodItem food in this.availableFoods)
            {
                availableFoods.Add((food.Name, food.Category));
            }

            return availableFoods;
        }

        /// <summary>
        /// Get the list of meal types.
        /// </summary>
        /// <returns>List of the available meal types.</returns>
        public List<string> GetMealTypes()
        {
            return this.plateFactory.GetMealTypes();
        }

        /// <summary>
        /// Get the list of meal plans.
        /// </summary>
        /// <returns>List of plates.</returns>
        public List<Plate> GetMealPlans()
        {
            return this.mealPlans;
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
