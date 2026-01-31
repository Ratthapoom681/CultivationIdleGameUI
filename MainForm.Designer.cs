using System;
using System.Drawing;
using System.Windows.Forms;

namespace CultivationIdleGameUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form Properties
            this.Text = "Cultivation Idle Game";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.Font = new Font("Segoe UI", 9F);

            // Main Status Panel
            this.statusPanel = new Panel();
            this.statusPanel.Location = new Point(20, 20);
            this.statusPanel.Size = new Size(960, 200);
            this.statusPanel.BackColor = Color.FromArgb(40, 40, 50);
            this.statusPanel.BorderStyle = BorderStyle.FixedSingle;

            // Title Label
            this.titleLabel = new Label();
            this.titleLabel.Text = "=== Cultivation Idle Game ===";
            this.titleLabel.Location = new Point(20, 10);
            this.titleLabel.Size = new Size(400, 30);
            this.titleLabel.ForeColor = Color.Gold;
            this.titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            // Player Info Labels
            this.realmLabel = new Label();
            this.realmLabel.Text = "Realm: Mortal 1";
            this.realmLabel.Location = new Point(20, 60);
            this.realmLabel.Size = new Size(200, 25);
            this.realmLabel.ForeColor = Color.Cyan;

            this.sectLabel = new Label();
            this.sectLabel.Text = "Sect: None";
            this.sectLabel.Location = new Point(250, 60);
            this.sectLabel.Size = new Size(200, 25);
            this.sectLabel.ForeColor = Color.LightGreen;

            this.qiLabel = new Label();
            this.qiLabel.Text = "Qi: 0.0";
            this.qiLabel.Location = new Point(500, 60);
            this.qiLabel.Size = new Size(150, 25);
            this.qiLabel.ForeColor = Color.Orange;

            this.spiritStonesLabel = new Label();
            this.spiritStonesLabel.Text = "Spirit Stones: 100";
            this.spiritStonesLabel.Location = new Point(20, 90);
            this.spiritStonesLabel.Size = new Size(200, 25);
            this.spiritStonesLabel.ForeColor = Color.Yellow;

            this.cultivationRateLabel = new Label();
            this.cultivationRateLabel.Text = "Cultivation Rate: 1.0 qi/sec";
            this.cultivationRateLabel.Location = new Point(250, 90);
            this.cultivationRateLabel.Size = new Size(250, 25);
            this.cultivationRateLabel.ForeColor = Color.LightBlue;

            this.progressLabel = new Label();
            this.progressLabel.Text = "Progress: 0.0%";
            this.progressLabel.Location = new Point(500, 90);
            this.progressLabel.Size = new Size(150, 25);
            this.progressLabel.ForeColor = Color.Pink;

            // Progress Bar
            this.progressBar = new ProgressBar();
            this.progressBar.Location = new Point(20, 130);
            this.progressBar.Size = new Size(400, 30);
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.BackColor = Color.FromArgb(60, 60, 70);

            // Meditation Status
            this.meditationLabel = new Label();
            this.meditationLabel.Text = "Meditation: Inactive";
            this.meditationLabel.Location = new Point(20, 170);
            this.meditationLabel.Size = new Size(200, 25);
            this.meditationLabel.ForeColor = Color.Gray;

            // Action Buttons Panel
            this.actionPanel = new Panel();
            this.actionPanel.Location = new Point(20, 240);
            this.actionPanel.Size = new Size(300, 400);
            this.actionPanel.BackColor = Color.FromArgb(40, 40, 50);
            this.actionPanel.BorderStyle = BorderStyle.FixedSingle;

            this.actionTitleLabel = new Label();
            this.actionTitleLabel.Text = "Actions";
            this.actionTitleLabel.Location = new Point(10, 10);
            this.actionTitleLabel.Size = new Size(100, 25);
            this.actionTitleLabel.ForeColor = Color.Gold;
            this.actionTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Action Buttons
            this.cultivateButton = new Button();
            this.cultivateButton.Text = "Cultivate";
            this.cultivateButton.Location = new Point(20, 50);
            this.cultivateButton.Size = new Size(120, 40);
            this.cultivateButton.BackColor = Color.FromArgb(100, 50, 50);
            this.cultivateButton.ForeColor = Color.White;
            this.cultivateButton.FlatStyle = FlatStyle.Flat;
            this.cultivateButton.Click += new EventHandler(this.CultivateButton_Click);

            this.meditateButton = new Button();
            this.meditateButton.Text = "Meditate";
            this.meditateButton.Location = new Point(150, 50);
            this.meditateButton.Size = new Size(120, 40);
            this.meditateButton.BackColor = Color.FromArgb(50, 100, 50);
            this.meditateButton.ForeColor = Color.White;
            this.meditateButton.FlatStyle = FlatStyle.Flat;
            this.meditateButton.Click += new EventHandler(this.MeditateButton_Click);

            this.breakthroughButton = new Button();
            this.breakthroughButton.Text = "Breakthrough";
            this.breakthroughButton.Location = new Point(20, 100);
            this.breakthroughButton.Size = new Size(250, 40);
            this.breakthroughButton.BackColor = Color.FromArgb(100, 100, 50);
            this.breakthroughButton.ForeColor = Color.White;
            this.breakthroughButton.FlatStyle = FlatStyle.Flat;
            this.breakthroughButton.Click += new EventHandler(this.BreakthroughButton_Click);

            this.sectButton = new Button();
            this.sectButton.Text = "Sect Management";
            this.sectButton.Location = new Point(20, 150);
            this.sectButton.Size = new Size(250, 40);
            this.sectButton.BackColor = Color.FromArgb(50, 50, 100);
            this.sectButton.ForeColor = Color.White;
            this.sectButton.FlatStyle = FlatStyle.Flat;
            this.sectButton.Click += new EventHandler(this.SectButton_Click);

            this.alchemyButton = new Button();
            this.alchemyButton.Text = "Alchemy";
            this.alchemyButton.Location = new Point(20, 200);
            this.alchemyButton.Size = new Size(250, 40);
            this.alchemyButton.BackColor = Color.FromArgb(100, 50, 100);
            this.alchemyButton.ForeColor = Color.White;
            this.alchemyButton.FlatStyle = FlatStyle.Flat;
            this.alchemyButton.Click += new EventHandler(this.AlchemyButton_Click);

            this.missionButton = new Button();
            this.missionButton.Text = "Sect Mission";
            this.missionButton.Location = new Point(20, 250);
            this.missionButton.Size = new Size(250, 40);
            this.missionButton.BackColor = Color.FromArgb(50, 100, 100);
            this.missionButton.ForeColor = Color.White;
            this.missionButton.FlatStyle = FlatStyle.Flat;
            this.missionButton.Click += new EventHandler(this.MissionButton_Click);

            // Inventory Panel
            this.inventoryPanel = new Panel();
            this.inventoryPanel.Location = new Point(340, 240);
            this.inventoryPanel.Size = new Size(300, 400);
            this.inventoryPanel.BackColor = Color.FromArgb(40, 40, 50);
            this.inventoryPanel.BorderStyle = BorderStyle.FixedSingle;

            this.inventoryTitleLabel = new Label();
            this.inventoryTitleLabel.Text = "Inventory";
            this.inventoryTitleLabel.Location = new Point(10, 10);
            this.inventoryTitleLabel.Size = new Size(100, 25);
            this.inventoryTitleLabel.ForeColor = Color.Gold;
            this.inventoryTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            this.inventoryTextBox = new TextBox();
            this.inventoryTextBox.Location = new Point(20, 50);
            this.inventoryTextBox.Size = new Size(260, 330);
            this.inventoryTextBox.Multiline = true;
            this.inventoryTextBox.ScrollBars = ScrollBars.Vertical;
            this.inventoryTextBox.BackColor = Color.FromArgb(30, 30, 40);
            this.inventoryTextBox.ForeColor = Color.LightGray;
            this.inventoryTextBox.ReadOnly = true;

            // Log Panel
            this.logPanel = new Panel();
            this.logPanel.Location = new Point(660, 240);
            this.logPanel.Size = new Size(320, 400);
            this.logPanel.BackColor = Color.FromArgb(40, 40, 50);
            this.logPanel.BorderStyle = BorderStyle.FixedSingle;

            this.logTitleLabel = new Label();
            this.logTitleLabel.Text = "Activity Log";
            this.logTitleLabel.Location = new Point(10, 10);
            this.logTitleLabel.Size = new Size(100, 25);
            this.logTitleLabel.ForeColor = Color.Gold;
            this.logTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            this.logTextBox = new TextBox();
            this.logTextBox.Location = new Point(20, 50);
            this.logTextBox.Size = new Size(280, 330);
            this.logTextBox.Multiline = true;
            this.logTextBox.ScrollBars = ScrollBars.Vertical;
            this.logTextBox.BackColor = Color.FromArgb(30, 30, 40);
            this.logTextBox.ForeColor = Color.LightGray;
            this.logTextBox.ReadOnly = true;

            // Timer
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer.Interval = 1000; // 1 second
            this.gameTimer.Tick += new EventHandler(this.GameTimer_Tick);

            // Add controls to panels
            this.statusPanel.Controls.Add(this.titleLabel);
            this.statusPanel.Controls.Add(this.realmLabel);
            this.statusPanel.Controls.Add(this.sectLabel);
            this.statusPanel.Controls.Add(this.qiLabel);
            this.statusPanel.Controls.Add(this.spiritStonesLabel);
            this.statusPanel.Controls.Add(this.cultivationRateLabel);
            this.statusPanel.Controls.Add(this.progressLabel);
            this.statusPanel.Controls.Add(this.progressBar);
            this.statusPanel.Controls.Add(this.meditationLabel);

            this.actionPanel.Controls.Add(this.actionTitleLabel);
            this.actionPanel.Controls.Add(this.cultivateButton);
            this.actionPanel.Controls.Add(this.meditateButton);
            this.actionPanel.Controls.Add(this.breakthroughButton);
            this.actionPanel.Controls.Add(this.sectButton);
            this.actionPanel.Controls.Add(this.alchemyButton);
            this.actionPanel.Controls.Add(this.missionButton);

            this.inventoryPanel.Controls.Add(this.inventoryTitleLabel);
            this.inventoryPanel.Controls.Add(this.inventoryTextBox);

            this.logPanel.Controls.Add(this.logTitleLabel);
            this.logPanel.Controls.Add(this.logTextBox);

            // Add panels to form
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.inventoryPanel);
            this.Controls.Add(this.logPanel);

            this.ResumeLayout(false);
        }

        private Label titleLabel;
        private Label realmLabel;
        private Label sectLabel;
        private Label qiLabel;
        private Label spiritStonesLabel;
        private Label cultivationRateLabel;
        private Label progressLabel;
        private Label meditationLabel;
        private ProgressBar progressBar;

        private Panel statusPanel;
        private Panel actionPanel;
        private Panel inventoryPanel;
        private Panel logPanel;

        private Label actionTitleLabel;
        private Button cultivateButton;
        private Button meditateButton;
        private Button breakthroughButton;
        private Button sectButton;
        private Button alchemyButton;
        private Button missionButton;

        private Label inventoryTitleLabel;
        private TextBox inventoryTextBox;

        private Label logTitleLabel;
        private TextBox logTextBox;

        private System.Windows.Forms.Timer gameTimer;
    }
}