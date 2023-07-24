using GecorrumpeerdeFlamingo.Extensions;
using System;
using System.Collections.Generic;

namespace GecorrumpeerdeFlamingo.Entities;

public class Bomb
{
    public string Color { get; set; }
    public List<Component> Components { get; set; }
    public Queue<string> Display { get; set; }
    public Timer Timer { get; set; }
    public List<string> ObservationsOnInspect { get; set; }
    public Stack<Command> AcceptedInput { get; set; }

    public void Print()
    {
        Console.WriteLine($"{Timer}");
        Console.WriteLine($"De display laat de volgende code zien: {Display.Peek()}\n");
        Console.WriteLine("De volgende componenten zijn aanwezig op de bom:");

        foreach (var component in Components)
        {
            switch (component)
            {
                case Button button:
                    Console.Write("- Een ");
                    button.Color.PrintColor();
                    Console.WriteLine(button.Active ? " knop." : " ingedrukte knop.");
                    break;
                case Wire wire:
                    Console.Write("- Een ");
                    wire.Color.PrintColor();
                    Console.WriteLine(wire.Active ? " draad." : " doorgeknipt draad.");
                    break;
                case Input:
                    Console.WriteLine(component);
                    break;
            }
        }
    }

    public string AnalyzeBomb()
    {
        var description = "Analyse bom:\n";

        foreach (var observation in ObservationsOnInspect)
        {
            description += $"- {observation}\n";
        }
        return description;
    }
}