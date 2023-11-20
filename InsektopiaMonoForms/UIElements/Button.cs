using InsektopiaMonoForms.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InsektopiaMonoForms.UIElements;

public class Button : GameObject
{
    public Button(Texture2D texture2D, Vector2 position, SpriteBatch spriteBatch, GraphicsDeviceManager graphics,
        int width, int height, SpriteFont spriteFont, string text) : base(texture2D, position, spriteBatch, graphics,
        width, height)
    {
        SpriteFont = spriteFont;
        Text = text;
    }

    private SpriteFont SpriteFont { get; }
    private string Text { get; }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.DrawString(SpriteFont, Text, Postion + new Vector2(10, 10), Color.Black);
        base.Draw(gameTime);
    }
}