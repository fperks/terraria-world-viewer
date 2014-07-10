using System.ComponentModel;
using System.Drawing;

namespace TerrariaWorldViewer
{

    /// <summary>
    /// File format terraria uses for the header of World Files
    /// </summary>
    public struct WorldHeader
    {
        private int _releaseNumber;
        private string _name;
        private int _id;
        private Rect _worldCoords;
        private Point _maxTiles;
        private Point _spawnPoint;
        private double _surfaceLevel;
        private double _rockLayer;
        private double _temporaryTime;
        private bool _isDayTime;
        private int _moonPhase;
        private bool _isBloodMoon;
        private Point _dungeonPoint;
        private bool _isBoss1Dead;
        private bool _isBoss2Dead;
        private bool _isBoss3Dead;
        private bool _isShadowOrbSmashed;
        private bool _isMeteorSpawned;
        private byte _shadowOrbsSmashed;
        private int _invasionDelay;
        private int _invasionSize;
        private int _invasionType;
        private double _invasionPointX;

        // NOTE: Properties are not automatic due to this implies structs are mutable which makes the serialization akward.

        [Category("General"), ReadOnly(true)]
// ReSharper disable ConvertToAutoProperty
        public int ReleaseNumber
        {
            get
            {
                return _releaseNumber;
            }
            set
            {
                _releaseNumber = value;
            }
        }

        [Category("General"), ReadOnly(true)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Category("General"), ReadOnly(true)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Rect WorldCoords
        {
            get
            {
                return _worldCoords;
            }
            set
            {
                _worldCoords = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point MaxTiles
        {
            get
            {
                return _maxTiles;
            }
            set
            {
                _maxTiles = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point SpawnPoint
        {
            get
            {
                return _spawnPoint;
            }
            set
            {
                _spawnPoint = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double SurfaceLevel
        {
            get
            {
                return _surfaceLevel;
            }
            set
            {
                _surfaceLevel = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double RockLayer
        {
            get
            {
                return _rockLayer;
            }
            set
            {
                _rockLayer = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double TemporaryTime
        {
            get
            {
                return _temporaryTime;
            }
            set
            {
                _temporaryTime = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public bool IsDayTime
        {
            get
            {
                return _isDayTime;
            }
            set
            {
                _isDayTime = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public int MoonPhase
        {
            get
            {
                return _moonPhase;
            }
            set
            {
                _moonPhase = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public bool IsBloodMoon
        {
            get
            {
                return _isBloodMoon;
            }
            set
            {
                _isBloodMoon = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point DungeonPoint
        {
            get
            {
                return _dungeonPoint;
            }
            set
            {
                _dungeonPoint = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss1Dead
        {
            get
            {
                return _isBoss1Dead;
            }
            set
            {
                _isBoss1Dead = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss2Dead
        {
            get
            {
                return _isBoss2Dead;
            }
            set
            {
                _isBoss2Dead = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss3Dead
        {
            get
            {
                return _isBoss3Dead;
            }
            set
            {
                _isBoss3Dead = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public bool IsShadowOrbSmashed
        {
            get
            {
                return _isShadowOrbSmashed;
            }
            set
            {
                _isShadowOrbSmashed = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public bool IsMeteorSpawned
        {
            get
            {
                return _isMeteorSpawned;
            }
            set
            {
                _isMeteorSpawned = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public byte ShadowOrbsSmashed
        {
            get
            {
                return _shadowOrbsSmashed;
            }
            set
            {
                _shadowOrbsSmashed = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionDelay
        {
            get
            {
                return _invasionDelay;
            }
            set
            {
                _invasionDelay = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionSize
        {
            get
            {
                return _invasionSize;
            }
            set
            {
                _invasionSize = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionType
        {
            get
            {
                return _invasionType;
            }
            set
            {
                _invasionType = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public double InvasionPointX
        {
            get
            {
                return _invasionPointX;
            }
            set
            {
                _invasionPointX = value;
            }

        }
        // ReSharper restore ConvertToAutoProperty
    }
}
