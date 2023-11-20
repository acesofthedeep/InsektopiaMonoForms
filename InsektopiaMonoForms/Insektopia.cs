using InsektopiaMonoForms.Network;
using InsektopiaMonoForms.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InsektopiaMonoForms;

public class Insektopia : Game
{
    public static int ScreenWidth;
    public static int ScreenHeight;
    private GameScene _currentScene;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Insektopia()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        ScreenWidth = 1920;
        ScreenHeight = 1080;
    }

    protected override void Initialize()
    {
        ClientTcpListener clientTcpListener = new ClientTcpListener();
        GameState gameState = new GameState();
        Player localPlayer = new Player();
        Player remotePlayer = new Player();

        GameScene gameScene = new GameScene(gameState, localPlayer, remotePlayer, clientTcpListener);
        _currentScene = gameScene;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _currentScene.LoadContent(Content, _graphics, _spriteBatch);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _currentScene.Draw(gameTime);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}