using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool _xTurn;
        private List<Coordinates> _coordListX = new List<Coordinates>();
        private List<Coordinates> _coordListO = new List<Coordinates>();

        List<Coordinates> currentPlayerCoords = null;


        public MainWindow()
        {
            InitializeComponent();
            _xTurn = true;
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            Close();
            win.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);

            string[] colPlacing = button.Tag.ToString().Split(",");
            var x = Int32.Parse(colPlacing[0]);
            var y = Int32.Parse(colPlacing[1]);

            char currentPlayer = GetCurrentPlayer();
            button.Content = currentPlayer;

            if (_xTurn)
            {
                currentPlayerCoords = _coordListX;
            }
            else
            {
                currentPlayerCoords = _coordListO;
            }

            currentPlayerCoords.Add(CoordinateFactory.New(x, y));

            var winnerDetails = EvaluateWinner(currentPlayer, currentPlayerCoords);

            if (winnerDetails.GameWon)
            {
                uxTurn.Text = winnerDetails.Message;

                // game is won, so disable all buttons
                foreach (object c in LogicalTreeHelper.GetChildren(uxGrid))
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        b.IsEnabled = false;
                    }
                }
            }
            else
            {
                ToggleTurns();

                // notify UI with the next player's turn
                uxTurn.Text = $"{GetCurrentPlayer()}'s turn";
                button.IsEnabled = String.IsNullOrWhiteSpace(button.Content.ToString());
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        #region Helper classes and methods

        private static char GetCurrentPlayer()
        {
            return _xTurn ? 'X' : 'O';
        }

        public static void ToggleTurns()
        {
            _xTurn = !_xTurn;
        }


        private WinnerDetails EvaluateWinner(char currentPlayer, List<Coordinates> currentPlayerCoords)
        {
            var winnerDetails = new WinnerDetails() { GameWon = false, Message = "" };

            // Horizontal winning condition
            bool horizontalConditions =
                currentPlayerCoords.Count(c => c.X == 0) >= 3 ||
                currentPlayerCoords.Count(c => c.X == 1) >= 3 ||
                currentPlayerCoords.Count(c => c.X == 2) >= 3;

            // Vertical winning condition
            bool verticalConditions =
                    currentPlayerCoords.Count(c => c.Y == 0) >= 3 ||
                    currentPlayerCoords.Count(c => c.Y == 1) >= 3 ||
                    currentPlayerCoords.Count(c => c.Y == 2) >= 3;

            // Diagonal winning condition
            bool diagonalConditionsA =
                    currentPlayerCoords.Contains(CoordinateFactory.New(0, 0)) &&
                    currentPlayerCoords.Contains(CoordinateFactory.New(1, 1)) &&
                    currentPlayerCoords.Contains(CoordinateFactory.New(2, 2));

            bool diagonalConditionsB =
                currentPlayerCoords.Contains(CoordinateFactory.New(2, 0)) &&
                currentPlayerCoords.Contains(CoordinateFactory.New(1, 1)) &&
                currentPlayerCoords.Contains(CoordinateFactory.New(0, 2));

            if (horizontalConditions)
            {
                winnerDetails.GameWon = true;
                winnerDetails.Message = $"{currentPlayer} won horizontally!";
            }

            if (verticalConditions)
            {
                winnerDetails.GameWon = true;
                winnerDetails.Message = $"{currentPlayer} won vertically!";

            }

            if (diagonalConditionsA || diagonalConditionsB)
            {
                winnerDetails.GameWon = true;
                winnerDetails.Message = $"{currentPlayer} won diagonally!";
            }

            return winnerDetails;
        }
    }


    internal struct WinnerDetails
    {
        public bool GameWon { get; set; }
        public string Message { get; set; }
    }

    internal struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal static class CoordinateFactory
    {
        internal static Coordinates New(int x, int y)
        {
            var coords = new Coordinates();
            coords.X = x;
            coords.Y = y;
            return coords;
        }
    }

    #endregion
}
