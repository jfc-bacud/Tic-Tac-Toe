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
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] gameGrid = new Button[3, 3];
        Game gameLogic = new Game();
        int turnsDone = 0;
        public MainWindow()
        {
            InitializeComponent();
            GameGrid();
            DisplayGame();
        }

        public void GameGrid()
        {
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    gameGrid[x, y] = new Button();
                    gameGrid[x, y].Name = "btn" + ((x * 10) + (y)).ToString();
                    gameGrid[x, y].Width = 100;
                    gameGrid[x, y].Height = 100;
                    gameGrid[x, y].Background = Brushes.White;
                    gameGrid[x, y].Click += PlayerClicks;
                }
            }
        }
        private void PlayerClicks(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Content == null)
            {
                button.Content = gameLogic.CurrentPlayer;
                button.FontSize = 60;
                gameLogic.SetNext();
                lblDesc.Content = $"Player '{gameLogic.CurrentPlayer}' Turn!";
                turnsDone++;
                gameLogic.CheckState(gameGrid, lblDesc);

                if (turnsDone == 9)
                {
                    lblDesc.Content = $"Board Cleared! Player '{gameLogic.CurrentPlayer}' Turn!";
                    gameLogic.ClearBoard(gameGrid);
                    turnsDone = 0;
                }
            }
        }
        public void DisplayGame()
        {
            int row = 0;
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                int current = 59;

                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    Canvas.SetTop(gameGrid[x, y], row);
                    Canvas.SetLeft(gameGrid[x, y], current);
                    current += 100;

                    tttCanvas.Children.Add(gameGrid[x, y]);
                }
                row += 100;
            }

        }

    }
}
