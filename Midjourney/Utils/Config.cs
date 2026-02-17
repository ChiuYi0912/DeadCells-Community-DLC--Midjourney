using System.Collections.Generic;

namespace Midjourney.Utils
{
    public class BackGardenConfig
    {
        public string LevelId { get; set; } = "BackGarden";
        public string DisplayName { get; set; } = "Back Garden";
        public string ResourcePath { get; set; } = "BackGardenAsstes/";
        public string Biome { get; set; } = "BackGarden";
        public string Biome2 { get; set; } = "BackGarden_Outside";

        


        public bool Enabled { get; set; } = false;
        public double MobDensity { get; set; } = 1.0;
        public int LootLevel { get; set; } = 2;

        public Dictionary<string, object> CustomSettings { get; set; } = new();
    }
}