using System.Collections.Generic;
using System.Drawing;

namespace TerrariaWorldViewer
{
    public class Chest
    {
        private readonly int _chestId;
        private readonly Point _coordinates;
        private readonly IList<Item> _items;

        public int ChestId
        {
            get { return _chestId; }
        }

        public Point Coordinates
        {
            get { return _coordinates; }
        }

        public IEnumerable<Item> Items
        {
            get { return _items; }
        }

        public Chest(int chestId, Point coordinates)
        {
            _chestId = chestId;
            _coordinates = coordinates;
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}
