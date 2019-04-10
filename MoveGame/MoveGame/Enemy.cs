using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoveGame
{
    /// <summary>
    /// Handles the generation, printing and positioning of an enemy
    /// </summary>
    class Enemy
    {
        public List<Point> pointList = new List<Point>();
        private int MapWidth { get; }
        private int MapHeight { get; }

        public Enemy(int MapWidth, int MapHeight)
        {
            this.MapWidth = MapWidth;
            this.MapHeight = MapHeight;
        }

        /// <summary>
        /// Generates positions for the enemy
        /// </summary>
        public void GenEnemy()
        {
            Random rnd = new Random();

            int Xpos = MapWidth - 3;
            int Ypos = rnd.Next(2, MapHeight - 2);

            int rowLen = rnd.Next(1, 4);

            for (int j = 0; j < rowLen; j++)
            {
                pointList.Add(new Point(Xpos + j, Ypos));
            }

        }



        /// <summary>
        /// Prints the enemy
        /// </summary>
        public void PrintEnemy()
        {
            for (int i = 0; i < pointList.Count; i++)
            {
                if (pointList[i].Xpos == 1)
                {
                    Console.SetCursorPosition(pointList[i].Xpos+1, pointList[i].Ypos);
                    Console.WriteLine('x');
                    pointList.Remove(pointList[i]);
                }
                else
                {
                    Console.SetCursorPosition(pointList[i].Xpos, pointList[i].Ypos);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine('X');
                    Console.SetCursorPosition(pointList[pointList.Count - 1].Xpos + 1, pointList[i].Ypos);
                    Console.WriteLine(' ');
                    pointList[i].Xpos--;
                }

            }

        }

    }


    
    internal class Point
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public Point(int Xpos, int Ypos)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
        }
    }
}
