using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CultivationIdleGameUI
{
    public partial class AlchemyForm : Form
    {
        private Player player;
        private AlchemySystem alchemySystem;

        public AlchemyForm(Player player, AlchemySystem alchemySystem)
        {
            this.player = player;
            this.alchemySystem = alchemySystem;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form Properties
            this.Text = "Alchemy";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.Font = new Font("Segoe UI", 9F);

            // Recipes Panel
            var recipesPanel = new Panel();
            recipesPanel.Location = new Point(20, 20);
            recipesPanel.Size = new Size(660, 400);
            recipesPanel.BackColor = Color.FromArgb(40, 40, 50);
            recipesPanel.BorderStyle = BorderStyle.FixedSingle;

            var titleLabel = new Label();
            titleLabel.Text = "Alchemy Recipes";
            titleLabel.Location = new Point(10, 10);
            titleLabel.Size = new Size(150, 25);
            titleLabel.ForeColor = Color.Gold;
            titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            var recipesListBox = new ListBox();
            recipesListBox.Location = new Point(10, 50);
            recipesListBox.Size = new Size(300, 330);
            recipesListBox.BackColor = Color.FromArgb(30, 30, 40);
            recipesListBox.ForeColor = Color.LightGray;
            recipesListBox.BorderStyle = BorderStyle.FixedSingle;

            // Populate recipes
            var recipes = new[]
            {
                new { key = "qi_pill", name = "Qi Gathering Pill", level = "Level 1+", success = "80%", herbs = "2x Ginseng Root, 1x Spirit Grass" },
                new { key = "breakthrough_pill", name = "Breakthrough Pill", level = "Level 5+", success = "60%", herbs = "1x Blood Lotus, 2x Spirit Grass" },
                new { key = "divine_pill", name = "Divine Cultivation Pill", level = "Level 10+", success = "40%", herbs = "1x Void Flower, 1x Dragon Fruit, 2x Blood Lotus" }
            };

            foreach (var recipe in recipes)
            {
                recipesListBox.Items.Add($"{recipe.name} ({recipe.level})");
            }

            var detailsLabel = new Label();
            detailsLabel.Location = new Point(330, 50);
            detailsLabel.Size = new Size(320, 330);
            detailsLabel.BackColor = Color.FromArgb(30, 30, 40);
            detailsLabel.ForeColor = Color.LightGray;
            detailsLabel.BorderStyle = BorderStyle.FixedSingle;

            recipesListBox.SelectedIndexChanged += (s, e) =>
            {
                if (recipesListBox.SelectedIndex >= 0 && recipesListBox.SelectedIndex < recipes.Length)
                {
                    var recipe = recipes[recipesListBox.SelectedIndex];
                    detailsLabel.Text = $"{recipe.name}\n\nRequired Level: {recipe.level}\nSuccess Rate: {recipe.success}\n\nRequired Herbs:\n{recipe.herbs}";
                }
            };

            var craftButton = new Button();
            craftButton.Text = "Craft Pill";
            craftButton.Location = new Point(10, 390);
            craftButton.Size = new Size(100, 25);
            craftButton.BackColor = Color.FromArgb(100, 50, 100);
            craftButton.ForeColor = Color.White;
            craftButton.FlatStyle = FlatStyle.Flat;

            craftButton.Click += (s, e) =>
            {
                if (recipesListBox.SelectedIndex >= 0 && recipesListBox.SelectedIndex < recipes.Length)
                {
                    var selectedKey = recipes[recipesListBox.SelectedIndex].key;
                    var success = alchemySystem.CraftPill(selectedKey);
                    
                    if (success)
                    {
                        MessageBox.Show($"Successfully crafted {recipes[recipesListBox.SelectedIndex].name}!", "Crafting Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Crafting failed! Check your requirements and try again.", "Crafting Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    UpdateInventoryStatus();
                }
            };

            recipesPanel.Controls.Add(titleLabel);
            recipesPanel.Controls.Add(recipesListBox);
            recipesPanel.Controls.Add(detailsLabel);
            recipesPanel.Controls.Add(craftButton);

            // Inventory Status Panel
            var inventoryPanel = new Panel();
            inventoryPanel.Location = new Point(20, 440);
            inventoryPanel.Size = new Size(660, 120);
            inventoryPanel.BackColor = Color.FromArgb(40, 40, 50);
            inventoryPanel.BorderStyle = BorderStyle.FixedSingle;

            var inventoryTitleLabel = new Label();
            inventoryTitleLabel.Text = "Your Herbs";
            inventoryTitleLabel.Location = new Point(10, 10);
            inventoryTitleLabel.Size = new Size(100, 25);
            inventoryTitleLabel.ForeColor = Color.Gold;
            inventoryTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            var herbsLabel = new Label();
            herbsLabel.Location = new Point(10, 40);
            herbsLabel.Size = new Size(640, 70);
            herbsLabel.BackColor = Color.FromArgb(30, 30, 40);
            herbsLabel.ForeColor = Color.LightGray;
            herbsLabel.BorderStyle = BorderStyle.FixedSingle;

            inventoryPanel.Controls.Add(inventoryTitleLabel);
            inventoryPanel.Controls.Add(herbsLabel);

            var closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Location = new Point(580, 10);
            closeButton.Size = new Size(70, 25);
            closeButton.BackColor = Color.FromArgb(50, 50, 50);
            closeButton.ForeColor = Color.White;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Click += (s, e) => this.Close();

            this.Controls.Add(recipesPanel);
            this.Controls.Add(inventoryPanel);
            recipesPanel.Controls.Add(closeButton);

            UpdateInventoryStatus();

            this.ResumeLayout(false);
        }

        private void UpdateInventoryStatus()
        {
            var herbsLabel = this.Controls.OfType<Panel>()
                .FirstOrDefault(p => p.Location.Y == 440)?
                .Controls.OfType<Label>()
                .FirstOrDefault(l => l.Location.Y == 40);

            if (herbsLabel != null)
            {
                var herbText = "Herbs available:\n\n";
                
                if (!player.Herbs.Any())
                {
                    herbText += "No herbs available. Gather herbs from sect missions!";
                }
                else
                {
                    var herbGroups = player.Herbs.GroupBy(h => h.Name);
                    foreach (var group in herbGroups)
                    {
                        herbText += $"• {group.Count()}x {group.Key}\n";
                    }
                }
                
                herbText += $"\nTotal Pills: {player.Pills.Count}";
                
                herbsLabel.Text = herbText;
            }
        }
    }
}