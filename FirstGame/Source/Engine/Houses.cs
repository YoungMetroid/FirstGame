using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame.Source.Engine
{
    public class Houses
    {
        Basic2D house;

        public Houses(float scale, Vector2 camaraPosition)
        {
            house = new Basic2D("2d\\House", camaraPosition, new Vector2(scale * 54, scale * 61),true);

        }

        public void Draw()
        {
            house.Draw();
        }
    }
}
