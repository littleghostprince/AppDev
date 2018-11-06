using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Guessing_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<Label> guessLabels = new List<Label>();
        List<PictureBox> guessPictures = new List<PictureBox>();
        int randomNumberAnswer = 0;
        int numGuess = 0;

        System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Ashley\Music\JeopardyTheme.wav");
     
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            ResetGame();
        }

        private void InitializeGame()
        {
            //add guess lables to the array

            guessLabels.Add(label2);
            guessLabels.Add(label3);
            guessLabels.Add(label4);
            guessLabels.Add(label5);
            guessLabels.Add(label6);

            //add pictures in the guess pictures
            guessPictures.Add(pictureBox1);
            guessPictures.Add(pictureBox2);
            guessPictures.Add(pictureBox3);
            guessPictures.Add(pictureBox4);
            guessPictures.Add(pictureBox5);

            foreach(Label l in guessLabels)
            {
                l.Text = "";
            }
            foreach (PictureBox p in guessPictures)
            {
                p.Image = null;
            }
        }
        private void ResetGame()
        {
            foreach(Label label in guessLabels)
            {
                label.Text = "";
            }

            foreach (PictureBox pic in guessPictures)
            {
                pic.Image = null;
            }

            maxNumber.Enabled = true;
            maxNumber.Value = 10;

            startButton.Enabled = true;
            startButton.Text = "Start";

            guessTextBox.Enabled = false;
            numGuess = 0;
        }
        private void StartGame()
        {
            randomNumberAnswer = random.Next(0, (int)maxNumber.Value);
            guessTextBox.Enabled = true;
            startSoundPlayer.Play();
        }
        private void GameWon()
        {
            startSoundPlayer.Stop();
            MessageBox.Show("Congratulation! You won!");
            guessTextBox.Enabled = false;
        }
        private void GameLost()
        {
            startSoundPlayer.Stop();
            MessageBox.Show("Game over! Better Luck next time!");
            guessTextBox.Enabled = false; 
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(button != null)
            {
                if(button.Text == "Start")
                {
                    button.Text = "";
                    StartGame();
                }
                else
                {
                    ResetGame();
                }
            }
        }

        private void guessTextKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int guess = 0;
                Int32.TryParse(guessTextBox.Text, out guess);

                if(guess == randomNumberAnswer)
                {
                    guessLabels[numGuess].Text = guess + " correct!";
                    guessLabels[numGuess].ForeColor = Color.Green;

                    guessPictures[numGuess].Image = Properties.Resources.correct_icon;
                    GameWon();
                }
                else
                {
                    string highLow = (guess > randomNumberAnswer) ? "too high" : "too low";
                    guessLabels[numGuess].Text = highLow;
                    guessPictures[numGuess].Image = Properties.Resources.incorrect_icon;
                    guessPictures[numGuess].ForeColor = Color.Red;

                    numGuess++;

                    if(numGuess >= 5)
                    {
                        GameLost();
                    }
                }
            }
        }
        
        private void guessTextKeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
