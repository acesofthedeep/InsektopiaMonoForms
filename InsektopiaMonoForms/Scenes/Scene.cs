using InsektopiaMonoForms.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InsektopiaMonoForms.Scenes;

public abstract class Scene : IScene
{
    private readonly ClientTcpListener _clientTcpListener;
    private readonly Player _localPlayer;
    private readonly Player _remotePlayer;

    protected Scene(ClientTcpListener clientTcpListener, GameState currentGameState, Player localPlayer,
        Player remotePlayer)
    {
        _clientTcpListener = clientTcpListener;
        _localPlayer = localPlayer;
        _remotePlayer = remotePlayer;
        CurrentGameState = currentGameState;
    }

    public SpriteBatch SpriteBatch { get; set; }

    protected ContentManager Content { get; set; }
    protected GraphicsDeviceManager Graphics { get; set; }
    protected GameState CurrentGameState { get; set; }


    public virtual void LoadContent(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager,
        SpriteBatch spriteBatch)
    {
        Content = contentManager;
        Graphics = graphicsDeviceManager;
        SpriteBatch = spriteBatch;
    }

    public virtual void Update(GameTime gameTime)
    {
        //TODO: Implement GameStateUpdate
    }

    public abstract void Draw(GameTime gameTime);
}