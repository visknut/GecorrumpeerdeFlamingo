using GecorrumpeerdeFlamingo.Constants;
using GecorrumpeerdeFlamingo.Entities;
using GecorrumpeerdeFlamingo.Extensions;
using System;
using Action = GecorrumpeerdeFlamingo.Constants.Action;

namespace GecorrumpeerdeFlamingo;

public class ConsoleUtility
{

    public static Command GetAction()
    {
        Console.Write("\nType uw input: ");
        var result = Console.ReadLine();

        if (string.IsNullOrEmpty(result.Trim()))
        {
            Error();
            return null;
        }

        var results = result.Split(" ");
        var actionString = results[0];

        if (!Enum.TryParse(typeof(Action), actionString.ToLower(), out var action))
        {
            Error();
            return null;
        }

        var id = "";
        if (results.Length > 1)
        {
            id = results[1];
        }

        Console.Clear();

        return new Command(id, (Action)action);
    }

    private static void Error()
    {
        Console.WriteLine("\nDeze input werd niet begrepen. Probeer het opnieuw.");
        Help();
        WaitOnUser();
    }

    public static void Help()
    {
        Console.Write(
            "Type:\n- 'druk' voor knoppen \n- 'knip' voor draden \n- 'gebruik' voor een element op het input component \n\nBijvoorbeeld: 'druk ");
        Color.Red.PrintColor();
        Console.WriteLine(
            " knop' of 'gebruik U+0DF4'\n\nType 'analyse' voor een analyse van de bom.");
    }

    public static void WaitOnUser()
    {
        Console.Beep();
        Console.WriteLine("(Druk enter om verder te gaan)");
        Console.ReadKey();
        Console.Clear();
    }
}