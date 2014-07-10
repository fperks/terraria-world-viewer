namespace TerrariaWorldViewer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    public struct WorldHeader
    {
        private int releaseNumber;
        private string name;
        private int id;
        private Rect worldCoords;
        private Point maxTiles;
        private Point spawnPoint;
        private double surfaceLevel;
        private double rockLayer;
        private double temporaryTime;
        private bool isDayTime;
        private int moonPhase;
        private bool isBloodMoon;
        private Point dungeonPoint;
        private bool isBoss1Dead;
        private bool isBoss2Dead;
        private bool isBoss3Dead;
        private bool isShadowOrbSmashed;
        private bool isMeteorSpawned;
        private byte shadowOrbsSmashed;
        private int invasionDelay;
        private int invasionSize;
        private int invasionType;
        private double invasionPointX;

        [Category("General"), ReadOnly(true)]
        public int ReleaseNumber
        {
            get
            {
                return this.releaseNumber;
            }
            set
            {
                this.releaseNumber = value;
            }
        }

        [Category("General"), ReadOnly(true)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [Category("General"), ReadOnly(true)]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Rect WorldCoords
        {
            get
            {
                return this.worldCoords;
            }
            set
            {
                this.worldCoords = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point MaxTiles
        {
            get
            {
                return this.maxTiles;
            }
            set
            {
                this.maxTiles = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point SpawnPoint
        {
            get
            {
                return this.spawnPoint;
            }
            set
            {
                this.spawnPoint = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double SurfaceLevel
        {
            get
            {
                return this.surfaceLevel;
            }
            set
            {
                this.surfaceLevel = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double RockLayer
        {
            get
            {
                return this.rockLayer;
            }
            set
            {
                this.rockLayer = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public double TemporaryTime
        {
            get
            {
                return this.temporaryTime;
            }
            set
            {
                this.temporaryTime = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public bool IsDayTime
        {
            get
            {
                return this.isDayTime;
            }
            set
            {
                this.isDayTime = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public int MoonPhase
        {
            get
            {
                return this.moonPhase;
            }
            set
            {
                this.moonPhase = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public bool IsBloodMoon
        {
            get
            {
                return this.isBloodMoon;
            }
            set
            {
                this.isBloodMoon = value;
            }
        }

        [Category("World Information"), ReadOnly(true)]
        public Point DungeonPoint
        {
            get
            {
                return this.dungeonPoint;
            }
            set
            {
                this.dungeonPoint = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss1Dead
        {
            get
            {
                return this.isBoss1Dead;
            }
            set
            {
                this.isBoss1Dead = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss2Dead
        {
            get
            {
                return this.isBoss2Dead;
            }
            set
            {
                this.isBoss2Dead = value;
            }
        }

        [Category("Boss Information"), ReadOnly(true)]
        public bool IsBoss3Dead
        {
            get
            {
                return this.isBoss3Dead;
            }
            set
            {
                this.isBoss3Dead = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public bool IsShadowOrbSmashed
        {
            get
            {
                return this.isShadowOrbSmashed;
            }
            set
            {
                this.isShadowOrbSmashed = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public bool IsMeteorSpawned
        {
            get
            {
                return this.isMeteorSpawned;
            }
            set
            {
                this.isMeteorSpawned = value;
            }
        }

        [Category("Meteor Information"), ReadOnly(true)]
        public byte ShadowOrbsSmashed
        {
            get
            {
                return this.shadowOrbsSmashed;
            }
            set
            {
                this.shadowOrbsSmashed = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionDelay
        {
            get
            {
                return this.invasionDelay;
            }
            set
            {
                this.invasionDelay = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionSize
        {
            get
            {
                return this.invasionSize;
            }
            set
            {
                this.invasionSize = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public int InvasionType
        {
            get
            {
                return this.invasionType;
            }
            set
            {
                this.invasionType = value;
            }
        }

        [Category("Invasion Information"), ReadOnly(true)]
        public double InvasionPointX
        {
            get
            {
                return this.invasionPointX;
            }
            set
            {
                this.invasionPointX = value;
            }

        }
    }
}
