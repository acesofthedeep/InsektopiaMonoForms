using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace InsektopiaMonoForms.Tools;

public abstract class DynamicPanel : IDrawable
{
    public DynamicPanel(int maxCount, Vector2 position, int margin) : this(new List<GameObject>(), maxCount, position,
        margin)
    {
    }

    public DynamicPanel(List<GameObject> gameObjects, int maxCount, Vector2 postion, int margin)
    {
        GameObjects = gameObjects;
        MaxCount = maxCount;
        InitialPosition = Position = postion;
        Margin = margin;
    }


    protected List<GameObject> GameObjects { get; set; }
    private int MaxCount { get; set; }
    protected Vector2 Position { get; set; }
    protected int Margin { get; set; }
    protected Vector2 InitialPosition { get; set; }

    public void Draw(GameTime gameTime)
    {
        GameObjects.ForEach(gameObj => gameObj.Draw(gameTime));
    }

    public event EventHandler MaxCountExceeded;

    public void AddRight(GameObject gameObject)
    {
        GameObjects.Add(gameObject);
        TryMaxCoundExceeded();
        Adjust();
    }

    protected abstract void Adjust();

    private void TryMaxCoundExceeded()
    {
        if (GameObjects.Count > MaxCount)
        {
            MaxCountExceeded?.Invoke(this, EventArgs.Empty);
        }
    }

    public void AddLeft(GameObject gameObject)
    {
        GameObjects.Insert(0, gameObject);
        TryMaxCoundExceeded();
        Adjust();
    }

    public void AddMiddle(GameObject gameObject)
    {
        int positionToInsert = GameObjects.Count / 2;
        GameObjects.Insert(positionToInsert, gameObject);
        TryMaxCoundExceeded();
        Adjust();
    }
}