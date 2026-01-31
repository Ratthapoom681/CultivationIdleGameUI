using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CultivationIdleGameUI
{
    public partial class MainForm : Form
    {
        private Player player;
        private SectSystem sectSystem;
        private AlchemySystem alchemySystem;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
            gameTimer.Start();
            AddLog("Welcome to Cultivation Idle Game!");
            AddLog("Your journey begins as a Mortal cultivator.");
            UpdateUI();
        }

        private void InitializeGame()
        {
            player = new Player();
            sectSystem = new SectSystem(player);
            alchemySystem = new AlchemySystem(player);
            
            // Give some starting herbs for testing
            player.Herbs.Add(new Herb { Name = "Ginseng Root", QiValue = 10, Rarity = 1 });
            player.Herbs.Add(new Herb { Name = "Spirit Grass", QiValue = 15, Rarity = 1 });
            player.Herbs.Add(new Herb { Name = "Ginseng Root", QiValue = 10, Rarity = 1 });
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            player.PassiveCultivation();
            UpdateUI();
        }

        private void UpdateUI()
        {
            // Update status labels
            realmLabel.Text = $"Realm: {player.CurrentRealm} {player.CurrentLevel}";
            sectLabel.Text = $"Sect: {player.Sect.Name}";
            qiLabel.Text = $"Qi: {player.Qi:F1}";
            spiritStonesLabel.Text = $"Spirit Stones: {player.SpiritStones}";
            cultivationRateLabel.Text = $"Cultivation Rate: {player.GetCurrentCultivationRate():F1} qi/sec";
            progressLabel.Text = $"Progress: {player.CultivationProgress:F1}%";
            
            // Update progress bar
            progressBar.Value = (int)Math.Min(100, player.CultivationProgress);
            
            // Update meditation status
            if (player.IsMeditating)
            {
                meditationLabel.Text = "Meditation: Active (+50% rate)";
                meditationLabel.ForeColor = Color.LightGreen;
            }
            else
            {
                meditationLabel.Text = "Meditation: Inactive";
                meditationLabel.ForeColor = Color.Gray;
            }
            
            // Update inventory
            UpdateInventoryDisplay();
        }

        private void UpdateInventoryDisplay()
        {
            var inventoryText = "=== INVENTORY ===\n\n";
            
            inventoryText += $"Spirit Stones: {player.SpiritStones}\n";
            inventoryText += $"Herbs: {player.Herbs.Count}\n";
            inventoryText += $"Pills: {player.Pills.Count}\n\n";
            
            if (player.Herbs.Any())
            {
                inventoryText += "Herbs:\n";
                var herbGroups = player.Herbs.GroupBy(h => h.Name);
                foreach (var group in herbGroups)
                {
                    var herb = group.First();
                    inventoryText += $"  • {group.Count()}x {herb.Name} (+{herb.QiValue} Qi)\n";
                }
                inventoryText += "\n";
            }
            
            if (player.Pills.Any())
            {
                inventoryText += "Pills:\n";
                foreach (var pill in player.Pills)
                {
                    inventoryText += $"  • {pill.Name} - {pill.Effect}\n";
                }
            }
            
            inventoryTextBox.Text = inventoryText;
        }

        private void AddLog(string message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            logTextBox.AppendText($"[{timestamp}] {message}\n");
            logTextBox.ScrollToCaret();
            
            // Limit log size
            var lines = logTextBox.Lines;
            if (lines.Length > 100)
            {
                logTextBox.Lines = lines.Skip(lines.Length - 100).ToArray();
            }
        }

        private void CultivateButton_Click(object sender, EventArgs e)
        {
            player.ActiveCultivation();
            AddLog("You focus your mind and cultivate actively!");
            UpdateUI();
        }

        private void MeditateButton_Click(object sender, EventArgs e)
        {
            player.StartMeditation();
            AddLog("You enter deep meditation state!");
            UpdateUI();
        }

        private void BreakthroughButton_Click(object sender, EventArgs e)
        {
            if (player.CurrentRealm == CultivationRealm.Immortal)
            {
                AddLog("You have reached the pinnacle of cultivation!");
                return;
            }

            if (player.CurrentLevel < 10)
            {
                AddLog($"You need to reach Level 10 in {player.CurrentRealm} before breakthrough!");
                return;
            }

            if (player.SpiritStones < 1000)
            {
                AddLog("You need 1000 Spirit Stones to breakthrough!");
                return;
            }

            player.SpiritStones -= 1000;
            
            double successRate = 0.6 + (player.CurrentLevel - 10) * 0.05;
            if (new Random().NextDouble() < successRate)
            {
                var oldRealm = player.CurrentRealm;
                player.CurrentRealm = (CultivationRealm)((int)player.CurrentRealm + 1);
                player.CurrentLevel = 1;
                player.CultivationProgress = 0;
                player.BaseCultivationRate *= 1.5;
                AddLog($"BREAKTHROUGH SUCCESS! You have reached {player.CurrentRealm} realm!");
                MessageBox.Show($"Congratulations! You've broken through from {oldRealm} to {player.CurrentRealm}!", "Breakthrough Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AddLog("Breakthrough failed! You lost 1000 Spirit Stones.");
                player.CurrentLevel = Math.Max(1, player.CurrentLevel - 2);
            }
            
            UpdateUI();
        }

        private void SectButton_Click(object sender, EventArgs e)
        {
            var sectForm = new SectManagementForm(player, sectSystem);
            sectForm.ShowDialog();
            UpdateUI();
        }

        private void AlchemyButton_Click(object sender, EventArgs e)
        {
            var alchemyForm = new AlchemyForm(player, alchemySystem);
            alchemyForm.ShowDialog();
            UpdateUI();
        }

        private void MissionButton_Click(object sender, EventArgs e)
        {
            if (player.Sect?.Name == "None" || player.Sect == null)
            {
                AddLog("You are not in any sect!");
                MessageBox.Show("You must join a sect first!", "No Sect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var random = new Random();
            var success = random.NextDouble() < 0.7;

            if (success)
            {
                int reward = random.Next(50, 200);
                player.SpiritStones += reward;
                AddLog($"Mission completed! You earned {reward} spirit stones.");
                
                if (random.NextDouble() < 0.3)
                {
                    var herb = sectSystem.GenerateRandomHerb();
                    player.Herbs.Add(herb);
                    AddLog($"You also found: {herb.Name}!");
                }
            }
            else
            {
                AddLog("Mission failed. Better luck next time.");
            }
            
            UpdateUI();
        }
    }
}