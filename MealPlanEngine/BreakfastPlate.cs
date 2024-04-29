// <copyright file="BreakfastPlate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Class for a breakfast plate.
    /// </summary>
    internal class BreakfastPlate : Plate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BreakfastPlate"/> class.
        /// </summary>
        /// <param name="date">date this meal is planned for.</param>
        /// <param name="mealName">name of the meal.</param>
        public BreakfastPlate(DateTime date, string mealName)
            : base(date, mealName)
        {
        }

        /// <summary>
        /// Gets the meal type.
        /// </summary>
        public static new string MealType => "Breakfast";
    }
}
