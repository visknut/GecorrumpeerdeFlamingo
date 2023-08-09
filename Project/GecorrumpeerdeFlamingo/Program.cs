using GecorrumpeerdeFlamingo.Constants;
using GecorrumpeerdeFlamingo.Entities;
using GecorrumpeerdeFlamingo.Extensions;
using System;
using Action = GecorrumpeerdeFlamingo.Constants.Action;

namespace GecorrumpeerdeFlamingo;

internal class Program
{
    private static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Intro();
        Bomb bomb = new BlueBomb();

        while (bomb.Timer.SecondsLeft > 0)
        {
            var startTime = GetCurrentUnixTimestampMillis();
            if (bomb.AcceptedInput.Count == 0)
            {
                Won();
            }

            bomb.Print();
            HandleInput(bomb);

            bomb = UpdateTime(bomb, startTime);
        }

        Lost();
    }

    private static void Intro()
    {
        Console.WriteLine("Welkom in het bomontmantelings-systeem!");
        Console.WriteLine("U bent succesvol ingelogd op de server.\n");
        Console.WriteLine("Via deze interface kunt u op een veilige afstand met de bom interacteren met behulp van simpele commando's");

        ConsoleUtility.Help();
        ConsoleUtility.WaitOnUser();
    }

    public static long GetCurrentUnixTimestampMillis()
    {
        var localDateTime = DateTime.Now;
        var univDateTime = localDateTime.ToUniversalTime();
        return (long)(univDateTime - UnixEpoch).TotalMilliseconds;
    }

    private static Bomb UpdateTime(Bomb bomb, long startTime)
    {
        var endTime = GetCurrentUnixTimestampMillis();
        var time = (endTime - startTime) * bomb.Timer.Speed;

        bomb.Timer.SecondsLeft -= (int)time;

        return bomb;
    }

    private static void Won()
    {
        while (true)
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Het is gelukt om de bom op tijd te ontmantelen!");
            ConsoleUtility.WaitOnUser();
        }
    }

    private static void Lost()
    {
        while (true)
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Het is niet gelukt om de bom op tijd te ontmantelen! De bom is ontploft...");
            ConsoleUtility.WaitOnUser();
        }
    }

    private static void HandleInput(Bomb bomb)
    {
        var command = ConsoleUtility.GetAction();

        if (command == null)
        {
            return;
        }

        if (command.Action == Action.analyse)
        {
            ShowAnalyse(bomb);
            return;
        }

        var acceptedCommand = bomb.AcceptedInput.Peek();
        if (command.Action == acceptedCommand.Action
            && command.Id == acceptedCommand.Id)
        {
            bomb.AcceptedInput.Pop();
            bomb.Display.Enqueue(bomb.Display.Dequeue());
            switch (command.Action)
            {
                case (Action.druk):
                    {
                        DissableButton(bomb, command.Id.ToColor());
                        break;
                    }
                case (Action.knip):
                    {
                        DissableWire(bomb, command.Id.ToColor());
                        break;
                    }
                case (Action.gebruik):
                    {
                        DissableInput(bomb, command.Id);
                        break;
                    }
            }
        }
        else
        {
            Console.Beep();
            Console.WriteLine("De handeling werd niet geaccepteerd en de bom begint sneller te tikken en de timer verspringt enkele minuten.");

            bomb.Timer.Speed *= 1.1;
            bomb.Timer.SecondsLeft -= 120000;

            ConsoleUtility.WaitOnUser();
        }
    }

    private static void ShowAnalyse(Bomb bomb)
    {
        Console.WriteLine(bomb.AnalyzeBomb());
        ConsoleUtility.WaitOnUser();
    }

    private static void DissableInput(Bomb bomb, string name)
    {
        foreach (var component in bomb.Components)
        {
            if (component.GetType() != typeof(Input)) continue;

            var inputComponent = (Input)component;
            inputComponent.ActiveSymbols.Remove(name[2..]);

            if (inputComponent.ActiveSymbols.Count == 0)
            {
                inputComponent.Active = false;
            }

            Console.WriteLine($"Het element met het symbool {name} was succesvol geactiveerd.");
            ConsoleUtility.WaitOnUser();

            return;
        }

        Console.WriteLine($"Handeling mislukt. Het element met het symbool {name} was al geactiveerd of bestaat niet.");
        ConsoleUtility.WaitOnUser();
    }

    private static void DissableWire(Bomb bomb, Color color)
    {
        if (color == Color.Unknown)
        {
            Console.WriteLine("Handeling mislukt. Er is geen draad met de kleur die u invoerde.");
            ConsoleUtility.WaitOnUser();
            return;
        }

        foreach (var component in bomb.Components)
        {
            if (component.GetType() != typeof(Wire)) continue;

            var wireComponent = (Wire)component;

            if (wireComponent.Color != color || !wireComponent.Active) continue;

            wireComponent.Active = false;
            Console.Write("De ");
            color.PrintColor();
            Console.WriteLine(" draad was succesvol doorgeknipt.");
            ConsoleUtility.WaitOnUser();
            return;
        }

        Console.Write("Handeling mislukt. De ");
        color.PrintColor();
        Console.WriteLine(" draad was al doorgeknipt of bestaat niet.");
        ConsoleUtility.WaitOnUser();
    }

    private static void DissableButton(Bomb bomb, Color color)
    {
        if (color == Color.Unknown)
        {
            Console.WriteLine("Handeling mislukt. Er is geen knop met de kleur die u invoerde.");
            ConsoleUtility.WaitOnUser();
            return;
        }

        foreach (var component in bomb.Components)
        {
            if (component.GetType() != typeof(Button)) continue;

            var buttonComponent = (Button)component;

            if (buttonComponent.Color != color || !buttonComponent.Active) continue;

            buttonComponent.Active = false;
            Console.Write("De ");
            color.PrintColor();
            Console.WriteLine(" knop was succesvol indrukt.");
            ConsoleUtility.WaitOnUser();
            return;
        }

        Console.Write("Handeling mislukt. De ");
        color.PrintColor();
        Console.WriteLine(" knop was al ingedrukt of bestaat niet.");
        ConsoleUtility.WaitOnUser();
    }
}