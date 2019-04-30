namespace GecorrumpeerdeFlamingo.Entities
{
    public class Timer
    {
        public int SecondsLeft { get; set; }
        public double Speed { get; set; }

        public Timer(int secondsLeft)
        {
            // var jsonFile = System.IO.File.ReadAllText(@"./Sounds/SoundSettings.json");
            // settings = JsonConvert.DeserializeObject(jsonFile);
            SecondsLeft = secondsLeft;
            Speed = 1.0;
        }

        override public string ToString()
        {
            return $"De timer leest: {SecondsLeft}";
        }
    }
}
