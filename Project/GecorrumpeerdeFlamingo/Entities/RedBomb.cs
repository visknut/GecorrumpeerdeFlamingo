using GecorrumpeerdeFlamingo.Constants;
using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities;

public class RedBomb : Bomb
{
    public RedBomb()
    {
        Components = new List<Component>
        {
            /* Add wires. */
            new Wire(Constants.Color.Yellow),
            new Wire(Constants.Color.Red),
            new Wire(Constants.Color.Green),

            /* Add an input. */
            new Input(new List<string> { "0BF5", "1325", "09E9", "0DF4" }),

            /* Add buttons. */
            new Button(Constants.Color.Pink),
            new Button(Constants.Color.Green),
            new Button(Constants.Color.Silver),
            new Button(Constants.Color.Red)
        };

        /* Add timer. */
        Timer = new Timer(3600000);

        /* Add obeservations. */
        ObservationsOnInspect = new List<string>
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
        AcceptedInput.Push(new Command("U+09E9", Action.gebruik));
        AcceptedInput.Push(new Command("U+0DF4", Action.gebruik));
        AcceptedInput.Push(new Command("U+1325", Action.gebruik));
        AcceptedInput.Push(new Command("U+0BF5", Action.gebruik));

        AcceptedInput.Push(new Command("groene", Action.knip));
        AcceptedInput.Push(new Command("gele", Action.knip));
        AcceptedInput.Push(new Command("rode", Action.knip));

        AcceptedInput.Push(new Command("zilvere", Action.druk));
        AcceptedInput.Push(new Command("roze", Action.druk));
        AcceptedInput.Push(new Command("groene", Action.druk));
        AcceptedInput.Push(new Command("rode", Action.druk));
    }
}