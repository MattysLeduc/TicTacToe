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
                if(currentPlayer == PlayerEnum.X)
                {
                    tile.Source = new BitmapImage(new Uri($"images/tic-tac-toe_x.png", UriKind.Relative));
                }
                else
                {
                    tile.Source = new BitmapImage(new Uri($"images/tic-tac-toe_o.png", UriKind.Relative));
                }
                if (gameBoard.CheckWin(out PlayerEnum winner) && winner != PlayerEnum.NONE)
                {
                    MessageBox.Show($"{winner} wins");
                    gameBoard.Reset();
                    ResetTiles();
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
    }
}
