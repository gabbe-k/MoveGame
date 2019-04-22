using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MoveGame
{
    /// <summary>
    /// A game where you dodge enemies
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetCursorPosition(1, 1);

            bool gameEnd = false;
            Map map = new Map(20, 50, 1,  1);
            Player player = new Player(map);

            int tickCount = 0;
            int gameSpeed = 150;
            int fakeSpeed = 20;

            DateTime timeBegin = DateTime.Now;
            map.PrintMap();

            ConsoleKey command = new ConsoleKey();

            do
            {

                if (Console.KeyAvailable) command = Console.ReadKey().Key;

                //Collision detection
                map.EnemyBulletCol();

                if (map.WallCol(player) || map.EnemyCol(player))
                {
                    gameEnd = true;
                }

                //Handle inputs
                player.MovePlayer(command);

                //Print dynamic objects
                player.PrintPlayer();
                map.PrintEnemies();
                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                map.PrintBullet(player, command);


                Thread.Sleep(gameSpeed);

                string speedMsg = "Speed: " + fakeSpeed;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(map.MapWidth - speedMsg.Length, map.MapHeight);
                Console.WriteLine(speedMsg);

                tickCount++;

                if (tickCount == 25)
                {
                    tickCount = 0;
                    if (gameSpeed >= 40)
                    {
                        gameSpeed -= 5;
                        fakeSpeed += 10;
                    }

                    map.LimitVal += 5;
                }

            } while (!gameEnd);

            DateTime timeDead = DateTime.Now;

            var secAliveDbl = (timeDead - timeBegin).TotalSeconds;
            int secAlive = Convert.ToInt32(secAliveDbl);

            Console.Clear();
            Console.WriteLine("You survived for " + secAlive + " seconds. Pay me 5 dollar and i give you 5 second ok thanks");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("__   __                             _    _ _ _ ");
            Console.WriteLine("\\ \\ / /                            | |  (_) | |");
            Console.WriteLine(" \\ V /___  _   _    __ _ _ __ ___  | | ___| | |");
            Console.WriteLine("  \\ // _ \\| | | |  / _` | '__/ _ \\ | |/ / | | |");
            Console.WriteLine("  | | (_) | |_| | | (_| | | |  __/ |   <| | | |");
            Console.WriteLine("  \\_/\\___/ \\__,_|  \\__,_|_|  \\___| |_|\\_\\_|_|_|");

            Console.ReadLine();



        }
    }
}
