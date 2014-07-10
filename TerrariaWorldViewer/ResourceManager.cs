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

        private Dictionary<TileType, Bitmap> symbolBitmaps;

        public static ResourceManager Instance { get { return UniqueInstance; } }

        private ResourceManager()
        {
            this.symbolBitmaps = new Dictionary<TileType, Bitmap>();            
        }

        /// <summary>
        /// Initialize the resource directory
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


        /// <summary>
        /// Copy the symbols externally to the resource directory
        /// </summary>
        public void ValidateSymbolResources()
        {
            Type resourceType = Util.GetResourceAssemblyType();

            foreach (string symbolName in Constants.ExternalSymbolNames)
            {
                // if it doesnt exist recopy
                if(!File.Exists(Path.Combine(Constants.ApplicationResourceDirectory, string.Format("{0}.png", symbolName))))
                {
                    var b = (Bitmap)Properties.Resources.ResourceManager.GetObject(symbolName);
                    SaveSymbolToResourceDirectory(b, symbolName);
                }
            }
        }

        /// <summary>
        /// Loads Symbols, filter which ones are actually enabled
        /// </summary>
        public void LoadSymbols()
        {
            //// Property file doesnt exist so recreate/reload
            //if(!File.Exists(Constants.ApplicationSymbolPropertiesFile))
            //{
            //    foreach (string symbolName in Constants.ExternalSymbolNames)
            //    {
            //        this.symbolProperties.Add((TileType)Enum.Parse(typeof(TileType), symbolName), new SymbolProperties(symbolName, true, GetSymbolPath(symbolName)));
            //    }

            //    // Serialize to File
            //    XmlSerializer outputSerializer = new XmlSerializer(this.symbolProperties.GetType());
            //    StringBuilder sb = new StringBuilder();
            //    StringWriter writer = new StringWriter(sb);
            //    outputSerializer.Serialize(writer, this.symbolProperties);
            //    XmlDocument xmlDocument = new XmlDocument();
            //    xmlDocument.LoadXml(sb.ToString());
            //    xmlDocument.Save(Constants.ApplicationSymbolPropertiesFile);
            //}
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(File.ReadAllText(Constants.ApplicationSymbolPropertiesFile));
            //XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            //XmlSerializer inputSerializer = new XmlSerializer(this.symbolProperties.GetType());
            //this.symbolProperties = (SerializableDictionary<TileType, SymbolProperties>)inputSerializer.Deserialize(reader);

            foreach (string symbolName in Constants.ExternalSymbolNames)
            {
                string symbolPath = GetSymbolPath(symbolName);
                this.symbolBitmaps.Add((TileType)Enum.Parse(typeof(TileType), symbolName), new Bitmap(symbolPath));
            }
        }

        public Bitmap GetSymbol(TileType symbolType)
        {
            if (!this.symbolBitmaps.ContainsKey(symbolType))
            {
                throw new ApplicationException(string.Format("Tile Type {0} Does not have an associated Symbol", symbolType));
            }
            return this.symbolBitmaps[symbolType];
        }

        public static string GetSymbolPath(string symbolName)
        {
            return Path.Combine(Constants.ApplicationResourceDirectory, string.Format("{0}.png", symbolName));
        }

        public static void SaveSymbolToResourceDirectory(Bitmap symbol, string name)
        {
            symbol.Save(Path.Combine(Constants.ApplicationResourceDirectory, string.Format("{0}.png", name)), ImageFormat.Png);
        }
    }
}
