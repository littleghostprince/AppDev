using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label firstClick = null;
        Label secondClick = null;
        private void AssignIconsToSquares()
        {
            // Iterate through all controls in the tableLayoutPanel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Check if the control is a Label
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void CheckForWinner()
        {
            // Iterate through all controls in the tableLayoutPanel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Check if the control is a Label
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    // Check if any of the labels still has the forecolor set to it's backcolor
                    // If so then the game is not over
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // If all the labels are flipped, the player has won
            // Show winner message box
            MessageBox.Show("You matched all the icons!", "Congratulations");

            // Close the application
            Close();
        }
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelClicker(object sender, EventArgs e)
        {
            // If the timer is running then don't allow any more clicks until it is reset
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Return if the label text/forecolor is black (already clicked)
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // Set the first click label if not set yet
                if (firstClick == null)
                {
                    firstClick = clickedLabel;
                    // Set the label forecolor to black to 'reveal' the icon
                    firstClick.ForeColor = Color.Black;
                    return;
                }

                // Set the second click label
                secondClick = clickedLabel;
                secondClick.ForeColor = Color.Black;

                CheckForWinner();

                // Check for a match, compare the text of the two labels
                if (firstClick.Text == secondClick.Text)
                {
                    firstClick = null;
                    secondClick = null;
                    return;
                }

                // Start the timer
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            // Reset firstClick and secondClick
            firstClick = null;
            secondClick = null;
        }
    }
}
