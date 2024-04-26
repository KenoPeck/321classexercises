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

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.currentUser = new("TestUser", "Test");
            this.users = new List<UserProfile>();
            this.users.Add(this.currentUser);
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
            this.ViewOnDateGroup.Hide();
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
            this.ViewOnDateGroup.Show();
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

        private void UpdateDailyGoals(int goal)
        {
            if (goal == 1)
            {
                this.FruitDailyGoalTextBox.Text = this.currentUser.GetGoal(1).ToString();
            }
            else if (goal == 2)
            {
                this.VegetableDailyGoalTextBox.Text = this.currentUser.GetGoal(2).ToString();
            }
            else if (goal == 3)
            {
                this.ProteinDailyGoalTextBox.Text = this.currentUser.GetGoal(3).ToString();
            }
            else if (goal == 4)
            {
                this.GrainsDailyGoalTextBox.Text = this.currentUser.GetGoal(4).ToString();
            }
            else if (goal == 5)
            {
                this.DairyDailyGoalTextBox.Text = this.currentUser.GetGoal(5).ToString();
            }
        }

        private void FruitDailyGoalTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                float goal = float.Parse(this.FruitDailyGoalTextBox.Text);
                this.currentUser.SetGoal(1, goal);
                this.UpdateDailyGoals(1);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number.");
            }
        }

        private void VegetableDailyGoalTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                float goal = float.Parse(this.VegetableDailyGoalTextBox.Text);
                this.currentUser.SetGoal(2, goal);
                this.UpdateDailyGoals(2);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number.");
            }
        }

        private void ProteinDailyGoalTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                float goal = float.Parse(this.ProteinDailyGoalTextBox.Text);
                this.currentUser.SetGoal(3, goal);
                this.UpdateDailyGoals(3);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number.");
            }
        }

        private void GrainsDailyGoalTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                float goal = float.Parse(this.GrainsDailyGoalTextBox.Text);
                this.currentUser.SetGoal(4, goal);
                this.UpdateDailyGoals(4);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number.");
            }
        }

        private void DairyDailyGoalTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                float goal = float.Parse(this.DairyDailyGoalTextBox.Text);
                this.currentUser.SetGoal(5, goal);
                this.UpdateDailyGoals(5);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a number.");
            }
        }
    }
}
