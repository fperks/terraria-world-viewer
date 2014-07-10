using System.Drawing;
using System.IO;
namespace TerrariaWorldViewer
{
    public class WorldReader
    {
        private readonly string _worldFilePath;
        private FileStream _worldStream;
        private BinaryReader _reader;
        
        private long TileOffset { get; set; }
        private long ChestOffset { get; set; }

        private BinaryReader Reader
        {
            get
            {
                return _reader ?? (_reader = new BinaryReader(WorldStream));
            }
        }

        private FileStream WorldStream
        {
            get
            {
                return _worldStream ?? (_worldStream = new FileStream(_worldFilePath, FileMode.Open));
            }
        }
        
        public WorldReader(string filePath)
        {
            _worldFilePath = filePath;
            TileOffset = 0L;
            ChestOffset = 0L;
        }

        public void SeekToTiles()
        {
            WorldStream.Seek(TileOffset, SeekOrigin.Begin);
        }

        public WorldHeader ReadHeader()
        {
            // Reset to origin
            WorldStream.Seek(0, SeekOrigin.Begin);

            var releaseNumber = _reader.ReadInt32();
            WorldHeader header;
            if (releaseNumber == 38)
            {
                header = new WorldHeader
                {
                    ReleaseNumber = releaseNumber,
                    Name = Reader.ReadString(),
         //           Id = this.reader.ReadInt32(),
                    WorldCoords = new Rect(Reader.ReadInt32(), Reader.ReadInt32(), Reader.ReadInt32(), Reader.ReadInt32()),
                    MaxTiles = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    SpawnPoint = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    SurfaceLevel = Reader.ReadDouble(),
                    RockLayer = Reader.ReadDouble(),
                    TemporaryTime = Reader.ReadDouble(),
                    IsDayTime = Reader.ReadBoolean(),
                    MoonPhase = Reader.ReadInt32(),
                    IsBloodMoon = Reader.ReadBoolean(),
                    DungeonPoint = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    IsBoss1Dead = Reader.ReadBoolean(),
                    IsBoss2Dead = Reader.ReadBoolean(),
                    IsBoss3Dead = Reader.ReadBoolean(),
                    IsShadowOrbSmashed = Reader.ReadBoolean(),
                    IsMeteorSpawned = Reader.ReadBoolean(),
                    ShadowOrbsSmashed = Reader.ReadByte(),
                    InvasionDelay = Reader.ReadInt32(),
                    InvasionSize = Reader.ReadInt32(),
                    InvasionType = Reader.ReadInt32(),
                    InvasionPointX = Reader.ReadDouble(),
                };
            }
            else
            {
                header = new WorldHeader
                {
                    ReleaseNumber = releaseNumber,
                    Name = Reader.ReadString(),
                    Id = Reader.ReadInt32(),
                    WorldCoords = new Rect(Reader.ReadInt32(), Reader.ReadInt32(), Reader.ReadInt32(), Reader.ReadInt32()),
                    MaxTiles = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    SpawnPoint = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    SurfaceLevel = Reader.ReadDouble(),
                    RockLayer = Reader.ReadDouble(),
                    TemporaryTime = Reader.ReadDouble(),
                    IsDayTime = Reader.ReadBoolean(),
                    MoonPhase = Reader.ReadInt32(),
                    IsBloodMoon = Reader.ReadBoolean(),
                    DungeonPoint = new Point(Reader.ReadInt32(), Reader.ReadInt32()),
                    IsBoss1Dead = Reader.ReadBoolean(),
                    IsBoss2Dead = Reader.ReadBoolean(),
                    IsBoss3Dead = Reader.ReadBoolean(),
                    IsShadowOrbSmashed = Reader.ReadBoolean(),
                    IsMeteorSpawned = Reader.ReadBoolean(),
                    ShadowOrbsSmashed = Reader.ReadByte(),
                    InvasionDelay = Reader.ReadInt32(),
                    InvasionSize = Reader.ReadInt32(),
                    InvasionType = Reader.ReadInt32(),
                    InvasionPointX = Reader.ReadDouble(),
                };

            }

            TileOffset = WorldStream.Position;
            return header;
        }

        public TileType GetNextTile()
        {
            var isTileActive = Reader.ReadBoolean();
            var tileType = TileType.Unknown;
            byte blockType = 0x00;
            if (isTileActive)
            {
                blockType = Reader.ReadByte();
                if (WorldMapper.tileTypeDefs[blockType].IsImportant)
                {
                    // skip this blocks
                    Reader.ReadInt16();
                    Reader.ReadInt16();
                }
                tileType = WorldMapper.tileTypeDefs[blockType].TileType;
            }
            else
            {
                tileType = TileType.Sky;
            }
            var isLighted = Reader.ReadBoolean();
            var isWall = Reader.ReadBoolean();
            if (isWall)
            {
                byte wallType = Reader.ReadByte();
                if (tileType == TileType.Unknown || tileType == TileType.Sky)
                {
                    if (!WorldMapper.tileTypeDefs.ContainsKey((int)wallType + Constants.WallOffset))
                    {
                        tileType = TileType.Unknown;
                    }
                    else
                    {
                        tileType = WorldMapper.tileTypeDefs[(int)wallType + Constants.WallOffset].TileType;
                    }
                    
                }
            }
            var isLiquid = Reader.ReadBoolean();
            if (isLiquid)
            {
                var liquidLevel = Reader.ReadByte();
                var isLava = Reader.ReadBoolean();
                if (isWall || tileType == TileType.Sky)
                {
                    tileType = isLava ? TileType.Lava : TileType.Water;
                }
                
            }
            return tileType;
        }

        /// <summary>
        /// Gets the next chest, if the next item is not a chest, return null
        /// </summary>
        /// <returns></returns>
        public Chest GetNextChest(int chestId)
        {
            var isChest = Reader.ReadBoolean();
            if (!isChest)
            {
                return null;
            }
            var chest = new Chest(chestId, new Point(Reader.ReadInt32(), Reader.ReadInt32()));

            // Iterate through items contained within chest
            for (var i = 0; i < Constants.ChestMaxItems; i++)
            {
                var count = Reader.ReadByte();
                if (count > 0)
                {
                    chest.AddItem(new Item(Reader.ReadString(), count));
                }
            }
            return chest;
        }

        public void Close()
        {
            Reader.Close();
        }
  
        //public void CreatePreviewImage(string outputFilePath)
        //{
        //    int maxX = (int)Header.MaxTiles.Y;
        //    int maxY = (int)Header.MaxTiles.X;
        //    //byte[,] pixels = new byte[cols, rows];

        //    Bitmap bitmap = new Bitmap(maxX, maxY);
        //    Graphics g2 = Graphics.FromImage((Image)bitmap);
        //    g2.FillRectangle(Brushes.SkyBlue, 0, 0, bitmap.Width, bitmap.Height);
        //    Dictionary<byte, Color> randomColors = new Dictionary<byte, Color>();
        //    Random random = new Random();
        //    for (int col = 0; col < maxX; col++)
        //    {
        //        for (int row = 0; row < maxY; row++)
        //        {
        //            bool isTileActive = reader.ReadBoolean();
        //            TileType tileType = TileType.Unknown;
        //            byte blockType = 0x00;
        //            if (isTileActive)
        //            {
        //                blockType = reader.ReadByte();
        //                if (tileTypeDefs[blockType].isImportant)
        //                {
        //                    reader.ReadInt16();
        //                    reader.ReadInt16();
        //                }
        //                tileType = tileTypeDefs[blockType].tileType;
        //            }
        //            else
        //            {
        //                tileType = TileType.Sky;
        //            }
        //            bool isLighted = reader.ReadBoolean();
        //            bool isWall = reader.ReadBoolean();
        //            if (isWall)
        //            {
        //                byte wallType = reader.ReadByte();
        //                if (tileType == TileType.Unknown)
        //                {
        //                    tileType = TileType.Wall;    
        //                }
                        
        //               // bitmap.SetPixel(col, row, Color.PowderBlue);
        //            }
        //            bool isLiquid = reader.ReadBoolean();
                    
        //            if (isLiquid)
        //            {
        //                byte liquidLevel = reader.ReadByte();
        //                bool isLava = reader.ReadBoolean();
        //                tileType = isLava ? TileType.Lava : TileType.Water;
        //               // bitmap.SetPixel(col, row, isLava ? Color.Pink : Color.Blue);
        //            }
        //            //if (tileType != TileType.Lava || tileType != TileType.Wall || tileType != TileType.Water)
        //            //{
        //            //    if (!randomColors.ContainsKey(blockType))
        //            //    {

        //            //        int r = random.Next(0, 255);
        //            //        int g = random.Next(0, 255);
        //            //        int b = random.Next(0, 255);

        //            //        randomColors.Add(blockType, Color.FromArgb(r, g, b));
        //            //    }
        //            //    bitmap.SetPixel(col, row, randomColors[blockType]);
        //            //}
        //            //if (tileType == TileType.Unknown)
        //            //{
        //            //    if (!randomColors.ContainsKey(blockType))
        //            //    {
        //            //        int r = random.Next(0, 255);
        //            //        int g = random.Next(0, 255);
        //            //        int b = random.Next(0, 255);
        //            //        randomColors.Add(blockType, Color.FromArgb(r, g, b));
        //            //    }
        //            //    bitmap.SetPixel(col, row, randomColors[blockType]);
        //            //}
        //            if (tileType != TileType.Sky)
        //            {
        //                bitmap.SetPixel(col, row, tileColorDefs[tileType]);
        //            }
        //            else
        //            {
        //                // Don't draw its sky
        //            }
        //        }
        //    }


        //    //TextWriter fs = new StreamWriter(@"C:\Users\Frank\Documents\My Games\Terraria\Worlds\dump.txt");
        //    //foreach (var pair in randomColors)
        //    //{
        //    //    fs.WriteLine(string.Format("{0}, ({1}, {2}, {3})", pair.Key, pair.Value.R, pair.Value.G, pair.Value.B));
        //    ////}
        //    //fs.Close();


        //    bitmap.Save(outputFilePath, ImageFormat.Png);
        //    reader.Close();
        //}
    }
}
