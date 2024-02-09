using System.ComponentModel;

namespace PropertyChangedEventsDemo
{
    public partial class Form1 : Form
    {
        internal Person instanceOfPerson = new();
        public Form1()
        {
            InitializeComponent();
            instanceOfPerson.PropertyChanged += Person_PropertyChanged;
            instanceOfPerson.FirstName = "noname";
            instanceOfPerson.LastName = "noname";
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FirstName")
            {
                FirstNameBobButton.Text = "First Name is currently " + instanceOfPerson.FirstName + ". Click to change to Bob";
                FirstNameCorneliusButton.Text = "First Name is currently " + instanceOfPerson.FirstName + ". Click to change to Cornelius";

            }
            else if (e.PropertyName == "LastName")
            {
                LastNameSmithButton.Text = "Last Name is currently " + instanceOfPerson.LastName + ". Click to change to Smith";
                LastNamePeckButton.Text = "Last Name is currently " + instanceOfPerson.LastName + ". Click to change to Peck";
            }
            Form1.ActiveForm.Text = "CptS321: Property Changed Events Demo - " + instanceOfPerson.FirstName + " " + instanceOfPerson.LastName;
        }

        private void FirstNameBobButton_Click(object sender, EventArgs e)
        {
            instanceOfPerson.FirstName = FirstNameBobButton.Tag.ToString();
        }

        private void FirstNameCorneliusButton_Click(object sender, EventArgs e)
        {
            instanceOfPerson.FirstName = FirstNameCorneliusButton.Tag.ToString();
        }

        private void LastNameSmithButton_Click(object sender, EventArgs e)
        {
            instanceOfPerson.LastName = LastNameSmithButton.Tag.ToString();
        }

        private void LastNamePeckButton_Click(object sender, EventArgs e)
        {
            instanceOfPerson.LastName = LastNamePeckButton.Tag.ToString();
        }
    }
}
