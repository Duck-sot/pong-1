using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace pong_1
{
    public class ball
    {
        private Texture2D texture;
        private Rectangle rectangle = new Rectangle(x: 390,y: 230, width: 20 , height: 20);

        private float Vel1 = 2;
        private float Vel2 = 2;

        public Rectangle Rectangle{
            get{return rectangle;}
        }

        public ball(Texture2D t){
            texture = t; 
        }

        public void Reset() {
            rectangle.X =390;
            rectangle.Y = 230;
            Vel1 = 2; 
            Vel2 = 2;
            
        }
        public void update(){
            rectangle.Y += (int)Vel2;            
            rectangle.X += (int)Vel1;
        
            if(rectangle.Y <= 0 || rectangle.Y >=460){
                Vel2 *= -1.001f;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.LightGoldenrodYellow);
        }
    }
}