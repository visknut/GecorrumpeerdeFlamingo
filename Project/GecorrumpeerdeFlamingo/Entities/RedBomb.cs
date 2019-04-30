using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class RedBomb : Bomb
    {
        public RedBomb()
        {
            Components = new List<Component>();

            /* Add wires. */
            Components.Add(new Wire("gele"));
            Components.Add(new Wire("rode"));
            Components.Add(new Wire("groene"));

            /* Add an input. */
            var inputSymbols = new List<string>() { "U+0BF5", "U+1325", "U+09E9", "U+0DF4" };
            Components.Add(new Input(inputSymbols));

            /* Add buttons. */
            Components.Add(new Button("roze"));
            Components.Add(new Button("groene"));
            Components.Add(new Button("zilvere"));
            Components.Add(new Button("rode"));

            /* Add timer. */
            Timer = new Timer(600000);

            /* Add obeservations. */
            ObservationsOnInspect = new List<string>()
            {
                "De kleur van de bomb is rood.",
                "De bom weegt 4500 gram.",
                "Het serienummer van de bom is 66d0e4ba-7b56-4db4-8906-02ab01da4208.",
                "De bom bevat 3 type componenten."
            };

            /* Add display */
            Display = new Queue<string>();
            Display.Enqueue("Aap");
            Display.Enqueue("Dinsdag");
            Display.Enqueue("Kerkelijk");

            /* Add accepted input. */
            AcceptedInput = new Stack<Command>();
            AcceptedInput.Push(new Command("U+0BF5", Action.gebruik));
            AcceptedInput.Push(new Command("U+1325", Action.gebruik));
            AcceptedInput.Push(new Command("U+0DF4", Action.gebruik));
            AcceptedInput.Push(new Command("U+09E9", Action.gebruik));

            AcceptedInput.Push(new Command("groene", Action.knip));
            AcceptedInput.Push(new Command("gele", Action.knip));
            AcceptedInput.Push(new Command("rode", Action.knip));

            AcceptedInput.Push(new Command("zilvere", Action.druk));
            AcceptedInput.Push(new Command("roze", Action.druk));
            AcceptedInput.Push(new Command("groene", Action.druk));
            AcceptedInput.Push(new Command("rode", Action.druk));
        }
    }
}
