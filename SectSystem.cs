using System;
using System.Collections.Generic;

namespace CultivationIdleGameUI
{
    public class SectSystem
    {
        private Player player;
        private Dictionary<string, Sect> availableSects;

        public SectSystem(Player player)
        {
            this.player = player;
            InitializeSects();
        }

        private void InitializeSects()
        {
            availableSects = new Dictionary<string, Sect>
            {
                ["none"] = new Sect("None", "Independent cultivator", 1.0, 0, 0),
                ["white_lotus"] = new Sect("White Lotus Sect", "Peaceful cultivation focused sect", 1.2, 10, 500),
                ["black_demon"] = new Sect("Black Demon Sect", "Aggressive cultivation through battle", 1.5, 5, 1000),
                ["heavenly_sword"] = new Sect("Heavenly Sword Sect", "Sword cultivation specialists", 1.3, 8, 750),
                ["mystic_alchemy"] = new Sect("Mystic Alchemy Sect", "Alchemy and pill crafting experts", 1.1, 12, 600),
                ["thunder_bolt"] = new Sect("Thunder Bolt Sect", "Lightning cultivation masters", 1.4, 7, 800)
            };
        }

        public void ShowAvailableSects()
        {
            Console.WriteLine("=== Available Sects ===");
            foreach (var sect in availableSects.Values)
            {
                if (sect.Name != "None")
                {
                    Console.WriteLine($"{sect.Name}: {sect.Description}");
                    Console.WriteLine($"  Requirements: {sect.RequiredLevel}+ cultivation, {sect.RequiredStones} spirit stones");
                    Console.WriteLine($"  Bonus: {sect.CultivationBonus}x cultivation rate");
                    Console.WriteLine();
                }
            }
        }

        public bool JoinSect(string sectKey)
        {
            if (!availableSects.ContainsKey(sectKey))
            {
                Console.WriteLine("Sect not found!");
                return false;
            }

            var sect = availableSects[sectKey];
            
            if (sect.Name == "None")
            {
                player.Sect = sect;
                player.BaseCultivationRate /= player.Sect.CultivationBonus;
                Console.WriteLine("You have left your sect and become an independent cultivator.");
                return true;
            }

            if (player.CurrentLevel < sect.RequiredLevel)
            {
                Console.WriteLine($"You need to be at least level {sect.RequiredLevel} to join {sect.Name}!");
                return false;
            }

            if (player.SpiritStones < sect.RequiredStones)
            {
                Console.WriteLine($"You need {sect.RequiredStones} spirit stones to join {sect.Name}!");
                return false;
            }

            // Leave current sect if any
            if (player.Sect?.Name != "None" && player.Sect != null)
            {
                player.BaseCultivationRate /= player.Sect.CultivationBonus;
            }

            player.SpiritStones -= sect.RequiredStones;
            player.Sect = sect;
            player.BaseCultivationRate *= sect.CultivationBonus;
            
            Console.WriteLine($"You have successfully joined {sect.Name}!");
            Console.WriteLine($"Your cultivation rate is now multiplied by {sect.CultivationBonus}!");
            return true;
        }

        public void DoSectMission()
        {
            if (player.Sect?.Name == "None" || player.Sect == null)
            {
                Console.WriteLine("You are not in any sect!");
                return;
            }

            var random = new Random();
            var success = random.NextDouble() < 0.7;

            if (success)
            {
                int reward = random.Next(50, 200);
                player.SpiritStones += reward;
                Console.WriteLine($"Mission completed! You earned {reward} spirit stones.");
                
                // Small chance to get herb
                if (random.NextDouble() < 0.3)
                {
                    var herb = GenerateRandomHerb();
                    player.Herbs.Add(herb);
                    Console.WriteLine($"You also found: {herb.Name}!");
                }
            }
            else
            {
                Console.WriteLine("Mission failed. Better luck next time.");
            }
        }

        public Herb GenerateRandomHerb()
        {
            var herbs = new List<Herb>
            {
                new Herb { Name = "Ginseng Root", QiValue = 10, Rarity = 1 },
                new Herb { Name = "Spirit Grass", QiValue = 15, Rarity = 1 },
                new Herb { Name = "Blood Lotus", QiValue = 25, Rarity = 2 },
                new Herb { Name = "Void Flower", QiValue = 40, Rarity = 3 },
                new Herb { Name = "Dragon Fruit", QiValue = 60, Rarity = 4 }
            };

            var random = new Random();
            return herbs[random.Next(herbs.Count)];
        }
    }
}