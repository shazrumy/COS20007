using System;

namespace SwinAdventure
{
    // GamePath class - Task 11.2
    public class GamePath : IdentifiableObject
    {
        private Location _destination;

        public GamePath(string[] ids, Location destination) : base(ids)
        {
            _destination = destination;
        }

        public Location Destination
        {
            get { return _destination; }
        }

        // Move player to this path's destination
        public void MovePlayer(Player player)
        {
            player.Location = _destination;
        }
    }
}