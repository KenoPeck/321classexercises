namespace PropertyChangedEventsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FirstNameBobButton_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Text = "CptS321: Property Changed Events Demo - Bob Peck";
            FirstNameBobButton.Text = "First Name Is Currently Bob. Click to change to Bob";
            FirstNameCorneliusButton.Text = "First Name Is Currently Bob. Click to change to Cornelius";
        }

        private void FirstNameCorneliusButton_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Text = "CptS321: Property Changed Events Demo - Cornelius Peck";
            FirstNameBobButton.Text = "First Name Is Currently Cornelius. Click to change to Bob";
            FirstNameCorneliusButton.Text = "First Name Is Currently Cornelius. Click to change to Cornelius";
        }

        private void LastNameSmithButton_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Text = "CptS321: Property Changed Events Demo - Cornelius Smith";
            LastNameSmithButton.Text = "Last Name Is Currently Smith. Click to change to Smith";
            LastNamePeckButton.Text = "Last Name Is Currently Smith. Click to change to Peck";
        }

        private void LastNamePeckButton_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Text = "CptS321: Property Changed Events Demo - Cornelius Peck";
            LastNameSmithButton.Text = "Last Name Is Currently Peck. Click to change to Smith";
            LastNamePeckButton.Text = "Last Name Is Currently Peck. Click to change to Peck";
        }
    }
}
