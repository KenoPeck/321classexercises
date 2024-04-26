// <copyright file="Plate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Abstract class for Plate.
    /// </summary>
    public abstract class Plate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Plate"/> class.
        /// </summary>
        /// <param name="date">date the meal is planned for.</param>
        public Plate(DateTime date)
        {
            this.Foods = new List<FoodItem>();
            this.FoodCategories = new List<Category>();
            this.Date = date;
        }

        /// <summary>
        /// Gets meal type of the plate.
        /// </summary>
        public static string MealType => "Breakfast";

        /// <summary>
        /// Gets list of FoodItems on the plate.
        /// </summary>
        public List<FoodItem> Foods { get; private set; }

        /// <summary>
        /// Gets list of Categories of FoodItems on the plate.
        /// </summary>
        public List<Category> FoodCategories { get; private set; }

        /// <summary>
        /// Gets date the meal is planned for.
        /// </summary>
        public DateTime Date { get; private set; }
    }
}
