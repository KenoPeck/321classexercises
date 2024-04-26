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
        /// Gets name of the food item.
        /// </summary>
        private string name;

        /// <summary>
        /// Gets category of the food item.
        /// </summary>
        private Category category;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodItem"/> class.
        /// </summary>
        /// <param name="name">Name of the food item.</param>
        /// <param name="category">Food Categories of the food item.</param>
        public FoodItem(string name, Category category)
        {
            this.name = name;
            this.category = category;
        }

        /// <summary>
        /// Gets name of the food item.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets category of the food item.
        /// </summary>
        public Category Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>
        /// Change the servings of the food item.
        /// </summary>
        /// <param name="servings">new servings of the food item.</param>
        public void ChangeServings(float servings)
        {
            this.category.Servings = servings;
        }

        /// <summary>
        /// Change the food groups of the food item.
        /// </summary>
        /// <param name="groups">List of new foodgroups of the food item.</param>
        public void ChangeFoodGroups(List<FoodGroup> groups)
        {
            this.category.Groups = groups;
        }
    }
}
