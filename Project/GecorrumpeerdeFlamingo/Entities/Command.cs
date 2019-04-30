namespace GecorrumpeerdeFlamingo.Entities
{
    public class Command
    {
        public Action Action { get; set; }
        public string Id { get; set; }

        public Command(string id, Action action)
        {
            Id = id;
            Action = action;
        }
    }
}
