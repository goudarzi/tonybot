using System.Linq;

namespace Tony
{
    class Compass
    {
        private CompassRange[] _ranges;

        public Compass()
        {
            _ranges = new CompassRange[]
            {
                new CompassRange("N", 350, 360),
                new CompassRange("N", 0, 10),
                new CompassRange("NE", 10, 80),
                new CompassRange("E", 80, 100),
                new CompassRange("ES", 100, 170),
                new CompassRange("S", 170, 190),
                new CompassRange("SW", 190, 260),
                new CompassRange("W", 260, 280),
                new CompassRange("NW", 280, 350)
            };
        }

        public string GetName(int direction)
        {
            direction = direction % 360;

            return _ranges.First(x => x.From <= direction && x.To >= direction).Name;
        }
    }
}