using System;
using System.Collections.Generic;

namespace CultivationIdleGameUI
{
    public class Player
    {
        public string Name { get; set; } = "Disciple";
        public double Qi { get; set; } = 0;
        public int SpiritStones { get; set; } = 100;
        public double CultivationRate { get; set; } = 1.0;
        public double BaseCultivationRate { get; set; } = 1.0;
        
        // Cultivation System
        public CultivationRealm CurrentRealm { get; set; } = CultivationRealm.Mortal;
        public int CurrentLevel { get; set; } = 1;
        public double CultivationProgress { get; set; } = 0;
        public double RequiredQiForNextLevel => GetRequiredQiForNextLevel();
        
        // Status Effects
        public bool IsMeditating { get; private set; } = false;
        public DateTime MeditationEndTime { get; private set; } = DateTime.MinValue;
        
        // Sect
        public Sect Sect { get; set; } = new Sect("None", "Independent cultivator", 1.0, 0, 0);
        
        // Inventory
        public List<Herb> Herbs { get; set; } = new List<Herb>();
        public List<Pill> Pills { get; set; } = new List<Pill>();

        public void ActiveCultivation()
        {
            double gain = CultivationRate * 10;
            Qi += gain;
            AddCultivationProgress(gain * 0.1);
        }

        public void PassiveCultivation()
        {
            double currentRate = GetCurrentCultivationRate();
            Qi += currentRate;
            AddCultivationProgress(currentRate * 0.1);

            // Check if meditation should end
            if (IsMeditating && DateTime.Now >= MeditationEndTime)
            {
                IsMeditating = false;
            }
        }

        public void StartMeditation()
        {
            if (IsMeditating)
            {
                Console.WriteLine("You are already meditating!");
                return;
            }

            IsMeditating = true;
            MeditationEndTime = DateTime.Now.AddSeconds(30);
        }

        public double GetCurrentCultivationRate()
        {
            double rate = BaseCultivationRate;
            
            // Realm bonus
            rate *= (1 + (int)CurrentRealm * 0.2);
            
            // Meditation bonus
            if (IsMeditating)
                rate *= 1.5;
            
            return rate;
        }

        public void AddCultivationProgress(double amount)
        {
            CultivationProgress += amount;
            
            // Auto level up
            while (CultivationProgress >= 100)
            {
                CultivationProgress -= 100;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            CurrentLevel++;
            BaseCultivationRate *= 1.1;
            Console.WriteLine($"\nLEVEL UP! You are now {CurrentRealm} Level {CurrentLevel}!");
        }

        public void TryBreakthrough()
        {
            if (CurrentRealm == CultivationRealm.Immortal)
            {
                Console.WriteLine("You have reached the pinnacle of cultivation!");
                return;
            }

            if (CurrentLevel < 10)
            {
                Console.WriteLine($"You need to reach Level 10 in {CurrentRealm} before breakthrough!");
                return;
            }

            if (SpiritStones < 1000)
            {
                Console.WriteLine("You need 1000 Spirit Stones to breakthrough!");
                return;
            }

            SpiritStones -= 1000;
            
            // Breakthrough success chance
            double successRate = 0.6 + (CurrentLevel - 10) * 0.05;
            if (new Random().NextDouble() < successRate)
            {
                CurrentRealm = (CultivationRealm)((int)CurrentRealm + 1);
                CurrentLevel = 1;
                CultivationProgress = 0;
                BaseCultivationRate *= 1.5;
                Console.WriteLine($"BREAKTHROUGH SUCCESS! You have reached {CurrentRealm} realm!");
            }
            else
            {
                Console.WriteLine("Breakthrough failed! You lost 1000 Spirit Stones.");
                CurrentLevel = Math.Max(1, CurrentLevel - 2);
            }
        }

        private double GetRequiredQiForNextLevel()
        {
            return 100 * Math.Pow(1.5, CurrentLevel - 1) * (1 + (int)CurrentRealm * 0.5);
        }

        public void ShowInventory()
        {
            Console.WriteLine("=== Inventory ===");
            Console.WriteLine($"Herbs: {Herbs.Count}");
            Console.WriteLine($"Pills: {Pills.Count}");
            Console.WriteLine();
            
            if (Herbs.Count > 0)
            {
                Console.WriteLine("Herbs:");
                foreach (var herb in Herbs)
                {
                    Console.WriteLine($"  - {herb.Name} (Qi: +{herb.QiValue})");
                }
            }
            
            if (Pills.Count > 0)
            {
                Console.WriteLine("Pills:");
                foreach (var pill in Pills)
                {
                    Console.WriteLine($"  - {pill.Name} ({pill.Effect})");
                }
            }
        }
    }

    public enum CultivationRealm
    {
        Mortal,
        QiCondensation,
        FoundationEstablishment,
        CoreFormation,
        NascentSoul,
        GoldenCore,
        NascentDivinity,
        SpiritSovereign,
        Immortal
    }

    public class Herb
    {
        public string Name { get; set; }
        public double QiValue { get; set; }
        public int Rarity { get; set; }
    }

    public class Pill
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int Power { get; set; }
    }

    public class Sect
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CultivationBonus { get; set; }
        public int RequiredLevel { get; set; }
        public int RequiredStones { get; set; }

        public Sect(string name, string description, double bonus, int requiredLevel, int requiredStones)
        {
            Name = name;
            Description = description;
            CultivationBonus = bonus;
            RequiredLevel = requiredLevel;
            RequiredStones = requiredStones;
        }
    }
}