﻿// <copyright file="UserProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalExam
{
    using MealPlanEngine;

    /// <summary>
    /// User Profile class.
    /// </summary>
    internal class UserProfile
    {
        private string userID;
        private string password;

        /// <summary>
        /// Plan handler for managing the user's meal plan.
        /// </summary>
        private PlanHandler planHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        /// <param name="userID">user's userID.</param>
        /// <param name="password">user's password.</param>
        public UserProfile(string userID, string password)
        {
            this.planHandler = new PlanHandler();
            this.userID = userID;
            this.password = password;
        }

        /// <summary>
        /// Gets the user's ID.
        /// </summary>
        internal string UserID
        {
            get
            {
                return this.userID;
            }
        }

        /// <summary>
        /// Gets the user's password.
        /// </summary>
        internal string Password
        {
            get
            {
                return this.password;
            }
        }

        /// <summary>
        /// Creates a new food item to add to records of available foods.
        /// </summary>
        /// <param name="name">Name of new food item.</param>
        /// <param name="quantity">Quantity of new food item.</param>
        /// <param name="groups">List of food groups the new food item belongs to.</param>
        public void CreateFoodItem(string name, float quantity, List<int> groups)
        {
            List<FoodGroup> foodGroups = new List<FoodGroup>();
            foreach (int group in groups)
            {
                foodGroups.Add((FoodGroup)group);
            }

            Category category = new Category(foodGroups, quantity);
            this.planHandler.CreateFoodItem(name, category);
        }

        /// <summary>
        /// Removes a food item from the available foods and all plates.
        /// </summary>
        /// <param name="name">name of food to be removed.</param>
        public void DeleteFoodItem(string name)
        {
            this.planHandler.DeleteFoodItem(name);
        }

        /// <summary>
        /// Gets the list of available food items.
        /// </summary>
        /// <returns>List of available food items in mealplan.</returns>
        public List<(string, float)> GetFoodItems()
        {
            List<(string, float)> foodItems = new List<(string, float)>();
            foreach ((var name, Category category) in this.planHandler.GetAvailableFoods())
            {
                foodItems.Add((name, category.Servings));
            }

            return foodItems;
        }

        /// <summary>
        /// Gets the list of meal types.
        /// </summary>
        /// <returns>List of available meal types.</returns>
        public List<string> GetMealTypes()
        {
            return this.planHandler.GetMealTypes();
        }

        /// <summary>
        /// Gets the list of meals for the selected date.
        /// </summary>
        /// <param name="date">Date of meals to get.</param>
        /// <returns>List of tuples conntaining a list of strings/floats representing the food items and a string representing the meal type.</returns>
        public List<(List<(string, float)>, string)> GetMeals(DateTime date)
        {
            List<(List<(string, float)>, string)> meals = new List<(List<(string, float)>, string)>();
            foreach (Plate plate in this.planHandler.GetMealPlans())
            {
                if (plate.Date != date)
                {
                    continue;
                }

                List<(string, float)> foods = new List<(string, float)>();
                foreach (FoodItem foodItem in plate.Foods)
                {
                    foods.Add((foodItem.Name, foodItem.Category.Servings));
                }

                meals.Add((foods, plate.MealName));
            }

            return meals;
        }

        /// <summary>
        /// Gets the daily goal for a selected food group.
        /// </summary>
        /// <param name="group">food group to return servings.</param>
        /// <param name="date">date to get servings for.</param>
        /// <returns>float of current servings for food group from all meals on date.</returns>
        public float GetDailyServings(int group, DateTime date)
        {
            return this.planHandler.GetDailyServings((FoodGroup)group, date);
        }

        /// <summary>
        /// Gets the servings of a food group from a plate.
        /// </summary>
        /// <param name="mealName">name of the plate.</param>
        /// <param name="date">date the plate is scheduled for.</param>
        /// <param name="group">foodgroup to get servings for.</param>
        /// <returns>float of servings for foodgroup from plate.</returns>
        public float GetPlateServings(string mealName, DateTime date, int group)
        {
            return this.planHandler.GetPlateServings(mealName, date, group);
        }

        /// <summary>
        /// Gets the list of foods for a meal.
        /// </summary>
        /// <param name="mealName">Name of meal.</param>
        /// <param name="date">Date of meal.</param>
        /// <returns>List of (string,float) tuples containing the food in the meal.</returns>
        public List<(string, float)> GetMealFoods(string mealName, DateTime date)
        {
            List<(string, float)> foods = new List<(string, float)>();
            foreach (Plate plate in this.planHandler.GetMealPlans())
            {
                if (plate.MealName == mealName && plate.Date == date)
                {
                    foreach (FoodItem foodItem in plate.Foods)
                    {
                        foods.Add((foodItem.Name, foodItem.Category.Servings));
                    }
                }
            }

            return foods;
        }

        /// <summary>
        /// Creates a new plate to add to the selected date's meals.
        /// </summary>
        /// <param name="foods">List of foods to add to the meal.</param>
        /// <param name="date">Date the meal is planned for.</param>
        /// <param name="mealType">Type of meal.</param>
        public void CreateMealPlan(List<(string, float)> foods, DateTime date, string mealType)
        {
            Plate meal = this.planHandler.CreatePlate(date, mealType);
            foreach ((string name, float servings) in foods)
            {
                var foodGroups = this.planHandler.GetAvailableFoods().Find(x => x.Item1 == name).Item2.Groups;
                Category category = new (foodGroups, servings);
                FoodItem foodItem = new FoodItem(name, category);
                this.planHandler.AddFoodToPlate(meal, foodItem);
            }
        }

        /// <summary>
        /// Adds a food item to a plate.
        /// </summary>
        /// <param name="mealName">name of meal food is being added to.</param>
        /// <param name="date">date of meal food is being added to.</param>
        /// <param name="foodName">name of food being added.</param>
        /// <param name="servings">servings of food being added.</param>
        public void AddFoodToPlate(string mealName, DateTime date, string foodName, float servings)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            Plate plate = this.planHandler.GetMealPlans().Find(x => x.Date == date && x.MealName == mealName);
            var foodGroups = this.planHandler.GetAvailableFoods().Find(x => x.Item1 == foodName).Item2.Groups;
            Category category = new (foodGroups, servings);
            FoodItem foodItem = new FoodItem(foodName, category);
            this.planHandler.AddFoodToPlate(plate, foodItem);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }

        /// <summary>
        /// Removes a food item from a plate.
        /// </summary>
        /// <param name="mealName">name of meal food is being removed from.</param>
        /// <param name="date">date of meal food is being removed from.</param>
        /// <param name="foodName">name of food being removed.</param>
        public void RemoveFoodFromPlate(string mealName, DateTime date, string foodName)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Plate plate = this.planHandler.GetMealPlans().Find(x => x.Date == date && x.MealName == mealName);
            FoodItem foodItem = plate.Foods.Find(x => x.Name == foodName);
            this.planHandler.RemoveFoodFromPlate(plate, foodItem);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }

        /// <summary>
        /// Creates a daily goal for a selected food category.
        /// </summary>
        /// <param name="group">integer representation of food group of goal.</param>
        /// <param name="servings">servings of goal.</param>
        public void SetGoal(int group, float servings)
        {
            Category category = new Category(new List<FoodGroup> { (FoodGroup)group }, servings);
            this.planHandler.SetDailyGoal(category);
        }

        /// <summary>
        /// Gets the daily goal for a selected food group.
        /// </summary>
        /// <param name="group">group.</param>
        /// <returns>servings for goal.</returns>
        public float GetGoal(int group)
        {
            return this.planHandler.GetDailyGoal((FoodGroup)group);
        }

        /// <summary>
        /// Changes the servings of a food item.
        /// </summary>
        /// <param name="foodName">name of food item being altered.</param>
        /// <param name="servings">new servings for food item.</param>
        public void ChangeFoodItemServings(string foodName, float servings)
        {
            this.planHandler.ChangeFoodItemServings(foodName, servings);
        }

        /// <summary>
        /// Changes the food groups of a food item.
        /// </summary>
        /// <param name="foodName">name of food item.</param>
        /// <param name="groups">new food groups for food item.</param>
        public void ChangeFoodItemGroups(string foodName, List<int> groups)
        {
            List<FoodGroup> foodGroups = new List<FoodGroup>();
            foreach (int group in groups)
            {
                foodGroups.Add((FoodGroup)group);
            }

            this.planHandler.ChangeFoodItemGroups(foodName, foodGroups);
            this.planHandler.ChangeFoodItemGroupsInPlates(foodName, foodGroups);
        }

        /// <summary>
        /// Gets the food groups of a food item.
        /// </summary>
        /// <param name="foodName">name of food.</param>
        /// <returns>List of foodgroups for food.</returns>
        public List<int> GetFoodGroups(string foodName)
        {
            List<int> groups = new List<int>();
            foreach (FoodGroup group in this.planHandler.GetAvailableFoods().Find(x => x.Item1 == foodName).Item2.Groups)
            {
                groups.Add((int)group);
            }

            return groups;
        }
    }
}
