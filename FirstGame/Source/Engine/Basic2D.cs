using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame.Source.Engine
{
    public class Basic2D:ICloneable
    {

        public Vector2 position, dimensiones;

        public Texture2D model;

        public bool collidable;
        public Basic2D(string Path, Vector2 position, Vector2 dimensiones,bool collidable)
        {
            this.position = position;
            this.dimensiones = dimensiones;
            this.collidable = collidable;
            model = Globals.content.Load<Texture2D>(Path);
        }
        public Basic2D(string Path, Vector2 position, Vector2 dimensiones)
        {
            this.position = position;
            this.dimensiones = dimensiones;
            this.collidable = false;
            model = Globals.content.Load<Texture2D>(Path);
        }

        public virtual void Update()
        {

        }
        public virtual void Draw()
        {
            if(model != null)
            {
                Globals.spriteBatch.Draw(
                    model, 
                    new Rectangle
                    (
                        (int)(position.X), (int)(position.Y), 
                        (int)(dimensiones.X), (int)(dimensiones.Y)
                    ),
                    null, Color.White, 0.0f,
                    new Vector2(0, 0), new SpriteEffects(), 0);
            }

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
