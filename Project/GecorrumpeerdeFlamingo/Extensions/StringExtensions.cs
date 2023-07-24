using GecorrumpeerdeFlamingo.Constants;

namespace GecorrumpeerdeFlamingo.Extensions
{
    public static class StringExtensions
    {
        public static Color ToColor(this string color)
        {
            color = color.ToLower();

            return color switch
            {
                "rode" => Color.Red,
                "groene" => Color.Green,
                "blauwe" => Color.Blue,
                "zwarte" => Color.Black,
                "witte" => Color.White,
                "zilvere" => Color.Silver,
                "gele" => Color.Yellow,
                "roze" => Color.Pink,
                "paarse" => Color.Purple,
                "bruine" => Color.Brown,
                "beige" => Color.Beige,
                "grijze" => Color.Gray,
                _ => Color.Unknown
            };
        }
    }
}
