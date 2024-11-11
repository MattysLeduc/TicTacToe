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
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Window
    {
        public string SelectedPlayer { get; private set; }

        public Startup()
        {
            InitializeComponent();
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = "X";
            StartGame();
        }

        private void ButtonO_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = "O";
            StartGame();
        }

        private void StartGame()
        {
            MainWindow mainWindow = new MainWindow(SelectedPlayer);
            mainWindow.Show();
            this.Close();
        }
    }
}
