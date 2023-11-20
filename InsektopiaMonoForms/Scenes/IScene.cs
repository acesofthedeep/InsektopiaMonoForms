using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = InsektopiaMonoForms.Tools.IDrawable;

namespace InsektopiaMonoForms.Scenes;

public interface IScene : IDrawable
{
    void LoadContent(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager,
        SpriteBatch spriteBatch);

    void Update(GameTime gameTime);
}