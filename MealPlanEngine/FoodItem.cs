// <copyright file="FoodItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Food Item class.
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodItem"/> class.
        /// </summary>
        /// <param name="name">Name of the food item.</param>
        /// <param name="category">Food Categories of the food item.</param>
        public FoodItem(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }

        /// <summary>
        /// Gets name of the food item.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets category of the food item.
        /// </summary>
        public Category Category { get; private set; }
    }
}
