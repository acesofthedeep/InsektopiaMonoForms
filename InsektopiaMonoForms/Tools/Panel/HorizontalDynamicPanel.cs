using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace InsektopiaMonoForms.Tools.Panel;

public class HorizontalDynamicPanel : DynamicPanel
{
    public HorizontalDynamicPanel(int maxCount, Vector2 position, int margin) : base(maxCount, position, margin)
    {
    }

    public HorizontalDynamicPanel(List<GameObject> gameObjects, int maxCount, Vector2 postion, int margin) : base(
        gameObjects, maxCount, postion, margin)
    {
    }

    protected override void Adjust()
    {
        int totalSize = GameObjects.Sum(obj => obj.Width) + GameObjects.Count * Margin;
        Position = new Vector2(InitialPosition.X - totalSize / 2, InitialPosition.Y);

        int currentX = (int)Position.X;
        int currentY = (int)Position.Y;
        GameObjects.ForEach(gameObj =>
        {
            gameObj.Postion = new Vector2(currentX, currentY);
            currentX += gameObj.Width + Margin;
            currentY = (int)gameObj.Postion.Y;
        });
    }
}