// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalExam
{
    /// <summary>
    /// Main form for the FinalExam application.
    /// </summary>
    public partial class Form1 : Form
    {
        private UserProfile currentUser;
        private List<UserProfile> users;
        private List<(string, float)> selectedFoods = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.currentUser = new ("TestUser", "Test");
            this.users = new List<UserProfile>();
            this.users.Add(this.currentUser);
            this.HideMealPlanner(); // comment out to debug without login
            foreach (string mealType in this.currentUser.GetMealTypes())
            {
                this.MealTypeBox.Items.Add(mealType);
            }
        }

        /// <summary>
        /// Function for when LoginButton is pressed.
        /// </summary>
        /// <param name="sender">object that sent signal.</param>
        /// <param name="e">eventArguments.</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (this.users.Any(x => x.UserID == this.UserIDTextBox.Text && x.Password == this.PasswordTextBox.Text))
            {
                this.currentUser = this.users.First(x => x.UserID == this.UserIDTextBox.Text && x.Password == this.PasswordTextBox.Text);
                this.HideLogin();
                this.ShowMealPlanner();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }

        /// <summary>
        /// Function to hide login elements.
        /// </summary>
        private void HideLogin()
        {
            this.LoginButton.Hide();
            this.UserIDTextBox.Hide();
            this.PasswordTextBox.Hide();
            this.UserIDLabel.Hide();
            this.PasswordLabel.Hide();
            this.RegisterButton.Hide();
            this.LoginLabel.Hide();
        }

        /// <summary>
        /// Function to show login elements.
        /// </summary>
        private void HideMealPlanner()
        {
            this.DatesLabel.Hide();
            this.DateBox.Hide();
            this.SelectedDateMealsLabel.Hide();
            this.MealSelectorBox.Hide();
            this.DailyGoalsGroup.Hide();
            this.AddFoodGroup.Hide();
            this.SelectedMealAmountsGroup.Hide();
            this.DailyAmountsGroup.Hide();
            this.EditMealGroup.Hide();
            this.AddMealGroup.Hide();
            this.EditFoodGroup.Hide();
        }

        /// <summary>
        /// Function to show meal planner.
        /// </summary>
        private void ShowMealPlanner()
        {
            this.DatesLabel.Show();
            this.DateBox.Show();
            this.SelectedDateMealsLabel.Show();
            this.MealSelectorBox.Show();
            this.DailyGoalsGroup.Show();
            this.AddFoodGroup.Show();
            this.SelectedMealAmountsGroup.Show();
            this.DailyAmountsGroup.Show();
            this.EditMealGroup.Show();
            this.AddMealGroup.Show();
            this.EditFoodGroup.Show();
        }

        /// <summary>
        /// Function for when RegisterButton is pressed.
        /// </summary>
        /// <param name="sender">object that sent signal.</param>
        /// <param name="e">eventArguments.</param>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (this.users.Any(x => x.UserID == this.UserIDTextBox.Text))
            {
                MessageBox.Show("User ID already exists");
            }
            else
            {
                this.currentUser = new UserProfile(this.UserIDTextBox.Text, this.PasswordTextBox.Text);
                this.users.Add(this.currentUser);
                this.HideLogin();
                this.ShowMealPlanner();
            }
        }

        /// <summary>
        /// Function for updating contributions to daily goals from selected meal.
        /// </summary>
        private void UpdatePlateDailyGoals()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8605 // Unboxing a possibly null value.
            float plateFruit = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, 0);
            this.FruitPercentLabel.Text = this.currentUser.GetGoal(0) == 0 ? "0%" : (plateFruit / this.currentUser.GetGoal(0) * 100).ToString() + "%";
            float plateVegetable = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, 1);
            this.VegetablePercentLabel.Text = this.currentUser.GetGoal(1) == 0 ? "0%" : (plateVegetable / this.currentUser.GetGoal(1) * 100).ToString() + "%";
            float plateProtein = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, 2);
            this.ProteinPercentLabel.Text = this.currentUser.GetGoal(2) == 0 ? "0%" : (plateProtein / this.currentUser.GetGoal(2) * 100).ToString() + "%";
            float plateGrains = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, 3);
            this.GrainsPercentLabel.Text = this.currentUser.GetGoal(3) == 0 ? "0%" : (plateGrains / this.currentUser.GetGoal(3) * 100).ToString() + "%";
            float plateDairy = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, 4);
            this.DairyPercentLabel.Text = this.currentUser.GetGoal(4) == 0 ? "0%" : (plateDairy / this.currentUser.GetGoal(4) * 100).ToString() + "%";
#pragma warning restore CS8605 // Unboxing a possibly null value.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        /// <summary>
        /// Function to update daily goals from all meals on selected dates.
        /// </summary>
        /// <param name="selectedDate">date of meals to update daily goal values from.</param>
        private void UpdateDailyGoals(DateTime selectedDate)
        {
            float dailyFruit = this.currentUser.GetDailyServings(0, selectedDate);
            this.FruitPercentLabelDaily.Text = this.currentUser.GetGoal(0) == 0 ? "0%" : (dailyFruit / this.currentUser.GetGoal(0) * 100).ToString() + "%";
            float dailyVegetable = this.currentUser.GetDailyServings(1, selectedDate);
            this.VegetablePercentLabelDaily.Text = this.currentUser.GetGoal(1) == 0 ? "0%" : (dailyVegetable / this.currentUser.GetGoal(1) * 100).ToString() + "%";
            float dailyProtein = this.currentUser.GetDailyServings(2, selectedDate);
            this.ProteinPercentLabelDaily.Text = this.currentUser.GetGoal(2) == 0 ? "0%" : (dailyProtein / this.currentUser.GetGoal(2) * 100).ToString() + "%";
            float dailyGrains = this.currentUser.GetDailyServings(3, selectedDate);
            this.GrainsPercentLabelDaily.Text = this.currentUser.GetGoal(3) == 0 ? "0%" : (dailyGrains / this.currentUser.GetGoal(3) * 100).ToString() + "%";
            float dailyDairy = this.currentUser.GetDailyServings(4, selectedDate);
            this.DairyPercentLabelDaily.Text = this.currentUser.GetGoal(4) == 0 ? "0%" : (dailyDairy / this.currentUser.GetGoal(4) * 100).ToString() + "%";
        }

        /// <summary>
        /// Function for when UpdateGoalsButton is pressed.
        /// </summary>
        private void UpdateGoalsButton_Click(object sender, EventArgs e)
        {
            float fruit = 0;
            float vegetable = 0;
            float protein = 0;
            float grains = 0;
            float dairy = 0;
            if (this.FruitDailyGoalTextBox.Text != string.Empty)
            {
                if (!float.TryParse(this.FruitDailyGoalTextBox.Text, out fruit))
                {
                    MessageBox.Show("Please enter a number for fruit goal.");
                    return;
                }
            }

            if (this.VegetableDailyGoalTextBox.Text != string.Empty)
            {
                if (!float.TryParse(this.VegetableDailyGoalTextBox.Text, out vegetable))
                {
                    MessageBox.Show("Please enter a number for vegetable goal.");
                    return;
                }
            }

            if (this.ProteinDailyGoalTextBox.Text != string.Empty)
            {
                if (!float.TryParse(this.ProteinDailyGoalTextBox.Text, out protein))
                {
                    MessageBox.Show("Please enter a number for protein goal.");
                    return;
                }
            }

            if (this.GrainsDailyGoalTextBox.Text != string.Empty)
            {
                if (!float.TryParse(this.GrainsDailyGoalTextBox.Text, out grains))
                {
                    MessageBox.Show("Please enter a number for grains goal.");
                    return;
                }
            }

            if (this.DairyDailyGoalTextBox.Text != string.Empty)
            {
                if (!float.TryParse(this.DairyDailyGoalTextBox.Text, out dairy))
                {
                    MessageBox.Show("Please enter a number for dairy goal.");
                    return;
                }
            }

            // Setting daily goals
            this.currentUser.SetGoal(0, fruit);
            this.currentUser.SetGoal(1, vegetable);
            this.currentUser.SetGoal(2, protein);
            this.currentUser.SetGoal(3, grains);
            this.currentUser.SetGoal(4, dairy);

            // Updating daily goal percentages if date is selected
            if (this.DateBox.SelectedItem != null)
            {
                this.UpdateDailyGoals((DateTime)this.DateBox.SelectedItem);

                // Updating plate daily goal percentages if meal is selected
                if (this.MealSelectorBox.SelectedItem != null)
                {
                    this.UpdatePlateDailyGoals();
                }
            }
        }

        /// <summary>
        /// Function for when AddFoodButton is pressed.
        /// </summary>
        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            float foodQuantity = 0;
            if (this.FoodNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a food name.");
            }
            else if (this.FoodQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.FoodQuantityTextBox.Text, out foodQuantity))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
            else if (this.FruitCheckBox.Checked == false && this.VegetableCheckBox.Checked == false && this.ProteinCheckBox.Checked == false && this.GrainsCheckBox.Checked == false && this.DairyCheckBox.Checked == false)
            {
                MessageBox.Show("Please select a category.");
            }
            else if (this.currentUser.GetFoodItems().Any(x => x.Item1 == this.FoodNameTextBox.Text))
            {
                MessageBox.Show("Food item already exists.");
            }
            else
            {
                List<int> groups = new ();
                if (this.FruitCheckBox.Checked)
                {
                    groups.Add(0);
                }

                if (this.VegetableCheckBox.Checked)
                {
                    groups.Add(1);
                }

                if (this.ProteinCheckBox.Checked)
                {
                    groups.Add(2);
                }

                if (this.GrainsCheckBox.Checked)
                {
                    groups.Add(3);
                }

                if (this.DairyCheckBox.Checked)
                {
                    groups.Add(4);
                }

                // Creating food item and adding to available food fields
                this.currentUser.CreateFoodItem(this.FoodNameTextBox.Text, foodQuantity, groups);
                string food = this.FoodNameTextBox.Text + " - " + this.FoodQuantityTextBox.Text + " Servings";
                this.AvailableFoodBox.Items.Add(food);
                this.EditMealFoodBox.Items.Add(food);
                this.EditFoodListBox.Items.Add(food);

                // Clearing relevant fields
                this.FoodNameTextBox.Clear();
                this.FoodQuantityTextBox.Clear();
                this.FruitCheckBox.Checked = false;
                this.VegetableCheckBox.Checked = false;
                this.ProteinCheckBox.Checked = false;
                this.GrainsCheckBox.Checked = false;
                this.DairyCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Function for when AddToMealButton is pressed.
        /// </summary>
        private void AddToMealButton_Click(object sender, EventArgs e)
        {
            float foodQuantity = 0;
            if (this.AvailableFoodBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else if (this.AddMealQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.AddMealQuantityTextBox.Text, out foodQuantity))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            else if (foodQuantity <= 0)
            {
                MessageBox.Show("Please enter a quantity greater than 0.");
            }
            else if (foodQuantity > float.Parse(this.AvailableFoodBox.SelectedItem.ToString().Split(" - ")[1].Split(" ")[0]))
            {
                MessageBox.Show("Please enter a quantity less than or equal to the available quantity.");
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type: this.AvailableFoodBox.SelectedItem has been checked for null.
                // Getting selected food item
                string food = this.AvailableFoodBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                string foodName = foodSplit[0];
                if (this.selectedFoods.Any(x => x.Item1 == foodName))
                {
                    MessageBox.Show("Food already added to meal.");
                    return;
                }

                string selectedFood = foodName + " - " + this.AddMealQuantityTextBox.Text.ToString() + " Servings";

                // Adding food to selectedFoods and FoodForMealBox
                this.selectedFoods.Add((foodName, foodQuantity));
                this.FoodForMealBox.Items.Add(selectedFood);

                // Subtracting food quantity from available food
                float availableQuantity = float.Parse(foodSplit[1].Split(" ")[0]);
                float newQuantity = availableQuantity - foodQuantity;
                string newFood = foodName + " - " + newQuantity.ToString() + " Servings";
                this.AvailableFoodBox.Items.Remove(food);
                this.AvailableFoodBox.Items.Add(newFood);
                this.EditMealFoodBox.Items.Remove(food);
                this.EditMealFoodBox.Items.Add(newFood);
                this.EditFoodListBox.Items.Remove(food);
                this.EditFoodListBox.Items.Add(newFood);
                this.currentUser.ChangeFoodItemServings(foodName, newQuantity);

                // Clearing relevant fields
                this.AvailableFoodBox.ClearSelected();
                this.AddMealQuantityTextBox.Clear();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
        }

        /// <summary>
        /// Function for when AddMealButton is pressed.
        /// </summary>
        private void AddMealButton_Click(object sender, EventArgs e)
        {
            if (this.MealTypeBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a meal type.");
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
                DateTime selectedDate = this.AddMealDateTimePicker.Value.Date;

                // Creating meal plan for selected date
                this.currentUser.CreateMealPlan(this.selectedFoods, selectedDate, this.MealTypeBox.SelectedItem.ToString());
                if (this.DateBox.Items.Contains(selectedDate) == false)
                {
                    this.DateBox.Items.Add(selectedDate);
                }

                // Clearing relevant fields
                this.selectedFoods.Clear();
                this.AvailableFoodBox.ClearSelected();
                this.MealTypeBox.ClearSelected();
                this.FoodForMealBox.Items.Clear();
                this.MealSelectorBox.Items.Clear();
                this.DateBox.ClearSelected();

                // Updating daily goal percentages if date is selected
                if (this.DateBox.SelectedItem != null)
                {
                    this.UpdateDailyGoals(selectedDate);
                }
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        /// <summary>
        /// Function for when a Date is selected.
        /// </summary>
        private void DateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MealSelectorBox.Items.Clear();
#pragma warning disable CS8605 // Unboxing a possibly null value.
            DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
            this.SelectedDateMealsLabel.Text = "Meals for " + selectedDate.ToShortDateString();
#pragma warning restore CS8605 // Unboxing a possibly null value.

            // Adding meal to MealSelectorBox
            foreach ((_, string mealName) in this.currentUser.GetMeals(selectedDate))
            {
                this.MealSelectorBox.Items.Add(mealName);
            }

            // Updating daily goal percentages
            this.DailyAmountsGroup.Text = "Daily Goal Levels for " + selectedDate.ToShortDateString() + ":";
            this.UpdateDailyGoals(selectedDate);
        }

        /// <summary>
        /// Function for when a Meal is selected.
        /// </summary>
        private void MealSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            // Updating selected meal daily goal percentages
            this.UpdatePlateDailyGoals();
            this.SelectedMealAmountsGroup.Text = "Daily Goal Contributions from " + this.MealSelectorBox.SelectedItem.ToString() + ":";

            this.EditMealFoodForMealBox.Items.Clear();

            // Adding food items from selected meal to EditMealFoodForMealBox
            this.EditMealGroup.Text = "Edit " + this.MealSelectorBox.SelectedItem.ToString() + " On " + this.DateBox.SelectedItem.ToString();
            foreach ((string, float) food in this.currentUser.GetMealFoods(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem))
            {
                this.EditMealFoodForMealBox.Items.Add(food.Item1 + " - " + food.Item2 + " Servings");
            }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        /// <summary>
        /// Function for when EditMealRemoveButton is pressed.
        /// </summary>
        private void EditMealRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.EditMealFoodForMealBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8605 // Unboxing a possibly null value.

                // Removing food from meal
                string food = this.EditMealFoodForMealBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
                string foodName = foodSplit[0];
                this.currentUser.RemoveFoodFromPlate(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, foodName);
                this.EditMealFoodForMealBox.Items.Remove(food);

                // Adding food back to available food
                foreach (string foodItem in this.EditMealFoodBox.Items)
                {
                    if (foodItem.Contains(foodName))
                    {
                        string[] foodItemSplit = foodItem.Split(" - ");
                        float availableQuantity = float.Parse(foodItemSplit[1].Split(" ")[0]);
                        float foodQuantity = float.Parse(foodSplit[1].Split(" ")[0]);
                        float newQuantity = availableQuantity + foodQuantity;
                        string newFood = foodName + " - " + newQuantity.ToString() + " Servings";
                        this.AvailableFoodBox.Items.Remove(foodItem);
                        this.AvailableFoodBox.Items.Add(newFood);
                        this.EditMealFoodBox.Items.Remove(foodItem);
                        this.EditMealFoodBox.Items.Add(newFood);
                        this.EditFoodListBox.Items.Remove(foodItem);
                        this.EditFoodListBox.Items.Add(newFood);
                        this.currentUser.ChangeFoodItemServings(foodName, newQuantity);
                        break;
                    }
                }

                this.UpdateDailyGoals((DateTime)this.DateBox.SelectedItem);
                this.UpdatePlateDailyGoals();
#pragma warning restore CS8605 // Unboxing a possibly null value.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        /// <summary>
        /// Function for when EditMealAddButton is pressed.
        /// </summary>
        private void EditMealAddButton_Click(object sender, EventArgs e)
        {
            float foodQuantity = 0;
            if (this.EditMealFoodBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else if (this.EditMealQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.EditMealQuantityTextBox.Text, out foodQuantity))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            else if (foodQuantity <= 0)
            {
                MessageBox.Show("Please enter a quantity greater than 0.");
            }
            else if (foodQuantity > float.Parse(this.EditMealFoodBox.SelectedItem.ToString().Split(" - ")[1].Split(" ")[0]))
            {
                MessageBox.Show("Please enter a quantity less than or equal to the available quantity.");
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8605 // Unboxing a possibly null value.
                string food = this.EditMealFoodBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
                string foodName = foodSplit[0];
                if (this.currentUser.GetMealFoods(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem).Any(x => x.Item1 == foodName))
                {
                    MessageBox.Show("Food already added to meal.");
                    return;
                }

                // Adding food to meal
                string selectedFood = foodName + " - " + this.EditMealQuantityTextBox.Text.ToString() + " Servings";
                this.currentUser.AddFoodToPlate(this.MealSelectorBox.SelectedItem.ToString(), (DateTime)this.DateBox.SelectedItem, foodName, foodQuantity);
                this.EditMealFoodForMealBox.Items.Add(selectedFood);

                // Subtracting food quantity from available food
                float availableQuantity = float.Parse(foodSplit[1].Split(" ")[0]);
                float newQuantity = availableQuantity - foodQuantity;
                string newFood = foodName + " - " + newQuantity.ToString() + " Servings";
                this.AvailableFoodBox.Items.Remove(food);
                this.AvailableFoodBox.Items.Add(newFood);
                this.EditMealFoodBox.Items.Remove(food);
                this.EditMealFoodBox.Items.Add(newFood);
                this.EditFoodListBox.Items.Remove(food);
                this.EditFoodListBox.Items.Add(newFood);
                this.currentUser.ChangeFoodItemServings(foodName, newQuantity);

                // Updating daily goal percentages
                this.UpdateDailyGoals((DateTime)this.DateBox.SelectedItem);
                this.UpdatePlateDailyGoals();
                this.EditMealQuantityTextBox.Clear();
            }
#pragma warning restore CS8605 // Unboxing a possibly null value.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        /// <summary>
        /// Function for when an Available Food is selected.
        /// </summary>
        private void EditFoodListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EditFoodListBox.SelectedItem != null)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string food = this.EditFoodListBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
                string foodName = foodSplit[0];
                float foodQuantity = float.Parse(foodSplit[1].Split(" ")[0]);
                List<int> foodGroups = this.currentUser.GetFoodGroups(foodName);

                // Updating fields for selected food item
                this.EditFoodQuantityTextBox.Text = foodQuantity.ToString();
                this.EditFoodFruitCheckBox.Checked = foodGroups.Contains(0);
                this.EditFoodVegetableCheckBox.Checked = foodGroups.Contains(1);
                this.EditFoodProteinCheckBox.Checked = foodGroups.Contains(2);
                this.EditFoodGrainsCheckBox.Checked = foodGroups.Contains(3);
                this.EditFoodDairyCheckBox.Checked = foodGroups.Contains(4);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
        }

        /// <summary>
        /// Function for when EditFoodUpdateButton is pressed.
        /// </summary>
        private void EditFoodUpdateButton_Click(object sender, EventArgs e)
        {
            float newQuantity = 0;
            if (this.EditFoodListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else if (this.EditFoodQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.EditFoodQuantityTextBox.Text, out newQuantity))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
            else if (this.EditFoodFruitCheckBox.Checked == false && this.EditFoodVegetableCheckBox.Checked == false && this.EditFoodProteinCheckBox.Checked == false && this.EditFoodGrainsCheckBox.Checked == false && this.EditFoodDairyCheckBox.Checked == false)
            {
                MessageBox.Show("Please select a food group.");
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string food = this.EditFoodListBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                string foodName = foodSplit[0];
                float oldQuantity = float.Parse(foodSplit[1].Split(" ")[0]);
                List<int> groups = new ();

                // Getting new food groups
                if (this.EditFoodFruitCheckBox.Checked)
                {
                    groups.Add(0);
                }

                if (this.EditFoodVegetableCheckBox.Checked)
                {
                    groups.Add(1);
                }

                if (this.EditFoodProteinCheckBox.Checked)
                {
                    groups.Add(2);
                }

                if (this.EditFoodGrainsCheckBox.Checked)
                {
                    groups.Add(3);
                }

                if (this.EditFoodDairyCheckBox.Checked)
                {
                    groups.Add(4);
                }

                if (this.currentUser.GetFoodGroups(foodName) == groups && newQuantity == oldQuantity)
                {
                    MessageBox.Show("No changes made to food item.");
                    return;
                }
                else if (this.currentUser.GetFoodGroups(foodName) == groups)
                {
                    // Updating food item servings but not food groups
                    this.currentUser.ChangeFoodItemServings(foodName, newQuantity);
                    string newFood = foodName + " - " + newQuantity.ToString() + " Servings";
                    this.EditFoodListBox.Items.Remove(food);
                    this.EditFoodListBox.Items.Add(newFood);
                    this.EditMealFoodBox.Items.Remove(food);
                    this.EditMealFoodBox.Items.Add(newFood);
                    this.AvailableFoodBox.Items.Remove(food);
                    this.AvailableFoodBox.Items.Add(newFood);
                }
                else if (newQuantity == oldQuantity)
                {
                    // Updating food item foodgroups but not servings
                    this.currentUser.ChangeFoodItemGroups(foodName, groups);
                }
                else
                {
                    // Updating food item servings and food groups
                    this.currentUser.ChangeFoodItemServings(foodName, newQuantity);
                    this.currentUser.ChangeFoodItemGroups(foodName, groups);
                    string newFood = foodName + " - " + newQuantity.ToString() + " Servings";
                    this.EditFoodListBox.Items.Remove(food);
                    this.EditFoodListBox.Items.Add(newFood);
                    this.EditMealFoodBox.Items.Remove(food);
                    this.EditMealFoodBox.Items.Add(newFood);
                    this.AvailableFoodBox.Items.Remove(food);
                    this.AvailableFoodBox.Items.Add(newFood);
                }

                // Updating daily goal percentages if date is selected
                if (this.DateBox.SelectedItem != null)
                {
                    this.UpdateDailyGoals((DateTime)this.DateBox.SelectedItem);

                    // Updating plate daily goal percentages if meal is selected
                    if (this.MealSelectorBox.SelectedItem != null)
                    {
                        this.UpdatePlateDailyGoals();
                    }
                }

                this.EditFoodListBox.ClearSelected();
            }
        }

        /// <summary>
        /// Function for when EditFoodRemoveButton is pressed.
        /// </summary>
        private void EditFoodRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.EditFoodListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.

                // Removing food item from available food and all meals
                this.currentUser.DeleteFoodItem(this.EditFoodListBox.SelectedItem.ToString().Split(" - ")[0]);

                // Removing food item from relevant fields
                this.AvailableFoodBox.Items.Remove(this.EditFoodListBox.SelectedItem);
                this.EditMealFoodBox.Items.Remove(this.EditFoodListBox.SelectedItem);
                foreach (var item in this.EditMealFoodForMealBox.Items)
                {
                    if (item.ToString().Contains(this.EditFoodListBox.SelectedItem.ToString().Split(" - ")[0]))
                    {
                        this.EditMealFoodForMealBox.Items.Remove(item);
                        break;
                    }
                }

                this.EditFoodListBox.Items.Remove(this.EditFoodListBox.SelectedItem);

                // Updating daily goal percentages if date is selected
                if (this.DateBox.SelectedItem != null)
                {
                    this.UpdateDailyGoals((DateTime)this.DateBox.SelectedItem);

                    // Updating plate daily goal percentages if meal is selected
                    if (this.MealSelectorBox.SelectedItem != null)
                    {
                        this.UpdatePlateDailyGoals();
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
    }
}
