using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace InsektopiaMonoForms.Tools.Panel;

public class VerticalDynamicPanel : DynamicPanel
{
    public VerticalDynamicPanel(int maxCount, Vector2 position, int margin) : base(maxCount, position, margin)
    {
    }

    public VerticalDynamicPanel(List<GameObject> gameObjects, int maxCount, Vector2 postion, int margin) : base(
        gameObjects, maxCount, postion, margin)
    {
    }

    protected override void Adjust()
    {
        int totalSize = GameObjects.Sum(obj => obj.Height) + GameObjects.Count * Margin;
        Position = new Vector2(InitialPosition.X, InitialPosition.Y - totalSize / 2);

        int currentX = (int)Position.X;
        int currentY = (int)Position.Y;
        GameObjects.ForEach(gameObj =>
        {
            gameObj.Postion = new Vector2(currentX, currentY);
            currentY += gameObj.Height + Margin;
            currentX = (int)gameObj.Postion.X;
        });
    }
}