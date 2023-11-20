using InsektopiaMonoForms.Network;
using InsektopiaMonoForms.Tools;
using InsektopiaMonoForms.Tools.Panel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InsektopiaMonoForms.Scenes;

public class GameScene : Scene
{
    private readonly Player _localPlayer;
    private readonly Player _remotePlayer;
    private Texture2D _backgroundTexture;
    private DynamicPanel _localHand;
    private DynamicPanel _opponentHand;

    public GameScene(GameState gameState, Player localPlayer, Player remotePlayer, ClientTcpListener clientTcpListener)
        : base(clientTcpListener, gameState, localPlayer, remotePlayer)
    {
        _localPlayer = localPlayer;
        _remotePlayer = remotePlayer;
    }

    public override void LoadContent(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager,
        SpriteBatch spriteBatch)
    {
        base.LoadContent(contentManager, graphicsDeviceManager, spriteBatch);
        _backgroundTexture = Content.Load<Texture2D>("Default");

        InitOpponentHand(spriteBatch);
        InitLocalHand(spriteBatch);
    }

    private void InitLocalHand(SpriteBatch spriteBatch)
    {
        _localHand = new HorizontalDynamicPanel(7,
            new Vector2(Insektopia.ScreenWidth / 2, Insektopia.ScreenHeight - 180), 10);
        //Replace with GameState 
        GameObject cardX = new GameObject(_backgroundTexture, new Vector2(0, Insektopia.ScreenHeight - 180),
            spriteBatch, Graphics, 90, 180);

        GameObject cardy = new GameObject(_backgroundTexture, new Vector2(0, Insektopia.ScreenHeight - 180),
            spriteBatch, Graphics, 90, 180);

        GameObject cardz = new GameObject(_backgroundTexture, new Vector2(0, Insektopia.ScreenHeight - 180),
            spriteBatch, Graphics, 90, 180);

        _localHand.AddRight(cardX);
        _localHand.AddRight(cardy);
        _localHand.AddRight(cardz);
    }

    private void InitOpponentHand(SpriteBatch spriteBatch)
    {
        _opponentHand =
            new HorizontalDynamicPanel(7, new Vector2(Insektopia.ScreenWidth / 2, 0), 10);
        //Replace with GameState 
        GameObject cardX = new GameObject(_backgroundTexture, new Vector2(0, 0),
            spriteBatch, Graphics, 90, 180);

        GameObject cardy = new GameObject(_backgroundTexture, new Vector2(0, 0),
            spriteBatch, Graphics, 90, 180);

        GameObject cardz = new GameObject(_backgroundTexture, new Vector2(0, 0),
            spriteBatch, Graphics, 90, 180);

        _opponentHand.AddRight(cardX);
        _opponentHand.AddRight(cardy);
        _opponentHand.AddRight(cardz);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(_backgroundTexture,
            new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight), Color.White);

        Render(gameTime);
    }

    private void Render(GameTime gameTime)
    {
        _localHand.Draw(gameTime);
        _opponentHand.Draw(gameTime);
    }
}