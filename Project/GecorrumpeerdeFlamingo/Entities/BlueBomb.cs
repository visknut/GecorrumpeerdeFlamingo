using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class BlueBomb : Bomb
    {
        public BlueBomb()
        {
            Components = new List<Component>();

            /* Add wires. */
            Components.Add(new Wire("zwarte"));
            Components.Add(new Wire("paarse"));
            Components.Add(new Wire("bruine"));
            Components.Add(new Wire("gele"));

            /* Add an input. */
            var inputSymbols = new List<string>() { "U+058D", "U+1158", "U+06DE", "U+0B2A" };
            Components.Add(new Input(inputSymbols));

            /* Add buttons. */
            Components.Add(new Button("gele"));
            Components.Add(new Button("beige"));
            Components.Add(new Button("zwarte"));
            Components.Add(new Button("roze"));
            Components.Add(new Button("blauwe"));
            Components.Add(new Button("grijze"));

            /* Add timer. */
            Timer = new Timer(3600000);

            /* Add obeservations. */
            ObservationsOnInspect = new List<string>()
            {
                "De kleur van de bomb is blauw.",
                "De bom weegt 4500 gram.",
                "Het serienummer van de bom is 66d0e4ba-7b92-4da4-8906-02ab01db4208.",
                "De bom bevat 3 type componenten."
            };

            /* Add display */
            Display = new Queue<string>();
            Display.Enqueue("Aap");
            Display.Enqueue("Dinsdag");
            Display.Enqueue("Kerkelijk");

            /* Add accepted input. */
            AcceptedInput = new Stack<Command>();
            AcceptedInput.Push(new Command("U+06DE", Action.gebruik));
            AcceptedInput.Push(new Command("U+1158", Action.gebruik));
            AcceptedInput.Push(new Command("U+0B2A", Action.gebruik));
            AcceptedInput.Push(new Command("U+058D", Action.gebruik));

            AcceptedInput.Push(new Command("zwarte", Action.druk));
            AcceptedInput.Push(new Command("roze", Action.druk));
            AcceptedInput.Push(new Command("grijze", Action.druk));
            AcceptedInput.Push(new Command("gele", Action.druk));
            AcceptedInput.Push(new Command("beige", Action.druk));
            AcceptedInput.Push(new Command("blauwe", Action.druk));

            AcceptedInput.Push(new Command("zwarte", Action.knip));
            AcceptedInput.Push(new Command("paarse", Action.knip));
            AcceptedInput.Push(new Command("gele", Action.knip));
            AcceptedInput.Push(new Command("bruine", Action.knip));
        }
    }
}
