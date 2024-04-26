// <copyright file="LunchPlate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    /// <summary>
    /// Lunch Plate class.
    /// </summary>
    internal class LunchPlate : Plate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LunchPlate"/> class.
        /// </summary>
        /// <param name="date">date this meal is planned for.</param>
        public LunchPlate(DateTime date)
            : base(date)
        {
        }

        /// <summary>
        /// Gets the meal type.
        /// </summary>
        public static new string MealType => "Lunch";
    }
}
