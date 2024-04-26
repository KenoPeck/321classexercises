// <copyright file="Category.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// enum for FoodGroup.
    /// </summary>
    public enum FoodGroup
    {
        /// <summary>
        /// Fruit food group
        /// </summary>
        Fruit,

        /// <summary>
        /// Vegetable food group
        /// </summary>
        Vegetable,

        /// <summary>
        /// Protein food group
        /// </summary>
        Protein,

        /// <summary>
        /// Grain food group
        /// </summary>
        Grain,

        /// <summary>
        /// Dairy food group
        /// </summary>
        Dairy,
    }

    /// <summary>
    /// Food Category class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="groups">Foodgroups of the food category.</param>
        /// <param name="servings">servings of the food category.</param>
        public Category(List<FoodGroup> groups, float servings)
        {
            this.Groups = groups;
            this.Servings = servings;
        }

        /// <summary>
        /// Gets or Sets List of FoodGroups in the category.
        /// </summary>
        public List<FoodGroup> Groups { get; set; }

        /// <summary>
        /// Gets number of servings in the category.
        /// </summary>
        public float Servings { get; private set; }
    }
}
