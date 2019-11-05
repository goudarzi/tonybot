using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Tony.Commands;

namespace Tony.Tests
{
    public class CommandTests
    {
        [Test]
        [TestCase("Place", "10", "20", "East")]
        [TestCase("Place", "1", "25", "South")]
        [TestCase("Place", "12", "5", "North")]
        [TestCase("Place", "28", "50", "West")]
        public void PlaceCommandMustPlaceBot(string command, string x, string y, string orientation)
        {
            Mock<IBot> mockOfBot = new Mock<IBot>();

            Command placeCommand = PlaceCommand.Parse(new string[] { command, x, y, orientation });

            placeCommand.Execute(mockOfBot.Object);

            mockOfBot.Verify((bot) => bot.Place(int.Parse(x), int.Parse(y), Orientation.GetByName(orientation)));
        }

        [Test]
        [TestCase("Move", "10", "20", "East")]
        public void PlaceCommandMustNotParseOtherCommands(string command, string x, string y, string orientation)
        {
            string[] arguments = new string[] { command, x, y, orientation };

            Assert.Throws<InvalidOperationException>(() => PlaceCommand.Parse(arguments), $"Command {command} cannot be parsed into {nameof(PlaceCommand)}.");
        }

        [Test]
        [TestCase("Move")]
        public void PlaceCommandMustNotParseWrongArguments(string command)
        {
            string[] arguments = new string[] { command };

            Assert.Throws<InvalidOperationException>(() => PlaceCommand.Parse(arguments), $"{nameof(PlaceCommand)} accepts 3 parameters. X, Y and Orientation (South, North, East and West).");
        }

        [Test]
        [TestCase("Move", null)]
        [TestCase("Move", "10")]
        [TestCase("Move", "-2")]
        [TestCase("Move", "0")]
        public void MoveCommandMustMoveBot(string command, string steps)
        {
            Mock<IBot> mockOfBot = new Mock<IBot>();

            string[] arguments = new string[] { command, steps };

            arguments = arguments.Where(value => value != null).ToArray();

            Command placeCommand = MoveCommand.Parse(arguments);

            placeCommand.Execute(mockOfBot.Object);

            mockOfBot.Verify((bot) => bot.Move(int.Parse(steps ?? "1")));
        }

        [Test]
        public void LeftCommandParse()
        {
            Mock<IBot> mockOfBot = new Mock<IBot>();

            Command placeCommand = LeftCommand.Parse(new string[] { "LEFT" });

            placeCommand.Execute(mockOfBot.Object);

            mockOfBot.Verify((bot) => bot.Left());
        }

        [Test]
        public void RightCommandParse()
        {
            Mock<IBot> mockOfBot = new Mock<IBot>();

            Command placeCommand = RightCommand.Parse(new string[] { "RIGHT" });

            placeCommand.Execute(mockOfBot.Object);

            mockOfBot.Verify((bot) => bot.Right());
        }
    }
}
