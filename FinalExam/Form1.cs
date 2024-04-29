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
            this.EditMealButton.Hide();
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

        private void FruitDailyGoalTextBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    float goal = float.Parse(this.FruitDailyGoalTextBox.Text);
                    this.currentUser.SetGoal(0, goal);

                    // Updating daily goal percentages
                    if (this.DateBox.SelectedItem != null)
                    {
                        DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
                        float dailyFruit = this.currentUser.GetDailyServings(0, selectedDate);
                        this.FruitPercentLabelDaily.Text = this.currentUser.GetGoal(0) == 0 ? "0%" : (dailyFruit / this.currentUser.GetGoal(0) * 100).ToString() + "%";

                        // Updating selected meal daily goal percentages
                        if (this.MealSelectorBox.SelectedItem != null)
                        {
                            #pragma warning disable CS8604 // Possible null reference argument.
                            float plateFruit = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), selectedDate, 0);
                            #pragma warning restore CS8604 // Possible null reference argument.
                            this.FruitPercentLabel.Text = this.currentUser.GetGoal(0) == 0 ? "0%" : (plateFruit / this.currentUser.GetGoal(0) * 100).ToString() + "%";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
        }

        private void VegetableDailyGoalTextBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    float goal = float.Parse(this.VegetableDailyGoalTextBox.Text);
                    this.currentUser.SetGoal(1, goal);

                    // Updating daily goal percentages
                    if (this.DateBox.SelectedItem != null)
                    {
                        DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
                        float dailyVegetable = this.currentUser.GetDailyServings(1, selectedDate);
                        this.VegetablePercentLabelDaily.Text = this.currentUser.GetGoal(1) == 0 ? "0%" : (dailyVegetable / this.currentUser.GetGoal(1) * 100).ToString() + "%";

                        // Updating selected meal daily goal percentages
                        if (this.MealSelectorBox.SelectedItem != null)
                        {
                            #pragma warning disable CS8604 // Possible null reference argument.
                            float plateVegetable = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), selectedDate, 1);
                            #pragma warning restore CS8604 // Possible null reference argument.
                            this.VegetablePercentLabel.Text = this.currentUser.GetGoal(1) == 0 ? "0%" : (plateVegetable / this.currentUser.GetGoal(1) * 100).ToString() + "%";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
        }

        private void ProteinDailyGoalTextBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    float goal = float.Parse(this.ProteinDailyGoalTextBox.Text);
                    this.currentUser.SetGoal(2, goal);
                    if (this.DateBox.SelectedItem != null)
                    {
                        DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
                        float dailyProtein = this.currentUser.GetDailyServings(2, selectedDate);
                        this.ProteinPercentLabelDaily.Text = this.currentUser.GetGoal(2) == 0 ? "0%" : (dailyProtein / this.currentUser.GetGoal(2) * 100).ToString() + "%";

                        // Updating selected meal daily goal percentages
                        if (this.MealSelectorBox.SelectedItem != null)
                        {
                            #pragma warning disable CS8604 // Possible null reference argument.
                            float plateProtein = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), selectedDate, 2);
                            #pragma warning restore CS8604 // Possible null reference argument.
                            this.ProteinPercentLabel.Text = this.currentUser.GetGoal(2) == 0 ? "0%" : (plateProtein / this.currentUser.GetGoal(2) * 100).ToString() + "%";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
        }

        private void GrainsDailyGoalTextBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    float goal = float.Parse(this.GrainsDailyGoalTextBox.Text);
                    this.currentUser.SetGoal(3, goal);
                    if (this.DateBox.SelectedItem != null)
                    {
                        DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
                        float dailyGrains = this.currentUser.GetDailyServings(3, selectedDate);
                        this.GrainsPercentLabelDaily.Text = this.currentUser.GetGoal(3) == 0 ? "0%" : (dailyGrains / this.currentUser.GetGoal(3) * 100).ToString() + "%";

                        // Updating selected meal daily goal percentages
                        if (this.MealSelectorBox.SelectedItem != null)
                        {
                            #pragma warning disable CS8604 // Possible null reference argument.
                            float plateGrains = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), selectedDate, 3);
                            #pragma warning restore CS8604 // Possible null reference argument.
                            this.GrainsPercentLabel.Text = this.currentUser.GetGoal(3) == 0 ? "0%" : (plateGrains / this.currentUser.GetGoal(3) * 100).ToString() + "%";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
        }

        private void DairyDailyGoalTextBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    float goal = float.Parse(this.DairyDailyGoalTextBox.Text);
                    this.currentUser.SetGoal(4, goal);
                    if (this.DateBox.SelectedItem != null)
                    {
                        DateTime selectedDate = (DateTime)this.DateBox.SelectedItem;
                        float dailyDairy = this.currentUser.GetDailyServings(4, selectedDate);
                        this.DairyPercentLabelDaily.Text = this.currentUser.GetGoal(4) == 0 ? "0%" : (dailyDairy / this.currentUser.GetGoal(4) * 100).ToString() + "%";

                        // Updating selected meal daily goal percentages
                        if (this.MealSelectorBox.SelectedItem != null)
                        {
                            #pragma warning disable CS8604 // Possible null reference argument.
                            float plateDairy = this.currentUser.GetPlateServings(this.MealSelectorBox.SelectedItem.ToString(), selectedDate, 4);
                            #pragma warning restore CS8604 // Possible null reference argument.
                            this.DairyPercentLabel.Text = this.currentUser.GetGoal(4) == 0 ? "0%" : (plateDairy / this.currentUser.GetGoal(4) * 100).ToString() + "%";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            if (this.FoodNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a food name.");
            }
            else if (this.FoodQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.FoodQuantityTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
            else if (this.FruitCheckBox.Checked == false && this.VegetableCheckBox.Checked == false && this.ProteinCheckBox.Checked == false && this.GrainsCheckBox.Checked == false && this.DairyCheckBox.Checked == false)
            {
                MessageBox.Show("Please select a category.");
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
                this.currentUser.CreateFoodItem(this.FoodNameTextBox.Text, float.Parse(this.FoodQuantityTextBox.Text), groups);
                string food = this.FoodNameTextBox.Text + " - " + this.FoodQuantityTextBox.Text;
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

        private void AddToMealButton_Click(object sender, EventArgs e)
        {
            if (this.AvailableFoodBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a food item.");
            }
            else if (this.AddMealQuantityTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a quantity.");
            }
            else if (!float.TryParse(this.AddMealQuantityTextBox.Text, out _))
            {
                MessageBox.Show("Please enter a number for quantity.");
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            else if (float.Parse(this.AddMealQuantityTextBox.Text) <= 0)
            {
                MessageBox.Show("Please enter a quantity greater than 0.");
            }
            else if (float.Parse(this.AddMealQuantityTextBox.Text) > float.Parse(this.AvailableFoodBox.SelectedItem.ToString().Split(" - ")[1]))
            {
                MessageBox.Show("Please enter a quantity less than or equal to the available quantity.");
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type: this.AvailableFoodBox.SelectedItem has been checked for null.
                string food = this.AvailableFoodBox.SelectedItem.ToString();
                string[] foodSplit = food.Split(" - ");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                string foodName = foodSplit[0];
                string selectedFood = foodName + " - " + this.AddMealQuantityTextBox.Text.ToString();
                float foodQuantity = float.Parse(this.AddMealQuantityTextBox.Text.ToString());

                // Adding food to selectedFoods and FoodForMealBox
                this.selectedFoods.Add((foodName, foodQuantity));
                this.FoodForMealBox.Items.Add(selectedFood);

                // Clearing relevant fields
                this.AvailableFoodBox.ClearSelected();
                this.AddMealQuantityTextBox.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
        }

        private void AddMealButton_Click(object sender, EventArgs e)
        {
            if (this.MealTypeBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a meal type.");
            }
            else
            {
                DateTime selectedDate = this.AddMealDateTimePicker.Value.Date;
#pragma warning disable CS8602 // Dereference of a possibly null reference: this.MealTypeBox.SelectedItem has been checked for null.
#pragma warning disable CS8604 // Possible null reference argument.
                this.currentUser.CreateMealPlan(this.selectedFoods, selectedDate, this.MealTypeBox.SelectedItem.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

                if (this.DateBox.SelectedItem != null)
                {
                    // Updating daily goal percentages
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
            }
        }

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
            this.DailyAmountsGroup.Text = "Daily Amounts for " + selectedDate.ToShortDateString();
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

        private void MealSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8605 // Unboxing a possibly null value.

            // Updating selected meal daily goal percentages
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
            this.SelectedMealAmountsGroup.Text = "Selected Meal Amounts for " + this.MealSelectorBox.SelectedItem.ToString();
#pragma warning restore CS8605 // Unboxing a possibly null value.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
