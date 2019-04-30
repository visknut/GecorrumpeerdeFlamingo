using GecorrumpeerdeFlamingo.Entities;
using System;
using Action = GecorrumpeerdeFlamingo.Entities.Action;

namespace GecorrumpeerdeFlamingo
{
    class Program
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static void Main(string[] args)
        {
            Intro();
            Bomb bomb = new RedBomb();
            long startTime;

            while (bomb.Timer.SecondsLeft > 0)
            {
                startTime = GetCurrentUnixTimestampMillis();
                if (bomb.AcceptedInput.Count == 0)
                {
                    Won();
                }

                Console.WriteLine(bomb.ToString());
                HandleInput(bomb);

                bomb = UpdateTime(bomb, startTime);
            }

            Lost();
        }

        private static void Intro()
        {
            Console.WriteLine("Welkom in het bomontmantelings-systeem!");
            Console.WriteLine("U bent succevol ingelogd op de server.\n");
            Console.WriteLine("Via deze interface kunt u op een veilige afstand met de bom interacteren met behulp van simpele commando's");

            ConsoleUtility.Help();
            ConsoleUtility.WaitOnUser();
        }

        public static long GetCurrentUnixTimestampMillis()
        {
            DateTime localDateTime, univDateTime;
            localDateTime = DateTime.Now;
            univDateTime = localDateTime.ToUniversalTime();
            return (long)(univDateTime - UnixEpoch).TotalMilliseconds;
        }

        private static Bomb UpdateTime(Bomb bomb, long startTime)
        {
            var endTime = GetCurrentUnixTimestampMillis();
            var time = (endTime - startTime) * bomb.Timer.Speed;

            bomb.Timer.SecondsLeft -= (int)time;

            return bomb;
        }

        static void Won()
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

        static void Lost()
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

        static private void HandleInput(Bomb bomb)
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

            var AcceptedCommand = bomb.AcceptedInput.Peek();
            if (command.Action == AcceptedCommand.Action
                && command.Id == AcceptedCommand.Id)
            {
                bomb.AcceptedInput.Pop();
                bomb.Display.Enqueue(bomb.Display.Dequeue());
                switch (command.Action)
                {
                    case (Action.druk):
                        {
                            DissableButton(bomb, command.Id);
                            break;
                        }
                    case (Action.knip):
                        {
                            DissableWire(bomb, command.Id);
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
                Console.WriteLine("De handeling werd niet geaccepteerd en de bom begint sneller te tikken.");
                bomb.Timer.Speed = bomb.Timer.Speed * 1.1;
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
            foreach(var component in bomb.Components)
            {
                if (component.GetType() == typeof(Input))
                {
                    var inputComponent = (Input)component;
                    foreach (var symbol in inputComponent.Symbols)
                    {
                        if (symbol == name)
                        {
                            inputComponent.ActiveSymbols.Remove(name);
                            if (inputComponent.ActiveSymbols.Count == 0)
                            {
                                inputComponent.Active = false;
                            }
                        }
                    }
                    Console.WriteLine($"Het element met het symbool {name} was succesvol geactiveerd.");
                    ConsoleUtility.WaitOnUser();
                    return;
                }
            }
            Console.WriteLine($"Handeling mislukt. Het element met het symbool {name}  was al geactiveerd of bestaat niet.");
            ConsoleUtility.WaitOnUser();
        }

        private static void DissableWire(Bomb bomb, string color)
        {
            foreach (var component in bomb.Components)
            {
                if (component.GetType() == typeof(Wire))
                {
                    var wireComponent = (Wire)component;
                    if (wireComponent.Color == color && wireComponent.Active)
                    {
                        wireComponent.Active = false;
                        Console.WriteLine($"De {color} draad was succesvol doorgeknipt.");
                        ConsoleUtility.WaitOnUser();
                        return;
                    }
                }
            }
            Console.WriteLine($"Handeling mislukt. De {color} draad was al doorgeknipt of bestaat niet.");
            ConsoleUtility.WaitOnUser();
        }

        private static void DissableButton(Bomb bomb, string color)
        {
            foreach (var component in bomb.Components)
            {
                if (component.GetType() == typeof(Button))
                {
                    var buttonComponent = (Button)component;
                    if (buttonComponent.Color == color && buttonComponent.Active)
                    {
                        buttonComponent.Active = false;
                        Console.WriteLine($"De {color} knop was succesvol indrukt.");
                        ConsoleUtility.WaitOnUser();
                        return;
                    }
                }
            }
            Console.WriteLine($"Handeling mislukt. De {color} knop was al ingedrukt of bestaat niet.");
            ConsoleUtility.WaitOnUser();
        }
    }
}
