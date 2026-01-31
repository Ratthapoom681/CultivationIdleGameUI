using System;
using System.Collections.Generic;
using System.Linq;

namespace CultivationIdleGameUI
{
    public class AlchemySystem
    {
        private Player player;
        private Dictionary<string, Recipe> recipes;

        public AlchemySystem(Player player)
        {
            this.player = player;
            InitializeRecipes();
        }

        private void InitializeRecipes()
        {
            recipes = new Dictionary<string, Recipe>
            {
                ["qi_pill"] = new Recipe
                {
                    Name = "Qi Gathering Pill",
                    RequiredHerbs = new List<(string herb, int count)>
                    {
                        ("Ginseng Root", 2),
                        ("Spirit Grass", 1)
                    },
                    Effect = "+50 Qi",
                    SuccessRate = 0.8,
                    RequiredLevel = 1
                },
                ["breakthrough_pill"] = new Recipe
                {
                    Name = "Breakthrough Pill",
                    RequiredHerbs = new List<(string herb, int count)>
                    {
                        ("Blood Lotus", 1),
                        ("Spirit Grass", 2)
                    },
                    Effect = "+20% breakthrough chance",
                    SuccessRate = 0.6,
                    RequiredLevel = 5
                },
                ["divine_pill"] = new Recipe
                {
                    Name = "Divine Cultivation Pill",
                    RequiredHerbs = new List<(string herb, int count)>
                    {
                        ("Void Flower", 1),
                        ("Dragon Fruit", 1),
                        ("Blood Lotus", 2)
                    },
                    Effect = "+200 Qi, +10% cultivation rate",
                    SuccessRate = 0.4,
                    RequiredLevel = 10
                }
            };
        }

        public void ShowRecipes()
        {
            Console.WriteLine("=== Alchemy Recipes ===");
            foreach (var recipe in recipes.Values)
            {
                Console.WriteLine($"{recipe.Name} (Level {recipe.RequiredLevel}+):");
                Console.WriteLine($"  Success Rate: {recipe.SuccessRate * 100}%");
                Console.WriteLine($"  Required Herbs: {string.Join(", ", recipe.RequiredHerbs.Select(h => $"{h.herb} x{h.count}"))}");
                Console.WriteLine($"  Effect: {recipe.Effect}");
                Console.WriteLine();
            }
        }

        public bool CraftPill(string recipeKey)
        {
            if (!recipes.ContainsKey(recipeKey))
            {
                Console.WriteLine("Recipe not found!");
                return false;
            }

            var recipe = recipes[recipeKey];

            if (player.CurrentLevel < recipe.RequiredLevel)
            {
                Console.WriteLine($"You need to be level {recipe.RequiredLevel} to craft this pill!");
                return false;
            }

            // Check if player has required herbs
            foreach (var (herbName, count) in recipe.RequiredHerbs)
            {
                var playerHerbs = player.Herbs.Where(h => h.Name == herbName).ToList();
                if (playerHerbs.Count < count)
                {
                    Console.WriteLine($"You need {count} {herbName} to craft this pill!");
                    return false;
                }
            }

            // Remove required herbs
            foreach (var (herbName, count) in recipe.RequiredHerbs)
            {
                for (int i = 0; i < count; i++)
                {
                    var herbToRemove = player.Herbs.First(h => h.Name == herbName);
                    player.Herbs.Remove(herbToRemove);
                }
            }

            // Attempt crafting
            var random = new Random();
            if (random.NextDouble() < recipe.SuccessRate)
            {
                var pill = new Pill
                {
                    Name = recipe.Name,
                    Effect = recipe.Effect,
                    Power = recipe.RequiredLevel * 10
                };
                player.Pills.Add(pill);
                Console.WriteLine($"Successfully crafted {pill.Name}!");
                return true;
            }
            else
            {
                Console.WriteLine("Crafting failed! The herbs were consumed.");
                return false;
            }
        }

        public void UsePill(string pillName)
        {
            var pill = player.Pills.FirstOrDefault(p => p.Name == pillName);
            if (pill == null)
            {
                Console.WriteLine("You don't have this pill!");
                return;
            }

            // Apply pill effects
            if (pill.Name.Contains("Qi Gathering"))
            {
                player.Qi += 50;
                player.AddCultivationProgress(5);
            }
            else if (pill.Name.Contains("Breakthrough"))
            {
                // This would modify breakthrough logic in main game
                Console.WriteLine("Breakthrough pill consumed! Your next breakthrough has increased success rate.");
            }
            else if (pill.Name.Contains("Divine"))
            {
                player.Qi += 200;
                player.BaseCultivationRate *= 1.1;
                Console.WriteLine("Divine power flows through you!");
            }

            player.Pills.Remove(pill);
            Console.WriteLine($"You used {pill.Name}: {pill.Effect}");
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<(string herb, int count)> RequiredHerbs { get; set; }
        public string Effect { get; set; }
        public double SuccessRate { get; set; }
        public int RequiredLevel { get; set; }
    }
}