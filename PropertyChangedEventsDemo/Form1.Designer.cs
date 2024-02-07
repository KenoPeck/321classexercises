namespace PropertyChangedEventsDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Person formPerson = new("Cornelius", "Peck");
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            FirstNameBobButton = new Button();
            FirstNameCorneliusButton = new Button();
            LastNameSmithButton = new Button();
            LastNamePeckButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FirstNameCorneliusButton);
            groupBox1.Controls.Add(FirstNameBobButton);
            groupBox1.Location = new Point(86, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 156);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "First Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LastNamePeckButton);
            groupBox2.Controls.Add(LastNameSmithButton);
            groupBox2.Location = new Point(86, 245);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(598, 156);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Last Name";
            // 
            // FirstNameBobButton
            // 
            FirstNameBobButton.Location = new Point(15, 36);
            FirstNameBobButton.Name = "FirstNameBobButton";
            FirstNameBobButton.Size = new Size(566, 29);
            FirstNameBobButton.TabIndex = 0;
            FirstNameBobButton.Text = "First Name Is Currently Cornelius. Click to change to Bob";
            FirstNameBobButton.UseVisualStyleBackColor = true;
            FirstNameBobButton.Click += FirstNameBobButton_Click;
            // 
            // FirstNameCorneliusButton
            // 
            FirstNameCorneliusButton.Location = new Point(15, 107);
            FirstNameCorneliusButton.Name = "FirstNameCorneliusButton";
            FirstNameCorneliusButton.Size = new Size(566, 29);
            FirstNameCorneliusButton.TabIndex = 1;
            FirstNameCorneliusButton.Text = "First Name Is Currently Cornelius. Click to change to Cornelius";
            FirstNameCorneliusButton.UseVisualStyleBackColor = true;
            FirstNameCorneliusButton.Click += FirstNameCorneliusButton_Click;
            // 
            // LastNameSmithButton
            // 
            LastNameSmithButton.Location = new Point(15, 37);
            LastNameSmithButton.Name = "LastNameSmithButton";
            LastNameSmithButton.Size = new Size(566, 29);
            LastNameSmithButton.TabIndex = 2;
            LastNameSmithButton.Text = "Last Name Is Currently Peck. Click to change to Smith";
            LastNameSmithButton.UseVisualStyleBackColor = true;
            LastNameSmithButton.Click += LastNameSmithButton_Click;
            // 
            // LastNamePeckButton
            // 
            LastNamePeckButton.Location = new Point(15, 100);
            LastNamePeckButton.Name = "LastNamePeckButton";
            LastNamePeckButton.Size = new Size(566, 29);
            LastNamePeckButton.TabIndex = 3;
            LastNamePeckButton.Text = "Last Name Is Currently Peck. Click to change to Peck";
            LastNamePeckButton.UseVisualStyleBackColor = true;
            LastNamePeckButton.Click += LastNamePeckButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "CptS321: Property Changed Events Demo - Cornelius Peck";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button FirstNameBobButton;
        private GroupBox groupBox2;
        private Button FirstNameCorneliusButton;
        private Button LastNamePeckButton;
        private Button LastNameSmithButton;
    }
}
