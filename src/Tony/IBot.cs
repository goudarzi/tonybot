using System;
using Tony.Visuals;

namespace Tony
{
    public interface IBot
    {
        ConsoleShape Shape { get; }
        Orientation Orientation { get; }
        bool Place(int x, int y, Orientation orientation);
        bool Move(int steps = 1);
        void Right();
        void Left();
    }
}