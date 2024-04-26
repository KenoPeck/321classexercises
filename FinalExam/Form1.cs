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
        /// Function to show meal planner.
        /// </summary>
        private void ShowMealPlanner()
        {

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
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
