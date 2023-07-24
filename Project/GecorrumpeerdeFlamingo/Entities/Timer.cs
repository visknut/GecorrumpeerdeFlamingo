namespace GecorrumpeerdeFlamingo.Entities;

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

    public override string ToString()
    {
        return $"De timer leest: 00{SecondsLeft}ms";
    }
}