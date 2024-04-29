// <copyright file="DinnerPlate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Dinner plate class.
    /// </summary>
    internal class DinnerPlate : Plate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DinnerPlate"/> class.
        /// </summary>
        /// <param name="date">Date meal is planned for.</param>
        /// <param name="mealName">Name of the meal.</param>
        public DinnerPlate(DateTime date, string mealName)
            : base(date, mealName)
        {
        }

        /// <summary>
        /// Gets the meal type.
        /// </summary>
        public static new string MealType => "Dinner";
    }
}
