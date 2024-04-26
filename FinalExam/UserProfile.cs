// <copyright file="UserProfile.cs" company="PlaceholderCompany">
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
        /// Shows a selected meal plan.
        /// </summary>
        public void ShowMeal()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Shows the daily goals for the selected date.
        /// </summary>
        /// <param name="date">date to display fullfill amounts of goals for.</param>
        public void ShowDailyGoals(DateTime date)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a new food item to add to records of available foods.
        /// </summary>
        /// <param name="name">Name of new food item.</param>
        /// <param name="categories">Categories of new food item.</param>
        public void CreateFoodItem(string name, Category categories)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a new plate to add to the selected date's meals.
        /// </summary>
        /// <param name="date">Date the meal is planned for.</param>
        public void CreateMealPlan(DateTime date)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a daily goal for a selected food category.
        /// </summary>
        /// <param name="category">Food category to set goal for.</param>
        public void SetGoal(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
