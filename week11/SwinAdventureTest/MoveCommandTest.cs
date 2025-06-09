using System;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTest
{
    // Unit tests for MoveCommand and GamePath - Task 11.2
    [TestFixture]
    public class MoveCommandTest
    {
        private Player _testPlayer;
        private Location _startRoom;
        private Location _endRoom;
        private GamePath _northPath;
        private MoveCommand _moveCommand;

        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("Test Player", "a test player");
            _startRoom = new Location(new string[] { "start" }, "Start Room", "Starting location");
            _endRoom = new Location(new string[] { "end" }, "End Room", "Destination location");
            _northPath = new GamePath(new string[] { "north", "n" }, _endRoom);
            _moveCommand = new MoveCommand();

            _startRoom.AddPath(_northPath);
            _testPlayer.Location = _startRoom;
        }

        // Test GamePath can move player to destination
        [Test]
        public void PathCanMovePlayer()
        {
            _northPath.MovePlayer(_testPlayer);
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
        }

        // Test getting GamePath from Location
        [Test]
        public void CanGetPathFromLocation()
        {
            GamePath? foundPath = _startRoom.GetPath("north");
            Assert.That(foundPath, Is.EqualTo(_northPath));
            
            GamePath? notFoundPath = _startRoom.GetPath("south");
            Assert.That(notFoundPath, Is.Null);
        }

        // Test player can leave location with valid path
        [Test]
        public void PlayerCanLeaveWithValidPath()
        {
            string result = _moveCommand.Execute(_testPlayer, new string[] { "move", "north" });
            
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
            Assert.That(result, Does.Contain("You move north"));
        }

        // Test player remains in same location with invalid path
        [Test]
        public void PlayerRemainsWithInvalidPath()
        {
            string result = _moveCommand.Execute(_testPlayer, new string[] { "move", "south" });
            
            Assert.That(_testPlayer.Location, Is.EqualTo(_startRoom));
            Assert.That(result, Does.Contain("You cannot go south"));
        }

        // Test all move command variations work
        [Test]
        public void AllMoveCommandsWork()
        {
            // Test "move"
            string result1 = _moveCommand.Execute(_testPlayer, new string[] { "move", "north" });
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
            
            // Reset position
            _testPlayer.Location = _startRoom;
            
            // Test "go"
            string result2 = _moveCommand.Execute(_testPlayer, new string[] { "go", "north" });
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
            
            // Reset position  
            _testPlayer.Location = _startRoom;
            
            // Test "head"
            string result3 = _moveCommand.Execute(_testPlayer, new string[] { "head", "north" });
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
            
            // Reset position
            _testPlayer.Location = _startRoom;
            
            // Test "leave"
            string result4 = _moveCommand.Execute(_testPlayer, new string[] { "leave", "north" });
            Assert.That(_testPlayer.Location, Is.EqualTo(_endRoom));
        }

        // Test invalid move command format
        [Test]
        public void InvalidMoveCommand()
        {
            string result1 = _moveCommand.Execute(_testPlayer, new string[] { "move" });
            Assert.That(result1, Is.EqualTo("I don't know how to move like that"));
            
            string result2 = _moveCommand.Execute(_testPlayer, new string[] { "walk", "north" });
            Assert.That(result2, Is.EqualTo("Error in move input"));
        }
    }
}