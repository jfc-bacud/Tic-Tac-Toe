using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    internal class Game
    {
        public Players CurrentPlayer { get; private set; }

        public Game()
        {

        }

        public Game(Button[,] gameGrid)
        {

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
