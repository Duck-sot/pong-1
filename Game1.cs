using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using pong_1;
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
    
    ball ball; 
    

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

        ball = new ball(t: pixel);
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

            
            ball.update();
            
            
            if(ball.Rectangle.X <= 0 ){
                ball.Reset();
                scoreRp++;
            }
            else if(ball.Rectangle.X + ball.Rectangle.Width>= 800){
                ball.Reset();
                scoreLp++;
            }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontscore,scoreLp.ToString(),new Vector2(x: 70, y :10), Color.Black);
        _spriteBatch.DrawString(fontscore,scoreRp.ToString(),new Vector2(x: 670, y :10), Color.Black);

        _spriteBatch.Draw(pixel,paddelLeft, Color.HotPink);
        _spriteBatch.Draw(pixel,paddelRight, Color.BlueViolet);
        ball.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
