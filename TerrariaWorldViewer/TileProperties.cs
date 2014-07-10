using System.Drawing;

namespace TerrariaWorldViewer
{
    public class TileProperties
    {
        private readonly bool _isImportant;
        private readonly TileType _tileType;
        private readonly Color _tileColor;
        private readonly bool _hasSymbol;

        public bool IsImportant
        {
            get { return _isImportant; }
        }

        public bool HasSymbol
        {
            get { return _hasSymbol; }
        }

        public Color TileColor
        {
            get { return _tileColor; }
        }

        public TileType TileType
        {
            get { return _tileType; }
        }
        
        public TileProperties(TileType tileType, bool isTileImportant, Color colour, bool hasSymbol = false)
        {
            _tileType = tileType;
            _isImportant = isTileImportant;
            _tileColor = colour;
            _hasSymbol = hasSymbol;
        }
    }
}
