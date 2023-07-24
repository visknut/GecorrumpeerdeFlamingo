using GecorrumpeerdeFlamingo.Constants;

namespace GecorrumpeerdeFlamingo.Entities;

public class Wire : Component
{
    public Color Color { get; set; }

    public Wire(Color color)
    {
        Color = color;
    }
}