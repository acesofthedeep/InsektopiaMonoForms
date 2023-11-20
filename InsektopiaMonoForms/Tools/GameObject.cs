using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InsektopiaMonoForms.Tools;

public class GameObject : IDrawable
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly Texture2D _texture2D;

    public GameObject(Texture2D texture2D, Vector2 position, SpriteBatch spriteBatch, GraphicsDeviceManager graphics,
        int width, int height)
    {
        _texture2D = texture2D;
        Postion = position;
        Width = width;
        Height = height;
        SpriteBatch = spriteBatch;
        _graphics = graphics;
    }


    protected SpriteBatch SpriteBatch { get; private set; }
    public Vector2 Postion { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public bool IsAlive { get; set; } = true;

    public virtual void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(_texture2D,
            new Rectangle((int)Postion.X, (int)Postion.Y, Width, Height), Color.White);
    }

    public void Destroy()
    {
        IsAlive = false;
    }
}