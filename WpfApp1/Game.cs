using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;

namespace WpfApp1
{
    internal class Game
    {
        public Players CurrentPlayer { get; private set; }
        public void CheckState(Button[,] gameGrid, Label lbldesc)
        {
            int Winner = 0;

            if (CheckX(gameGrid, out Winner) || CheckY(gameGrid, out Winner) || CheckDiags(gameGrid, out Winner) || CheckReverseDiag(gameGrid, out Winner))
            {
                if (Winner == 1 || Winner == 2)
                {
                    if (Winner == 1)
                        lbldesc.Content = $"Player '{Players.X}' Won!";
                    else
                        lbldesc.Content = $"Player '{Players.O}' Won!";

                    DisableGame(gameGrid);
                }
            }
        }
        private void DisableGame(Button[,] gameGrid)
        {
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    gameGrid[x, y].IsEnabled = false;
                }
            }
        }
        private bool CheckX (Button[,] gameGrid, out int Winner)
        {
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                int xCounter = 0;
                int oCounter = 0;

                for (int y = 0;  y < gameGrid.GetLength(1); y++)
                {
                    if (gameGrid[x,y].Content != null)
                    {
                        if (gameGrid[x, y].Content.Equals(Players.X))
                        {
                            xCounter++;
                        }

                        if (gameGrid[x, y].Content.Equals(Players.O))
                        {
                            oCounter++;
                        }
                    }
                }
                if (xCounter == 3)
                {
                    Winner = 1;
                    return true;
                }
                if (oCounter == 3)
                {
                    Winner = 2;
                    return true;
                }
            }

            Winner = 0;
            return false;
        }
        private bool CheckY(Button[,] gameGrid, out int Winner)
        {
            for (int y = 0; y < gameGrid.GetLength(1); y++)
            {
                int xCounter = 0;
                int oCounter = 0;

                for (int x = 0; x < gameGrid.GetLength(0); x++)
                {
                    if (gameGrid[x, y].Content != null)
                    {
                        if (gameGrid[x, y].Content.Equals(Players.X))
                        {
                            xCounter++;
                        }

                        if (gameGrid[x, y].Content.Equals(Players.O))
                        {
                            oCounter++;
                        }
                    }
                }

                if (xCounter == 3)
                {
                    Winner = 1;
                    return true;
                }

                if (oCounter == 3)
                {
                    Winner = 2;
                    return true;
                }

            }
            Winner = 0;
            return false;
        }
        private bool CheckDiags(Button[,] gameGrid, out int Winner)
        {
            if (gameGrid[0, 0].Content != null && gameGrid[1, 1].Content != null && gameGrid[2, 2].Content != null) /*||
                gameGrid[0, 2].Content != null && gameGrid[1, 1].Content != null && gameGrid[2, 0].Content != null)*/
            {
                if (gameGrid[0, 0].Content.Equals(Players.X) && gameGrid[1, 1].Content.Equals(Players.X) && gameGrid[2, 2].Content.Equals(Players.X)) /*||
                    gameGrid[0, 2].Content.Equals(Players.X) && gameGrid[1, 1].Content.Equals(Players.X) && gameGrid[2, 0].Content.Equals(Players.X))*/
                {
                    Winner = 1;
                    return true;
                }
                else if (gameGrid[0, 0].Content.Equals(Players.O) && gameGrid[1, 1].Content.Equals(Players.O) && gameGrid[2, 2].Content.Equals(Players.O)) /*||
                    gameGrid[0, 2].Content.Equals(Players.O) && gameGrid[1, 1].Content.Equals(Players.O) && gameGrid[2, 0].Content.Equals(Players.O))*/
                {
                    Winner = 2;
                    return true;
                }
                else
                {
                    Winner = 0;
                    return false;
                }
            }

            Winner = 0;
            return false;
        }
        private bool CheckReverseDiag(Button[,] gameGrid, out int Winner)
        {
            if (gameGrid[0, 2].Content != null && gameGrid[1, 1].Content != null && gameGrid[2, 0].Content != null)
            {
                if (gameGrid[0, 2].Content.Equals(Players.X) && gameGrid[1, 1].Content.Equals(Players.X) && gameGrid[2, 0].Content.Equals(Players.X))
                {
                    Winner = 1;
                    return true;
                }
                else if (gameGrid[0, 2].Content.Equals(Players.O) && gameGrid[1, 1].Content.Equals(Players.O) && gameGrid[2, 0].Content.Equals(Players.O))
                {
                    Winner = 2;
                    return true;
                }
                else
                {
                    Winner = 0;
                    return false;
                }
            }

            Winner = 0;
            return false;
        }
        public void ClearBoard(Button[,] gameGrid)
        {
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    gameGrid[x,y].Content = null;
                }
            }
        }
        public void SetNext()
        {
            if (CurrentPlayer == Players.X)
            {
                CurrentPlayer = Players.O;
            }
            else
            {
                CurrentPlayer = Players.X;  
            }
        }
    }
}
