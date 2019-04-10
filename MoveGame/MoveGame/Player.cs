using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoveGame
{   
    /// <summary>
    /// Contains functions for printing the player, input, and position of the player
    /// </summary>
    class Player
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Player(Map map)
        {
            XPos = map.MapWidth/2;
            YPos = map.MapHeight/2;
        }

        /// <summary>
        /// Prints player
        /// </summary>
        public void PrintPlayer()
        {
            Console.SetCursorPosition(XPos, YPos);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine((char)214);
        }




        /// <summary>
        /// Moves the player
        /// </summary>
        /// <param name="command">Contains current player input</param>
        public void MovePlayer(ConsoleKey command)
        {
            switch (command)
            {
                case ConsoleKey.A:
                    Console.SetCursorPosition(XPos, YPos);
                    Console.Write(" ");
                    XPos--;
                    break;
                case ConsoleKey.W:
                    Console.SetCursorPosition(XPos, YPos);
                    Console.Write(" ");
                    YPos--;
                    break;
                case ConsoleKey.S:
                    Console.SetCursorPosition(XPos, YPos);
                    Console.Write(" ");
                    YPos++;
                    break;
                case ConsoleKey.D:
                    Console.SetCursorPosition(XPos, YPos);
                    Console.Write(" ");
                    XPos++;
                    break;
            }
        }

    }
}
