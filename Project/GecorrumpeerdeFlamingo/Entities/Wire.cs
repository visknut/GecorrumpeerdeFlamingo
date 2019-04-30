using System;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class Wire : Component
    {
        public string Color { get; set; }

        public Wire(string color)
        {
            Color = color;
        }

        public override string ToString()
        {
            if (Active)
            {
                return $"Een {Color} draad.";
            }
            else
            {
                return $"Een doorgeknipte {Color} draad.";
            }
            
        }
    }
}
