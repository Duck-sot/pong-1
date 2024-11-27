using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong_1
{
    public class Paddel
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 3;
        private Keys Up;
        private Keys down;
        public Paddel(Texture2D  t){
            texture = t;
        }
        public void update(){
            KeyboardState Kstate = Keyboard.GetState();
            if(Kstate.IsKeyDown(key: Up)){

            }
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.HotPink);
        }
    }
}