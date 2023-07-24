using GecorrumpeerdeFlamingo.Constants;
using System;

namespace GecorrumpeerdeFlamingo.Extensions
{
    public static class ColorExtensions
    {
        public static void PrintColor(this Color color)
        {
            switch (color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("rode");
                    break;
                case Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("groene");
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("blauwe");
                    break;
                case Color.Black:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("zwarte");
                    break;
                case Color.White:
                    Console.Write("witte");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Color.Silver:
                    Console.Write("zilvere");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("gele");
                    break;
                case Color.Pink:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("roze");
                    break;
                case Color.Purple:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("paarse");
                    break;
                case Color.Brown:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("bruine");
                    break;
                case Color.Beige:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("beige");
                    break;
                case Color.Gray:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("grijze");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
            Console.ResetColor();
        }
    }
}
