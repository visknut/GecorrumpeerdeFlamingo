using GecorrumpeerdeFlamingo.Constants;

namespace GecorrumpeerdeFlamingo.Entities;

public class Button : Component
{
    public Color Color { get; set; }

    public Button(Color color)
    {
        Color = color;
    }
}