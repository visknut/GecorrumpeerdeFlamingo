using System;
using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class Bomb
    {
        public string Color { get; set; }
        public List<Component> Components { get; set; }
        public Queue<string> Display { get; set; }
        public Timer Timer { get; set; }
        public List<string> ObservationsOnInspect { get; set; }
        public Stack<Command> AcceptedInput { get; set; }

        override public string ToString()
        {
            var description = "";

            description += $"{Timer.ToString()}\n";

            description += $"De display laat de volgende code zien: {Display.Peek()}\n";

            description += $"\nDe volgende componenten zijn aanwezig op de bom:\n";

            foreach (var component in Components)
            {
                description += $"- {component.ToString()}\n";
            }
            return description;
        }

        public string AnalyzeBomb()
        {
            var description = "Analyse bom:\n";

            foreach (var observation in ObservationsOnInspect)
            {
                description += $"- {observation.ToString()}\n";
            }
            return description;
        }
    }
}
