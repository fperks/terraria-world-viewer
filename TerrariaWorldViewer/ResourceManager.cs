using System;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace TerrariaWorldViewer
{
    public sealed class ResourceManager
    {
        private static readonly Lazy<ResourceManager> UniqueInstance = new Lazy<ResourceManager>(() => new ResourceManager());

        private readonly IDictionary<TileType, Bitmap> _symbolBitmaps;

        public static ResourceManager Instance
        {
            get
            {
                return UniqueInstance.Value;
            }
        }

        private ResourceManager()
        {
            _symbolBitmaps = new Dictionary<TileType, Bitmap>();
        }
        
        /// <summary>
        /// Initialize the resources and the resource directories
        /// </summary>
        public void Initialize()
        {
            // Check to see if root folder directory exists
            if (!Directory.Exists(Constants.ApplicationRootDirectory))
            {
                // Create it
                Directory.CreateDirectory(Constants.ApplicationRootDirectory);
            }

            if (!Directory.Exists(Constants.ApplicationLogDirectory))
            {
                // Create it
                Directory.CreateDirectory(Constants.ApplicationLogDirectory);
            }

            if (!Directory.Exists(Constants.ApplicationResourceDirectory))
            {
                // Create it
                Directory.CreateDirectory(Constants.ApplicationResourceDirectory);
            }
            // Copy all the symbols
            ValidateSymbolResources();

            // Load
            LoadSymbols();
        }

        public Bitmap GetSymbol(TileType symbolType)
        {
            if (!_symbolBitmaps.ContainsKey(symbolType))
            {
                throw new ApplicationException(string.Format("Tile Type {0} Does not have an associated Symbol", symbolType));
            }
            return _symbolBitmaps[symbolType];
        }

        /// <summary>
        /// Copy the symbols externally to the resource directory
        /// </summary>
        private void ValidateSymbolResources()
        {
            foreach (var symbolName in Constants.ExternalSymbolNames)
            {
                // if it doesnt exist recopy
                var symbolPath = Path.Combine(Constants.ApplicationResourceDirectory,
                    string.Format("{0}.png", symbolName));
 
                if(!File.Exists(symbolPath))
                {
                    var b = (Bitmap)Properties.Resources.ResourceManager.GetObject(symbolName);
                    SaveSymbolToResourceDirectory(b, symbolName);
                }
            }
        }

        /// <summary>
        /// Loads Symbols, filter which ones are actually enabled
        /// </summary>
        private void LoadSymbols()
        {
            foreach (var symbolName in Constants.ExternalSymbolNames)
            {
                var symbolPath = GetSymbolPath(symbolName);
                _symbolBitmaps.Add((TileType)Enum.Parse(typeof(TileType), symbolName), new Bitmap(symbolPath));
            }
        }

        private static string GetSymbolPath(string symbolName)
        {
            return Path.Combine(Constants.ApplicationResourceDirectory, string.Format("{0}.png", symbolName));
        }

        private static void SaveSymbolToResourceDirectory(Bitmap symbol, string name)
        {
            symbol.Save(Path.Combine(Constants.ApplicationResourceDirectory, string.Format("{0}.png", name)), ImageFormat.Png);
        }
    }
}
