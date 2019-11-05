
namespace Tony
{
    class CompassRange
    {
        public CompassRange(string name, int @from, int to)
            : base()
        {
            this.Name = name;
            this.From = from;
            this.To = to;
        }
        public string Name { get; }
        public int From { get; }
        public int To { get; }
    }
}
