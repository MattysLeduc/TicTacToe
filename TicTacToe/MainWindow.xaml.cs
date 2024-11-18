using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Board gameBoard;
        private PlayerEnum currentPlayer = PlayerEnum.X;

        //Player Stats Initialization
        private int gamesplayedX = 0;
        private int gamesWonX = 0;

        private int gamesPlayedO = 0;
        private int gamesWonO = 0;

        public MainWindow(string startingPlayer)
        {
            InitializeComponent();
            gameBoard = new Board();
            currentPlayer = (PlayerEnum)Enum.Parse(typeof(PlayerEnum), startingPlayer);
            UpdateTurnLabel();
            ResetTiles();
        }



        private void Tile_Click(object sender, MouseButtonEventArgs e)
        {
            var tile = sender as Image;
            int row = Grid.GetRow(tile);
            int col = Grid.GetColumn(tile);

            if (gameBoard.Select(row, col, currentPlayer))
            {
                tile.Source = new BitmapImage(new Uri(currentPlayer == PlayerEnum.X
                    ? "images/tic-tac-toe_x.png"
                    : "images/tic-tac-toe_o.png", UriKind.Relative));

                if (gameBoard.CheckEndCondition(out PlayerEnum winner))
                {
                    if (winner != PlayerEnum.NONE)
                    {
                        MessageBox.Show($"{winner} wins!");

                        if (winner == PlayerEnum.X)
                        {
                            gamesplayedX++;
                            gamesWonX++;
                            gamesPlayedO++;
                        }
                        else
                        {
                            gamesPlayedO++;
                            gamesWonO++;
                            gamesplayedX++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("It's a draw!");
                        gamesplayedX++;
                        gamesPlayedO++;
                    }

                    gameBoard.Reset();
                    ResetTiles();
                    UpdateStats();
                }
                else
                {
                    currentPlayer = currentPlayer == PlayerEnum.X ? PlayerEnum.O : PlayerEnum.X;
                    UpdateTurnLabel();
                }
            }
        }

        private void ResetTiles()
        {
            foreach (var child in myGrid.Children)
           {
              if (child is Image img)
            {
                  img.Source = new BitmapImage(new Uri("images/Blank_image.png", UriKind.Relative));
                }
            }
        }

        private void UpdateTurnLabel()
        {
            lbl_TurnLabel.Content = $"Turn: Player {currentPlayer}";
        }

        private void UpdateStats()
        {
            lbl_XGamesPlayed.Content = $"Games Played: {gamesplayedX}";
            lbl_XGamesWon.Content = $"Games Won: {gamesWonX}";
            lbl_XWinRatio.Content = $"Win Ratio: {(gamesplayedX > 0 ? (gamesWonX * 100 / gamesplayedX) : 0)}%";

            lbl_OGamesPlayed.Content = $"Games Played: {gamesPlayedO}";
            lbl_OGamesWon.Content = $"Games Won: {gamesWonO}";
            lbl_OWinRatio.Content = $"Win Ratio: {(gamesPlayedO > 0 ? (gamesWonO * 100 / gamesPlayedO) : 0)}%";
        }

        private void Btn_StopGame_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show(
                "Do you want to stop the game?",
                "Stopping Game",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
