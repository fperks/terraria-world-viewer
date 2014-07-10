using System;

namespace TerrariaWorldViewer
{
    [Serializable]
    public class UserSettings
    {
        public string InputWorldDirectory { get; set; }
        public string OutputPreviewDirectory { get; set; }
        public bool IsChestFilterEnabled { get; set; }
        public bool IsWallsDrawable { get; set; }
        public bool IsSymbolsDrawable { get; set; }
        public SerializableDictionary<string, bool> SymbolStates { get; set; }
        public SerializableDictionary<string, bool> ChestFilterWeaponStates { get; set; }
        public SerializableDictionary<string, bool> ChestFilterAccessoryStates { get; set; }
    }
}