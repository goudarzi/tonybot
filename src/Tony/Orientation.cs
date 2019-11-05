
using System;
using System.Linq;

namespace Tony
{
    public struct Orientation
    {
        public Orientation(int value)
            : this()
        {
            this.Value = value;
        }

        public static readonly Orientation North = new Orientation(0);
        public static readonly Orientation East = new Orientation(90);
        public static readonly Orientation South = new Orientation(180);
        public static readonly Orientation West = new Orientation(270);

        public static Orientation GetByName(string name)
        {
            return (Orientation)typeof(Orientation)
                .GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                .Where(field => field.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                .Single()
                .GetValue(null);
        }

        public int Value { get; }

        public string Name { get => new Compass().GetName(this.Value); }

        public Orientation Shift(int value)
        {
            int currentDirection = this.Value;

            currentDirection += value;

            currentDirection = currentDirection % 360;

            if (currentDirection < 0)
            {
                currentDirection += 360;
            }

            return new Orientation(currentDirection);
        }
    }
}
