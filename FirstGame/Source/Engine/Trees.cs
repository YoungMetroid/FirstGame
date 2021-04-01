using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame.Source.Engine
{
 
    public class Trees
    {
        public List<Basic2D> tileList;
        public List<List<Basic2D>> tileMap;


        Basic2D middleTreeTrunk;
        Basic2D bottomTreeTrunk;
        Basic2D topTreeTrunk;
        Basic2D topTreeTrunk2;

        int xPosition;
        int yPosition;

        public float scale;

        const int TILEWIDTH = 16;
        const int TILEWIDTH2 = 20;
        const int WIDTHDIFFERENCE = 2;
        const int TILEHEIGHT = 16;

        int[,] mapSetup =
        {
            {0,0,0,0,0,4,0,0,0,0},
            {0,3,0,0,0,1,0,0,0,4},
            {0,1,0,0,0,1,0,0,0,1},
            {0,2,0,0,0,2,0,0,0,2},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
        };

        public Trees(float scale, Vector2 camaraPosition)
        {
            tileMap = new List<List<Basic2D>>();
            this.scale = scale;

            xPosition = 0;
            yPosition = TILEHEIGHT * (int)scale;

            middleTreeTrunk = new Basic2D("2d\\TreeTrunkMiddle", new Vector2(), new Vector2(16 * scale, 16 * scale),true);
            bottomTreeTrunk = new Basic2D("2d\\TreeTrunkBottom", new Vector2(), new Vector2(20 * scale, 16 * scale),true);
            topTreeTrunk = new Basic2D("2d\\TreeTrunkTop1", new Vector2(), new Vector2(16 * scale, 16 * scale),true);
            topTreeTrunk2 = new Basic2D("2d\\TreeTrunkTop2", new Vector2(), new Vector2(24 * scale, 16 * scale), true);
            LoadMap();
        }

        private void LoadMap()
        {
            for (int row = 0; row <= mapSetup.GetUpperBound(0); row++)
            {
                tileList = new List<Basic2D>();
                for (int column = 0; column <= mapSetup.GetUpperBound(1); column++)
                {
                    switch (mapSetup[row, column])
                    {
                        case 1:
                            Basic2D middleTreeTrunkCopy = (Basic2D)middleTreeTrunk.Clone();
                            middleTreeTrunkCopy.position.X = xPosition * scale;
                            middleTreeTrunkCopy.position.Y = yPosition * scale;
                            tileList.Add(middleTreeTrunkCopy);
                            break;
                        case 2:
                            Basic2D bottomTreeTrunkCopy = (Basic2D)bottomTreeTrunk.Clone();
                            bottomTreeTrunkCopy.position.X = (xPosition - WIDTHDIFFERENCE) * scale;
                            bottomTreeTrunkCopy.position.Y = yPosition * scale;
                            tileList.Add(bottomTreeTrunkCopy);
                            break;
                        case 3:
                            Basic2D topTreeTrunkCopy = (Basic2D)topTreeTrunk.Clone();
                            topTreeTrunkCopy.position.X = xPosition  * scale;
                            topTreeTrunkCopy.position.Y = yPosition * scale;
                            tileList.Add(topTreeTrunkCopy);
                            break;
                        case 4: Basic2D topTreeTrunk2Copy = (Basic2D)topTreeTrunk2.Clone();
                            topTreeTrunk2Copy.position.X = (xPosition - 4)* scale;
                            topTreeTrunk2Copy.position.Y = yPosition * scale;
                            tileList.Add(topTreeTrunk2Copy);
                            break;

                    }
                    xPosition = xPosition + TILEWIDTH;
                }
                yPosition = yPosition + TILEHEIGHT;
                xPosition = 0;
                tileMap.Add(tileList);
            }
        }
        public void Draw()
        {
            foreach (List<Basic2D> tileList in tileMap)
            {
                foreach (Basic2D tile in tileList)
                {
                    tile.Draw();
                }
            }
        }
    }
}
