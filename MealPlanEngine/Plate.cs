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

        /// <summary>
        /// Adds a food item to the plate.
        /// </summary>
        /// <param name="foodItem">Food item to be added to plate.</param>
        public void AddFoodItem(FoodItem foodItem)
        {
            if (this.Foods.All(x => x != foodItem))
            {
                this.Foods.Add(foodItem);
            }
            else
            {
                throw new InvalidOperationException("Food item already exists on the plate.");
            }

            foreach (FoodGroup group in foodItem.Category.Groups)
            {
                if (this.FoodCategories.All(x => x.Groups[0] != group))
                {
                    this.FoodCategories.Add(new Category(new List<FoodGroup> { group }, foodItem.Category.Servings));
                }
                else
                {
                    foreach (Category category in this.FoodCategories)
                    {
                        if (category.Groups[0] == group)
                        {
                            category.Servings += foodItem.Category.Servings;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes a food item from the plate.
        /// </summary>
        /// <param name="foodItem">FoodItem to be reomved from the plate.</param>
        public void RemoveFoodItem(FoodItem foodItem)
        {
            this.Foods.Remove(foodItem);
            foreach (FoodGroup group in foodItem.Category.Groups)
            {
                foreach (Category category in this.FoodCategories)
                {
                    if (category.Groups[0] == group)
                    {
                        category.Servings -= foodItem.Category.Servings;
                        break;
                    }
                }
            }
        }
    }
}
