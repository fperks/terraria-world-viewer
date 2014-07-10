using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TerrariaWorldViewer
{
    public sealed class SettingsManager
    {
        private static readonly Lazy<SettingsManager> UniqueInstance = new Lazy<SettingsManager>(() => new SettingsManager());

        public static SettingsManager Instance
        {
            get { return UniqueInstance.Value; }
        }

        public UserSettings Settings { get; set; }
        
        private SettingsManager()
        {
            Settings = new UserSettings()
            {
                IsChestFilterEnabled = false,
                SymbolStates = new SerializableDictionary<string, bool>(),       
                ChestFilterWeaponStates = new SerializableDictionary<string, bool>(),
                ChestFilterAccessoryStates = new SerializableDictionary<string, bool>(),
                IsWallsDrawable = true,
                IsSymbolsDrawable = true,
                InputWorldDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games\\Terraria\\Worlds")
            };

            foreach (var s in Constants.ExternalSymbolNames)
            {
                Settings.SymbolStates.Add(s, true);
            }

            foreach (var s in Constants.ChestFilterWeapons)
            {
                Settings.ChestFilterWeaponStates.Add(s, false);
            }

            foreach (var s in Constants.ChestFilterAccessories)
            {
                Settings.ChestFilterAccessoryStates.Add(s, false);
            }

            if (!Directory.Exists(Settings.InputWorldDirectory))
            {
                Settings.InputWorldDirectory = string.Empty;
            }
        }



        public string InputWorldDirectory
        {
            get
            {
                return Settings.InputWorldDirectory;
            }
            set
            {
                Settings.InputWorldDirectory = value;
            }
        }

        public string OutputPreviewDirectory
        {
            get
            {
                return Settings.OutputPreviewDirectory;
            }
            set
            {
                Settings.OutputPreviewDirectory = value;
            }
        }

        public Dictionary<string, bool> SymbolStates
        {
            get
            {
                return Settings.SymbolStates;
            }
        }

        public bool IsSymbolsDrawable
        {
            get
            {
                return Settings.IsSymbolsDrawable;
            }
            set
            {
                Settings.IsSymbolsDrawable = value;
            }
        }

        public bool IsWallDrawable
        {
            get
            {
                return Settings.IsWallsDrawable;
            }
            set
            {
                Settings.IsWallsDrawable = value;
            }
        }

        public bool IsSymbolViewable(TileType type)
        {
            // convert to string index
            return Settings.SymbolStates[Enum.GetName(typeof(TileType), type)];
        }

        public void ToggleSymbolVisibility(string key, bool status)
        {
            Settings.SymbolStates[key] = status;
        }

        public void ToggleFilterWeapon(string weaponName, bool status)
        {
            Settings.ChestFilterWeaponStates[weaponName] = status;
        }

        public void ToggleFilterAccessories(string accessoryName, bool status)
        {
            Settings.ChestFilterAccessoryStates[accessoryName] = status;
        }

        public Dictionary<string, bool> FilterItemsStates
        {
            get
            {
                return Settings.ChestFilterWeaponStates.Concat(Settings.ChestFilterAccessoryStates).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public Dictionary<string, bool> FilterWeaponStates
        {
            get
            {
                return Settings.ChestFilterWeaponStates;
            }
        }

        public Dictionary<string, bool> FilterAccessoryStates
        {
            get
            {
                return Settings.ChestFilterAccessoryStates;
            }
        }

        public bool IsChestFilterEnabled
        {
            get
            {
                return Settings.IsChestFilterEnabled;
            }
            set
            {
                Settings.IsChestFilterEnabled = value;
            }
        }

        public void Initialize()
        {
            // Initialization
            if (!File.Exists(Constants.ApplicationUserSettingsFile))
            {
                return;
            }

            // Load User Preference File
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(File.ReadAllText(Constants.ApplicationUserSettingsFile));

            if (xmlDoc.DocumentElement == null)
            {
                throw new InvalidOperationException(string.Format("Document Element is Null in Settings File"));
            }

            var reader = new XmlNodeReader(xmlDoc.DocumentElement);
            var inputSerializer = new XmlSerializer(Settings.GetType());
            Settings = (UserSettings)inputSerializer.Deserialize(reader);
        }

        public void Shutdown()
        {           
            // Serialize Symbols / Etc
            var outputSerializer = new XmlSerializer(Settings.GetType());
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            outputSerializer.Serialize(writer, Settings);
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sb.ToString());
            xmlDocument.Save(Constants.ApplicationUserSettingsFile);
        }

        
    }
}
