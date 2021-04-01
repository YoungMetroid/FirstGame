using FirstGame.Source.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame.Source
{
    public class World
    {

        public Basic2D hero;
        public List<Basic2D> tiles;
        public TamaraField field;

        public World()
        {
            //hero = new Basic2D("2d\\Blue Sword", new Vector2(300, 300), new Vector2(64, 96));
            field = new TamaraField(3.5f, new Vector2());
            List<Basic2D> collisionList = field.tileMap.SelectMany(x => x.Where(y => y.collidable = true)).ToList();
             
        }

        public virtual void Update()
        {
            field.Update(new Vector2());

        }
        public virtual void Draw()
        {
            field.Draw();
        }
    }
}
