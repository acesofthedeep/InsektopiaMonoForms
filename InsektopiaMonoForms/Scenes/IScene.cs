using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace InsektopiaMonoForms.Scenes;

public interface IScene
{
    void LoadContent(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager);
    void Update(GameTime gameTime);

    void Draw(GameTime gameTime);
}