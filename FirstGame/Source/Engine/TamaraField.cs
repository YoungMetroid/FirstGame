using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame.Source.Engine
{
    public class TamaraField
    {

        public List<Basic2D> tileList;
        public List<List<Basic2D>> tileMap;

        Basic2D grassPatch;
        Basic2D topLeftGrassPatch;
        Basic2D topRightGrassPatch;
        Basic2D bottomlLeftGrassPatch;
        Basic2D bottomRightGrassPatch;
        public Trees trees;
        public Houses house;

        int xPosition;
        int yPosition;
        public float scale;
        const int TILEWIDTH = 16;
        const int TILEHEIGHT = 16;
        
        int [,]mapSetup = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,3,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,7,9,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

        public TamaraField(float scale,Vector2 camaraPosition)
        {
            tileMap = new List<List<Basic2D>>();
            this.scale = scale;
            xPosition = 0;
            yPosition = 0;

            grassPatch = new Basic2D("2d\\GrassPatch", new Vector2(), new Vector2(16 * scale, 16 * scale),true);
            topLeftGrassPatch = new Basic2D("2d\\TopLeftGrassPatch", new Vector2(), new Vector2(16 * scale, 16 * scale),true);
            topRightGrassPatch = new Basic2D("2d\\TopRightGrassPatch", new Vector2(), new Vector2(16 * scale, 16 * scale));
            bottomlLeftGrassPatch = new Basic2D("2d\\BottomLeftGrassPatch", new Vector2(), new Vector2(16 * scale, 16 * scale));
            bottomRightGrassPatch = new Basic2D("2d\\BottomRightGrassPatch", new Vector2(), new Vector2(16 * scale, 16 * scale));

            
            LoadMap();
            CalculateCollidableTiles();
            trees = new Trees(3.5f, new Vector2());
            house = new Houses(3.5f, new Vector2(200,100));
            //Basic2D topmiddleTile = new Basic2D("2d\\TopMiddleGrassPatch", new Vector2(16 * scale, 0), new Vector2(16 * scale, 16 * scale));

            //Basic2D leftmiddleTile = new Basic2D("2d\\LeftMiddleGrassPatch", new Vector2(0 * scale, 16 * scale), new Vector2(16 * scale, 16 * scale));
            //Basic2D middleTile = new Basic2D("2d\\MiddleGrassPatch", new Vector2(16 * scale, 16 * scale), new Vector2(16 * scale, 16 * scale));
            //Basic2D rightmiddleTile = new Basic2D("2d\\RightMiddleGrassPatch", new Vector2(32 * scale, 16 * scale), new Vector2(16 * scale, 16 * scale));

            //Basic2D bottommiddleTile = new Basic2D("2d\\BottomMiddleGrassPatch", new Vector2(16 * scale, 32 * scale), new Vector2(16 * scale, 16 * scale));



            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
            //yPosition = yPosition + TILEHEIGHT;
            //LoadGrassPatch();
        }
       
        private void LoadMap()
        {
            Console.WriteLine(mapSetup.GetUpperBound(0));
            Console.WriteLine(mapSetup.GetUpperBound(1));
            
            for(int row = 0; row <= mapSetup.GetUpperBound(0); row++)
            {
                tileList = new List<Basic2D>();
                for (int column = 0; column <= mapSetup.GetUpperBound(1);column++)
                {
                    switch(mapSetup[row,column])
                    {
                        case 0:
                            Basic2D grassPatchCopy = (Basic2D)grassPatch.Clone();
                            grassPatchCopy.position.X = xPosition * scale;
                            grassPatchCopy.position.Y = yPosition * scale;

                            tileList.Add(grassPatchCopy);
                            break;
                        case 1:
                            Basic2D topLeftGrassPatchCopy = (Basic2D)topLeftGrassPatch.Clone();
                            topLeftGrassPatchCopy.position.X = xPosition * scale;
                            topLeftGrassPatchCopy.position.Y = yPosition * scale;
                            tileList.Add(topLeftGrassPatchCopy);
                            break;
                        case 2:
                            break;
                        case 3:
                            Basic2D topRightGrassPatchCopy = (Basic2D)topRightGrassPatch.Clone();
                            topRightGrassPatchCopy.position.X = xPosition * scale;
                            topRightGrassPatchCopy.position.Y = yPosition * scale;
                            tileList.Add(topRightGrassPatchCopy);
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            Basic2D bottomlLeftGrassPatchCopy = (Basic2D)bottomlLeftGrassPatch.Clone();
                            bottomlLeftGrassPatchCopy.position.X = xPosition * scale;
                            bottomlLeftGrassPatchCopy.position.Y = yPosition * scale;
                            tileList.Add(bottomlLeftGrassPatchCopy);
                            break;
                        case 8:
                            break;
                        case 9:
                            Basic2D bottomRightGrassPatchCopy = (Basic2D)bottomRightGrassPatch.Clone();
                            bottomRightGrassPatchCopy.position.X = xPosition * scale;
                            bottomRightGrassPatchCopy.position.Y = yPosition * scale;
                            tileList.Add(bottomRightGrassPatchCopy);
                            break;
                        default:
                            Basic2D defaultCopy = (Basic2D)grassPatch.Clone();
                            defaultCopy.position.X = xPosition * scale;
                            defaultCopy.position.Y = yPosition * scale;
                            tileList.Add(defaultCopy);
                            break;
                    }
                    xPosition = xPosition + TILEWIDTH;
                }
                yPosition = yPosition + TILEHEIGHT;
                xPosition = 0;
                tileMap.Add(tileList);
            }
        }
        private void CalculateCollidableTiles()
        {
            List<TileAttributes> collidableTiles = tileMap.SelectMany(x => x.Where(y => y.collidable == true))
                .Select(attributes =>
                new TileAttributes
                {
                    position = attributes.position,
                    dimensiones = attributes.dimensiones
                }).ToList(); 

        }
        private void LoadGrassPatch()
        {
            tileList = new List<Basic2D>();
            xPosition = 0;
            for(int column = 0; column < 20; column++)
            {
                tileList.Add(new Basic2D("2d\\GrassPatch", new Vector2(xPosition*scale, yPosition * scale), new Vector2(TILEWIDTH*scale,TILEHEIGHT*scale)));
                xPosition = xPosition + TILEWIDTH;
            }
            tileMap.Add(tileList);
        }
        private void LoadSecondRow()
        {
            
        }

        public void Update(Vector2 camaraPosition)
        {
            if(tileList != null)
            {
                foreach(Basic2D tile in tileList)
                {
                    tile.position.X = tile.position.X + camaraPosition.X;
                    tile.position.Y = tile.position.Y + camaraPosition.Y;
                }
            }
        }
        public void Draw()
        {
            foreach(List<Basic2D> tileList in tileMap)
            {
                foreach (Basic2D tile in tileList)
                {
                    tile.Draw();
                }
            }
            trees.Draw();
            house.Draw();
        }
    }
}
