using Microsoft.Extensions.DependencyInjection;
using System;
using Tony.Commands;
using Tony.Visuals;

namespace Tony
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<CommandParser>()
                .AddSingleton<Surface>(
                    (sp) => new Surface(0, 1, 50, 40)
                )
                .AddSingleton<IDisplay>(
                    (sp) =>
                    {
                        IDisplay display = new Display();

                        return display;
                    }
                )
                .AddScoped<IBot>(
                    (sp) =>
                    {
                        Bot bot = new Bot(sp.GetRequiredService<Surface>());

                        //TODO: Wait for tony to bootup and test visibility/components.

                        return bot;
                    }
                )
                .BuildServiceProvider();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                Surface surface = scope.ServiceProvider.GetRequiredService<Surface>();
                IBot bot = scope.ServiceProvider.GetRequiredService<IBot>();
                IDisplay display = scope.ServiceProvider.GetRequiredService<IDisplay>();

                display.AddShape(surface.Shape);
                display.AddShape(bot.Shape);

                // Default Placement
                //bot.Place(surface.Shape.Area.X + 1, surface.Shape.Area.Y + 1, Orientation.East);

                display.Render();

                while (true)
                {
                    Console.Write(">");

                    Console.SetCursorPosition(1, 0);

                    string command = Console.ReadLine().Trim().ToUpper();

                    if (command == "CONNECT")
                    {
                        Console.Clear();

                        if (false == bot.Shape.IsVisible)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("> Tony must be placed prior to connection.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("> CONNECTED (Press Esc to disconnect)");

                            bool isConnected = true;

                            while (true == isConnected)
                            {
                                display.Render();

                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Escape: isConnected = false; break;
                                    case ConsoleKey.RightArrow: bot.Right(); break;
                                    case ConsoleKey.LeftArrow: bot.Left(); break;
                                    case ConsoleKey.UpArrow: bot.Move(); break;
                                    case ConsoleKey.DownArrow: bot.Move(-1); break;
                                    default: continue;
                                }
                            }
                        }
                    }
                    else if (command == "EXIT")

                        return;
                    else
                    {
                        CommandParser parser = scope.ServiceProvider.GetRequiredService<CommandParser>();

                        try
                        {
                            parser.ParseSingleCommand(command).Execute(bot);
                        }
                        catch (Exception ex)
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(ex.Message);
                            Console.ReadKey();
                        }
                    }

                    Console.Clear();

                    display.Render();
                }
            }
        }
    }
}
