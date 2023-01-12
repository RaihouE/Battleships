namespace Battleships.Models
{
    public class Ship
    {
        private int _health;
        private readonly List<Coordinate> _coordinates;

        public Ship(int health, List<Coordinate> coordinates)
        {
            _health = health;
            _coordinates = coordinates;
        }

        public bool TryHit(Coordinate coordinate)
        {
            if (_coordinates.Any(c => c == coordinate))
            {
                return true;
            }

            return false;
        }
    }
}
