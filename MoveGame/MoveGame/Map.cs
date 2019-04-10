using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGame
{   
    /// <summary>
    /// Handles collisions and the printing of the map
    /// </summary>
    class Map
    {
        private int[,] MapArr { get; }
        public int MapHeight { get; }
        public int MapWidth { get;  }
        public List<Enemy> EnemyList = new List<Enemy>();
        public List<Bullet> BulletList = new List<Bullet>();
        public int LimitVal { get; set; }
        public int BulletLimit { get; set; }

        public Map(int mapHeight, int mapWidth, int limitVal, int bulletLimit)
        {
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            MapArr = new int[mapWidth,mapHeight];
            this.LimitVal = limitVal;
            this.BulletLimit = bulletLimit;
        }




        /// <summary>
        /// Prints map
        /// </summary>
        public void PrintMap()
        {
            int row = MapArr.GetLength(0);
            int col = MapArr.GetLength(1);

            for (int i = 1; i < col; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(row-1, i);
                Console.Write("#");
            }
            for (int i = 1; i < row; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, col-1);
                Console.Write("#");
            }
        }



        /// <summary>
        /// Checks if the player has collided with a wall
        /// </summary>
        /// <param name="player">The current player, including the position</param>
        /// <returns>Bool representing if the player collided</returns>
        public bool WallCol(Player player)
        {
            if (player.XPos == 1 || player.XPos == MapWidth - 1 || player.YPos == 1 || player.YPos == MapHeight - 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the player has collided with an enemy
        /// </summary>
        /// <param name="player">Player, including position</param>
        /// <returns>Bool representing if the player has collided</returns>
        public bool EnemyCol(Player player)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {

                if (EnemyList[i].pointList.Count > 0 && player.YPos == EnemyList[i].pointList.Last().Ypos)
                {

                    for (int j = 0; j < EnemyList[i].pointList.Count; j++)
                    {
                        if (player.XPos == EnemyList[i].pointList[j].Xpos)
                        {
                            Console.WriteLine(player.XPos);
                            Console.WriteLine(EnemyList[i].pointList[j].Xpos);
                            return true;
                        }
                    }
                }
            }

            return false;
        }



        /// <summary>
        /// Checks if enemies have collided with a bullet
        /// </summary>
        public void EnemyBulletCol()
        {
            if (EnemyList.Count != 0 && BulletList.Count != 0)
            {
                int numBullet = BulletList.Count;

                for (int i = 0; i < numBullet; i++)
                {
                    if (numBullet == 0 || i >= numBullet)
                    {
                        break;
                    }

                    int numEnem = EnemyList.Count;

                    for (int j = 0; j < numEnem; j++)
                    {
                        if (numBullet == 0 || numEnem == 0 || i >= BulletList.Count || j >= EnemyList.Count)
                        {
                            break;
                        }

                        if (EnemyList[j].pointList.Count > 0 &&
                            BulletList[i].Ypos == EnemyList[j].pointList.Last().Ypos)
                        {
                            int numEnemPoints = EnemyList[j].pointList.Count;

                            for (int k = 0; k < numEnemPoints; k++)
                            {
                                if (BulletList.Count == 0 || EnemyList.Count == 0 ||
                                    EnemyList[j].pointList.Count == 0
                                    || i >= BulletList.Count || j >= EnemyList.Count ||
                                    k >= EnemyList[j].pointList.Count)
                                {
                                    break;
                                }

                                numBullet = BulletList.Count;
                                numEnem = EnemyList.Count;
                                numEnemPoints = EnemyList[j].pointList.Count;

                                if (EnemyList[j].pointList[k].Xpos == BulletList[i].Xpos)
                                {
                                    Console.SetCursorPosition(BulletList[i].Xpos, BulletList[i].Ypos);
                                    Console.WriteLine(" ");
                                    EnemyList[j].pointList.Remove(EnemyList[j].pointList[k]);
                                }
                            }
                        }

                    }

                }
            }

        }


        /// <summary>
        /// Prints and generates all enemies
        /// </summary>
        public void PrintEnemies()
        {
            Random rnd = new Random();

            int numEnemies = rnd.Next(1, 4);

            if (EnemyList.Count < LimitVal)
            {
                for (int k = 0; k < numEnemies; k++)
                {
                    Enemy tmpEnemy = new Enemy(MapWidth, MapHeight);
                    tmpEnemy.GenEnemy();
                    EnemyList.Add(tmpEnemy);
                }
            }



            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].pointList.Count == 0)
                {
                    EnemyList.Remove(EnemyList[i]);
                }
                else 
                {
                    EnemyList[i].PrintEnemy();
                }
            }


        }



        /// <summary>
        /// Prints bullet
        /// </summary>
        /// <param name="player">Contains position of the player</param>
        /// <param name="command">Current command, if it is enter, a bullet will be fired</param>
        public void PrintBullet(Player player, ConsoleKey command)
        {

            if (command == ConsoleKey.Enter)
            {
                if (BulletList.Count < BulletLimit)
                {
                    Bullet fired = new Bullet(player.XPos, player.YPos);
                    Bullet fired2 = new Bullet(player.XPos+1, player.YPos);
                    BulletList.Add(fired);
                    BulletList.Add(fired2);
                }
            }

            for (int i = 0; i < BulletList.Count; i++)
            {
                if (BulletList[i].Xpos == -1 || BulletList[i].Xpos > MapWidth-2)
                {
                    Console.SetCursorPosition(BulletList[i].Xpos-1, BulletList[i].Ypos);
                    Console.WriteLine(" ");
                    BulletList.Remove(BulletList[i]);
                }
                else
                {
                    BulletList[i].PrintBullet();
                }
            }

        }

    }
}
