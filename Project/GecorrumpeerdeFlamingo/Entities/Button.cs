using System;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class Button : Component
    {
        public string Color { get; set; }

        public Button(string color)
        {
            Color = color;
        }

        public override string ToString()
        {
            if (Active)
            {
                return $"Een {Color} knop.";
            }
            else
            {
                return $"Een ingedrukte {Color} knop.";
            }

        }
    }
}
