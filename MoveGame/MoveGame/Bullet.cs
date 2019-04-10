using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGame
{
    /// <summary>
    /// Bullet class, handling position, rendering of a singular bullet
    /// </summary>
    class Bullet
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        private int MapWidth { get; }
        private int MapHeight { get; }

        public Bullet(int playerX, int playerY)
        {
            Xpos = playerX;
            Ypos = playerY;
        }


        /// <summary>
        /// Prints bullet
        /// </summary>
        public void PrintBullet()
        {
            if (Xpos == 1)
            {
                Console.SetCursorPosition(Xpos + 1,Ypos);
                Console.WriteLine(' ');
                Xpos = -1;
                Ypos = -1;
            }
            else
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(">");
                Console.SetCursorPosition(Xpos-1, Ypos);
                Console.WriteLine(' ');
                Xpos++;
            }
        }
    }
}
