using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.X3DAudio;

namespace pong_1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont fontscore;
    Rectangle paddelLeft = new Rectangle(x: 10,y: 200, width: 20 , height: 100);
    Rectangle paddelRight = new Rectangle(x: 770,y: 200, width: 20 , height: 100);
    Rectangle ball = new Rectangle(x: 390,y: 230, width: 20 , height: 20);

    float Vel1 = 2;
    float Vel2 = 2;

    int scoreRp = 0;
    int scoreLp = 0; 
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>(assetName: "pixel");
        fontscore = Content.Load<SpriteFont>(assetName:"score");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.W) && paddelLeft.Y >= 0){
                paddelLeft.Y-= 3;
            }
            if(kstate.IsKeyDown(Keys.S) && paddelLeft.Y + paddelLeft.Height <= 480){
                paddelLeft.Y+=3;
            }
            if(kstate.IsKeyDown(Keys.Up) && paddelRight.Y + paddelLeft.Height >= 0){
                paddelRight.Y-=3;
            }
            if(kstate.IsKeyDown(Keys.Down) && paddelRight.Y + paddelLeft.Height <= 480){
                paddelRight.Y+=3;
            }

            ball.Y += (int)Vel2;            
            ball.X += (int)Vel1;
            if (ball.Intersects(paddelRight) || ball.Intersects(paddelLeft)){
                Vel1 *= -1.1f;
                Vel2 *= 1.1f; 
            }

            if(ball.Y <= 0 || ball.Y >=460){
                Vel2 *= -1.001f;
            }
            if(ball.X <= 0  || ball.X + ball.Width>= 800){
                ball.X =390;
                ball.Y = 230;
                Vel1 = 2; 
                Vel2 = 2;
            }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontscore,scoreLp.ToString(),new Vector2(x: 10, y :10), Color.Black);
        _spriteBatch.DrawString(fontscore,scoreRp.ToString(),new Vector2(x: 410, y :10), Color.Black);

        _spriteBatch.Draw(pixel,paddelLeft, Color.HotPink);
        _spriteBatch.Draw(pixel,paddelRight, Color.BlueViolet);
        _spriteBatch.Draw(pixel,ball, Color.LightGoldenrodYellow);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
