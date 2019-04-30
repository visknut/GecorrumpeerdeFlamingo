using GecorrumpeerdeFlamingo.Entities;
using System;
using Action = GecorrumpeerdeFlamingo.Entities.Action;

namespace GecorrumpeerdeFlamingo
{
    public class ConsoleUtility
    {

        static public Command GetAction()
        {
            var result = Console.ReadLine();

            if (string.IsNullOrEmpty(result.Trim()))
            {
                Error();
                return null;
            }

            var results = result.Split(" ");
            var actionString = results[0];

            object action;

            if (!Enum.TryParse(typeof(Action), actionString, out action))
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

        static private void Error()
        {
            Console.WriteLine("Deze input werd niet begrepen. Probeer het opnieuw.");
            Help();
            WaitOnUser();
        }
        static public void Help()
        {
            Console.WriteLine("(Gebruik 'druk' voor knoppen, 'snijd' voor draden, 'gebruik' voor een element op het input component. [bijv: 'druk rode knop']. Type 'analyse' voor een analyse van de bom.)");
        }

        static public void WaitOnUser()
        {
            Console.Beep();
            Console.WriteLine("(Druk enter om verder te gaan)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
