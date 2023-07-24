using GecorrumpeerdeFlamingo.Constants;
using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities;

public class BlueBomb : Bomb
{
    public BlueBomb()
    {
        Components = new List<Component>
        {
            /* Add wires. */
            new Wire(Constants.Color.Black),
            new Wire(Constants.Color.Purple),
            new Wire(Constants.Color.Brown),
            new Wire(Constants.Color.Yellow),

            /* Add an input. */
            new Input(new List<string> { "058D", "1158", "06DE", "0B2A" }),

            /* Add buttons. */
            new Button(Constants.Color.Yellow),
            new Button(Constants.Color.Beige),
            new Button(Constants.Color.Black),
            new Button(Constants.Color.Pink),
            new Button(Constants.Color.Blue),
            new Button(Constants.Color.Gray)
        };

        /* Add timer. */
        Timer = new Timer(3600000);

        /* Add obeservations. */
        ObservationsOnInspect = new List<string>
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