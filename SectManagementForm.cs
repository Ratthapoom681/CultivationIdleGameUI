using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CultivationIdleGameUI
{
    public partial class SectManagementForm : Form
    {
        private Player player;
        private SectSystem sectSystem;

        public SectManagementForm(Player player, SectSystem sectSystem)
        {
            this.player = player;
            this.sectSystem = sectSystem;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form Properties
            this.Text = "Sect Management";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.Font = new Font("Segoe UI", 9F);

            // Current Sect Panel
            var currentSectPanel = new Panel();
            currentSectPanel.Location = new Point(20, 20);
            currentSectPanel.Size = new Size(560, 80);
            currentSectPanel.BackColor = Color.FromArgb(40, 40, 50);
            currentSectPanel.BorderStyle = BorderStyle.FixedSingle;

            var currentSectLabel = new Label();
            currentSectLabel.Text = $"Current Sect: {player.Sect.Name}";
            currentSectLabel.Location = new Point(10, 10);
            currentSectLabel.Size = new Size(200, 25);
            currentSectLabel.ForeColor = Color.Gold;
            currentSectLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            var currentBonusLabel = new Label();
            currentBonusLabel.Text = $"Bonus: {player.Sect.CultivationBonus}x cultivation rate";
            currentBonusLabel.Location = new Point(10, 40);
            currentBonusLabel.Size = new Size(250, 25);
            currentBonusLabel.ForeColor = Color.LightGreen;

            currentSectPanel.Controls.Add(currentSectLabel);
            currentSectPanel.Controls.Add(currentBonusLabel);

            // Available Sects Panel
            var availablePanel = new Panel();
            availablePanel.Location = new Point(20, 120);
            availablePanel.Size = new Size(560, 340);
            availablePanel.BackColor = Color.FromArgb(40, 40, 50);
            availablePanel.BorderStyle = BorderStyle.FixedSingle;

            var titleLabel = new Label();
            titleLabel.Text = "Available Sects";
            titleLabel.Location = new Point(10, 10);
            titleLabel.Size = new Size(150, 25);
            titleLabel.ForeColor = Color.Gold;
            titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            var sectsListBox = new ListBox();
            sectsListBox.Location = new Point(10, 50);
            sectsListBox.Size = new Size(350, 250);
            sectsListBox.BackColor = Color.FromArgb(30, 30, 40);
            sectsListBox.ForeColor = Color.LightGray;
            sectsListBox.BorderStyle = BorderStyle.FixedSingle;

            // Populate sects
            var sects = new[]
            {
                new { key = "none", name = "None", desc = "Independent cultivator", bonus = "1.0x", req = "0" },
                new { key = "white_lotus", name = "White Lotus Sect", desc = "Peaceful cultivation focused sect", bonus = "1.2x", req = "Level 10, 500 stones" },
                new { key = "black_demon", name = "Black Demon Sect", desc = "Aggressive cultivation through battle", bonus = "1.5x", req = "Level 5, 1000 stones" },
                new { key = "heavenly_sword", name = "Heavenly Sword Sect", desc = "Sword cultivation specialists", bonus = "1.3x", req = "Level 8, 750 stones" },
                new { key = "mystic_alchemy", name = "Mystic Alchemy Sect", desc = "Alchemy and pill crafting experts", bonus = "1.1x", req = "Level 12, 600 stones" },
                new { key = "thunder_bolt", name = "Thunder Bolt Sect", desc = "Lightning cultivation masters", bonus = "1.4x", req = "Level 7, 800 stones" }
            };

            foreach (var sect in sects)
            {
                if (sect.name != "None" || player.Sect.Name != "None")
                {
                    sectsListBox.Items.Add($"{sect.name} ({sect.bonus}) - {sect.req}");
                }
            }

            var detailsLabel = new Label();
            detailsLabel.Location = new Point(370, 50);
            detailsLabel.Size = new Size(170, 250);
            detailsLabel.BackColor = Color.FromArgb(30, 30, 40);
            detailsLabel.ForeColor = Color.LightGray;
            detailsLabel.BorderStyle = BorderStyle.FixedSingle;

            sectsListBox.SelectedIndexChanged += (s, e) =>
            {
                if (sectsListBox.SelectedIndex >= 0 && sectsListBox.SelectedIndex < sects.Length)
                {
                    var sect = sects[sectsListBox.SelectedIndex];
                    detailsLabel.Text = $"{sect.name}\n\n{sect.desc}\n\nRequirements:\n{sect.req}";
                }
            };

            var joinButton = new Button();
            joinButton.Text = "Join Sect";
            joinButton.Location = new Point(10, 310);
            joinButton.Size = new Size(100, 25);
            joinButton.BackColor = Color.FromArgb(100, 50, 50);
            joinButton.ForeColor = Color.White;
            joinButton.FlatStyle = FlatStyle.Flat;

            joinButton.Click += (s, e) =>
            {
                if (sectsListBox.SelectedIndex >= 0 && sectsListBox.SelectedIndex < sects.Length)
                {
                    var selectedKey = sects[sectsListBox.SelectedIndex].key;
                    var success = sectSystem.JoinSect(selectedKey);
                    
                    if (success)
                    {
                        currentSectLabel.Text = $"Current Sect: {player.Sect.Name}";
                        currentBonusLabel.Text = $"Bonus: {player.Sect.CultivationBonus}x cultivation rate";
                    }
                }
            };

            var closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Location = new Point(450, 310);
            closeButton.Size = new Size(80, 25);
            closeButton.BackColor = Color.FromArgb(50, 50, 50);
            closeButton.ForeColor = Color.White;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Click += (s, e) => this.Close();

            availablePanel.Controls.Add(titleLabel);
            availablePanel.Controls.Add(sectsListBox);
            availablePanel.Controls.Add(detailsLabel);
            availablePanel.Controls.Add(joinButton);
            availablePanel.Controls.Add(closeButton);

            this.Controls.Add(currentSectPanel);
            this.Controls.Add(availablePanel);

            this.ResumeLayout(false);
        }
    }
}