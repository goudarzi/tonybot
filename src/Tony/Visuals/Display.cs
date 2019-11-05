using System;
using System.Collections.Generic;
using System.Linq;

namespace Tony.Visuals
{
    class Display
        : IDisplay
    {
        public Display()
            : base()
        {
            this._objects = new List<ConsoleShape>();
        }

        private List<ConsoleShape> _objects;

        public void AddShape(ConsoleShape shape)
        {
            this._objects.Add(shape);
        }

        void IDisplay.Render()
        {
            this._objects
                .Where(item => true == item.IsVisible)
                .ToList()
                .ForEach(
                shape =>
                {
                    shape.Draw(this);

                    Console.SetCursorPosition(0, 0);

                    Console.ResetColor();
                }
            );
        }

        void IDisplay.DrawText(ConsoleColor color, int x, int y, string text)
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(x, y);

            Console.Write(text);
        }
    }
}