using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong_1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    Rectangle paddelLeft = new Rectangle(x: 10,y: 200, width: 20 , height: 100);
    Rectangle paddelRight = new Rectangle(x: 770,y: 200, width: 20 , height: 100);
    Rectangle ball = new Rectangle(x: 390,y: 230, width: 20 , height: 20);
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
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.W)){
                paddelLeft.Y-= 3;
            }
            if(kstate.IsKeyDown(Keys.S)){
                paddelLeft.Y+=3;
            }
            if(kstate.IsKeyDown(Keys.Up)){
                paddelRight.Y-=3;
            }
            if(kstate.IsKeyDown(Keys.Down)){
                paddelRight.Y+=3;
            }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel,paddelLeft, Color.HotPink);
        _spriteBatch.Draw(pixel,paddelRight, Color.BlueViolet);
        _spriteBatch.Draw(pixel,ball, Color.LightGoldenrodYellow);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
