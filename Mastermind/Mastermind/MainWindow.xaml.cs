using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mastermind.Models;
using Mastermind.UserControls;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        List<Peg> answerPegs = new List<Peg>();
        List<Peg> selectPegs = new List<Peg>();
        List<int> playerScores = new List<int>();

        public int numPlayers { get; set; } = 0;
        public int numGuess { get; set; } = 0;

        public int CurrentRow { get; set; } = 0;

        public int CurrentPlayer { get; set; } = 0;
        public bool TwoPlayer { get; set; } = false;

        public int numOfPegs { get; set; } = 0;

        public MainWindow()
		{
			InitializeComponent();
		}
        private void ResetAnswer()
        {
            answerPegs.Clear();
            AnswerPanel.Children.Clear();

            for (int i = 0; i < ColumnSlider.Value; i++)
            {
                Peg peg = new Peg();
                peg.Color = (Peg.Colors)random.Next(1, (int)Peg.Colors.Num_Colors);
                answerPegs.Add(peg);
            }

            PegButtonContainerControl pegContainer = new PegButtonContainerControl(answerPegs);
            AnswerPanel.Children.Add(pegContainer);
        }

            private void Reset()
	    	{

			    SelectionPanel.Children.Clear();
			    for (int i = 0; i < RowSlider.Value; i++)
			    {
				    List<Peg> pegs = new List<Peg>();
				    for (int j = 0; j < ColumnSlider.Value; j++) pegs.Add(new Peg());

				    PegButtonContainerControl pegContainer = new PegButtonContainerControl(pegs);
				    SelectionPanel.Children.Add(pegContainer);
			    }
			
			    HintPanel.Children.Clear();
			    for (int i = 0; i < RowSlider.Value; i++)
			    {
				    List<Peg> pegs = new List<Peg>();
				    for (int j = 0; j < ColumnSlider.Value; j++) pegs.Add(new Peg());
		
				    PegContainerControl pegContainer = new PegContainerControl(pegs);
				    HintPanel.Children.Add(pegContainer);
			    }

        }
		
		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{

            PegButtonContainerControl pegContainer = (PegButtonContainerControl)SelectionPanel.Children[CurrentRow];
            List<Peg> pegs = pegContainer.Pegs;

            List<Peg> selectPegsCopy = new List<Peg>();
            pegs.ForEach((item) => { selectPegsCopy.Add((Peg)item.Clone()); });

            List<Peg> answerPegsCopy = new List<Peg>();
            answerPegs.ForEach((item) => { answerPegsCopy.Add((Peg)item.Clone()); });

            int hintIndex = 0;


           for (int i = 0; i < selectPegsCopy.Count; i++)
            {
                if (selectPegsCopy[i].Color == answerPegsCopy[i].Color)
                {
                    selectPegsCopy[i].Color = Peg.NULL_COLOR;
                    answerPegsCopy[i].Color = Peg.NULL_COLOR;

                    PegContainerControl pegHintContainer = (PegContainerControl)HintPanel.Children[CurrentRow];
                    pegHintContainer.Pegs[hintIndex].Color = Peg.CORRECT_COLOR_POSITION;

                    updateScore(CurrentPlayer, numGuess);
                    numOfPegs++;
                    hintIndex++;
                }
                if(numOfPegs == pegs.Count)
                {
                    updateScore(CurrentPlayer, numGuess);
                    MessageBox.Show("You won!");
                    ResetGame();
                }
                else
                {
                    if (numGuess <= GuessSlider.Value)
                    {
                        numGuess++;
                    }
                    else
                    {
                        //lose condition
                        MessageBox.Show("Ran out of guesses! better luck next time!");
                        ResetGame();
                    }
                }
            }

            for (int i = 0; i < selectPegsCopy.Count; i++)
            {
                for (int j = 0; j < answerPegsCopy.Count; j++)
                {
                    if (selectPegsCopy[i].Color != Peg.NULL_COLOR && selectPegsCopy[i].Color == answerPegsCopy[j].Color)
                    {
                        selectPegsCopy[i].Color = Peg.NULL_COLOR;
                        answerPegsCopy[j].Color = Peg.NULL_COLOR;

                        PegContainerControl pegHintContainer = (PegContainerControl)HintPanel.Children[CurrentRow];
                        pegHintContainer.Pegs[hintIndex].Color = Peg.CORRECT_COLOR;

                        if (numGuess <= GuessSlider.Value)
                        {
                            numGuess++;
                        }
                        hintIndex++;
                    }
                }
            }

            CurrentRow++;
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Reset();
            ResetAnswer();
            ResetPlayer();
		}

        private void visibleButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (AnswerPanel.Visibility == Visibility.Visible)
            {
                AnswerPanel.Visibility = Visibility.Hidden;
                button.Content = "Show";
            }
            else
            {
                AnswerPanel.Visibility = Visibility.Visible;
                button.Content = "Hide";
            }
        }

        private void Resetbutton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            ResetPlayer();
            ResetAnswer();
        }
        private void ResetGame()
        {
            Reset();
            ResetPlayer();
            ResetAnswer();

            numOfPegs = 0;
            CurrentRow = 0;
        }
        private void OptionsCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox button = (CheckBox)sender;

            if (OptionsBox.Visibility == Visibility.Visible)
            {
                OptionsBox.Visibility = Visibility.Hidden;
                button.IsChecked = false;
            }
            else
            {
                OptionsBox.Visibility = Visibility.Visible;
                button.IsChecked = true;
            }
        }

        private void SelectPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox select = (ComboBox)sender;
            numPlayers = select.SelectedIndex + 1;
            
            if(numPlayers == 2)
            {
                TwoPlayer = true;
                CurrentPlayer = 0;
            }
        }

        private void ResetPlayer()
        {
            PlayerPanel.Children.Clear();
            playerScores.Clear();

            for (int i = 0; i < numPlayers; i++)
            {
                playerScores.Add(new int());
            }

            for (int i = 0; i < playerScores.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Foreground = new SolidColorBrush(Colors.White);
                textBlock.Text = "Player " + (i + 1) + ": " + playerScores[i].ToString("D4");
                PlayerPanel.Children.Add(textBlock);
            }

        }
        private void updateScore(int indexPlayer, int numguess)
        {
            if (indexPlayer == 0)
            {
                playerScores[0] += 100 - (numGuess * 10);
                PlayerPanel.Children.Clear();
                for (int i = 0; i < playerScores.Count; i++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Foreground = new SolidColorBrush(Colors.White);
                    textBlock.Text = "Player " + (i + 1) + ": " + playerScores[i].ToString("D4");
                    PlayerPanel.Children.Add(textBlock);
                }
            }
            if (indexPlayer == 1)
            {
                playerScores[1] += 100 - (numGuess * 10);
                PlayerPanel.Children.Clear();
                for (int i = 0; i < playerScores.Count; i++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Foreground = new SolidColorBrush(Colors.White);
                    textBlock.Text = "Player " + (i + 1) + ": " + playerScores[i].ToString("D4");
                    PlayerPanel.Children.Add(textBlock);
                }
            }
        }
        private void nextPlayer(int nextPlayer)
        {
            Reset();
            ResetAnswer();

            numGuess = 0;
            CurrentRow = 0;
            CurrentPlayer = nextPlayer;

            if (CurrentPlayer == 0)
            {
                MessageBox.Show("1st Player Turn.");
            }
            else
            {
                MessageBox.Show("2st Player Turn.");
            }
        }
      
    }
}
