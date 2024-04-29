// <copyright file="PlateFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MealPlanEngine
{
    using System.Reflection;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

    /// <summary>
    /// Factory class for creating Plate objects.
    /// </summary>
    internal class PlateFactory : Plate
    {
        /// <summary>
        /// Dictionary of supported meal types.
        /// </summary>
        private Dictionary<string, Type> mealTypes = new Dictionary<string, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlateFactory"/> class.
        /// </summary>
        /// <param name="date">date for base class constructor.</param>
        /// <param name="mealName">meal name for base class constructor.</param>
        public PlateFactory(DateTime date, string mealName)
            : base(date, mealName)
        {
            this.TraverseAvailableMealTypes((mealType, type) => this.mealTypes.Add(mealType, type));
        }

        private delegate void OnMealType(string mealType, Type type);

        /// <summary>
        /// Create a new Plate object for a meal type and date.
        /// </summary>
        /// <param name="mealType">mealtype of the plate being created.</param>
        /// <param name="date">date the meal is planned for.</param>
        /// <param name="mealName">name of the meal.</param>
        /// <returns>Plate object of mealtype subclass.</returns>
        /// <exception cref="ArgumentException">unhandled meal type.</exception>
        public Plate CreatePlate(string mealType, DateTime date, string mealName)
        {
            if (this.mealTypes.ContainsKey(mealType))
            {
                object plateObject = System.Activator.CreateInstance(this.mealTypes[mealType], date, mealName);
                if (plateObject is Plate)
                {
                    return (Plate)plateObject;
                }
                else
                {
                    throw new ArgumentException("Invalid meal type.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid meal type.");
            }
        }

        /// <summary>
        /// Get all available meal types.
        /// </summary>
        /// <returns>List of available meal types as strings.</returns>
        public List<string> GetMealTypes()
        {
            return this.mealTypes.Keys.ToList();
        }

        /// <summary>
        /// Traverse all available meal types and invoke the function passed as parameter.
        /// </summary>
        /// <param name="onMealType">function delegate for adding meal types to dictionary.</param>
        private void TraverseAvailableMealTypes(OnMealType onMealType)
        {
            // get the type declaration of Plate
            Type plateType = typeof(Plate);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from Plate class using LINQ
                IEnumerable<Type> plateTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(plateType));
                foreach (var type in plateTypes)
                {
                    // for each subclass, retrieve the MealType property
                    PropertyInfo mealField = type.GetProperty("MealType");
                    if (mealField != null)
                    {
                        // Get the string of the MealType
                        object value = mealField.GetValue(type);
                        if (value is string)
                        {
                            string mealType = (string)value;

                            // Invoke the function passed as parameter with the mealtype string and the plate class
                            onMealType(mealType, type);
                        }
                    }
                }
            }
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }
}
