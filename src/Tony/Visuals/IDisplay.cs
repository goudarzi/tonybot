using System;

namespace Tony.Visuals
{
    public interface IDisplay
    {
        void AddShape(ConsoleShape shape);
        void DrawText(ConsoleColor color, int x, int y, string line);
        void Render();
    }
}