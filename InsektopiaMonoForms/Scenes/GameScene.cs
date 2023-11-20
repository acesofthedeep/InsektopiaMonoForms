using InsektopiaMonoForms.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InsektopiaMonoForms.Scenes;

public class GameScene : Scene
{
    private readonly Player _localPlayer;
    private readonly Player _remotePlayer;
    private Texture2D _backgroundTexture;

    public GameScene(GameState gameState, Player localPlayer, Player remotePlayer, ClientTcpListener clientTcpListener)
        : base(clientTcpListener, gameState,localPlayer,remotePlayer)
    {
        _localPlayer = localPlayer;
        _remotePlayer = remotePlayer;
    }

    public override void LoadContent(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager)
    {
        base.LoadContent(contentManager, graphicsDeviceManager);
        _backgroundTexture = Content.Load<Texture2D>("Default");
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(_backgroundTexture,
            new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight), Color.White);
    }
}