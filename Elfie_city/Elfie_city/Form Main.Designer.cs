namespace Elfie_city
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxBackgroundElfieCity = new System.Windows.Forms.PictureBox();
            this.timerCounter = new System.Windows.Forms.Timer(this.components);
            this.labelResourcesWood = new System.Windows.Forms.Label();
            this.labelResourcesStone = new System.Windows.Forms.Label();
            this.labelResourcesCrystals = new System.Windows.Forms.Label();
            this.labelResourcesIron = new System.Windows.Forms.Label();
            this.labelResourcesFood = new System.Windows.Forms.Label();
            this.labelFood = new System.Windows.Forms.Label();
            this.labelWood = new System.Windows.Forms.Label();
            this.labelStone = new System.Windows.Forms.Label();
            this.labelCrystals = new System.Windows.Forms.Label();
            this.labelIron = new System.Windows.Forms.Label();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.labelResourcesPopulation = new System.Windows.Forms.Label();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.timerOrcsAttack = new System.Windows.Forms.Timer(this.components);
            this.timerWarnings = new System.Windows.Forms.Timer(this.components);
            this.timerCheckIfDefeat = new System.Windows.Forms.Timer(this.components);
            this.timerCrystalsProduction = new System.Windows.Forms.Timer(this.components);
            this.timerRatAttack = new System.Windows.Forms.Timer(this.components);
            this.timerAccidents = new System.Windows.Forms.Timer(this.components);
            this.timerFireInWarehouse = new System.Windows.Forms.Timer(this.components);
            this.buttonMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundElfieCity)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBoxBackgroundElfieCity
            // 
            this.pictureBoxBackgroundElfieCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackgroundElfieCity.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackgroundElfieCity.MaximumSize = new System.Drawing.Size(1038, 554);
            this.pictureBoxBackgroundElfieCity.MinimumSize = new System.Drawing.Size(1038, 554);
            this.pictureBoxBackgroundElfieCity.Name = "pictureBoxBackgroundElfieCity";
            this.pictureBoxBackgroundElfieCity.Size = new System.Drawing.Size(1038, 554);
            this.pictureBoxBackgroundElfieCity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBackgroundElfieCity.TabIndex = 0;
            this.pictureBoxBackgroundElfieCity.TabStop = false;
            // 
            // timerCounter
            // 
            this.timerCounter.Tick += new System.EventHandler(this.timerProduction_Tick);
            // 
            // labelResourcesWood
            // 
            this.labelResourcesWood.AutoSize = true;
            this.labelResourcesWood.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesWood.Location = new System.Drawing.Point(96, 30);
            this.labelResourcesWood.Name = "labelResourcesWood";
            this.labelResourcesWood.Size = new System.Drawing.Size(19, 21);
            this.labelResourcesWood.TabIndex = 1;
            this.labelResourcesWood.Text = "0";
            // 
            // labelResourcesStone
            // 
            this.labelResourcesStone.AutoSize = true;
            this.labelResourcesStone.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesStone.Location = new System.Drawing.Point(96, 51);
            this.labelResourcesStone.Name = "labelResourcesStone";
            this.labelResourcesStone.Size = new System.Drawing.Size(19, 21);
            this.labelResourcesStone.TabIndex = 2;
            this.labelResourcesStone.Text = "0";
            // 
            // labelResourcesCrystals
            // 
            this.labelResourcesCrystals.AutoSize = true;
            this.labelResourcesCrystals.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesCrystals.Location = new System.Drawing.Point(96, 72);
            this.labelResourcesCrystals.Name = "labelResourcesCrystals";
            this.labelResourcesCrystals.Size = new System.Drawing.Size(19, 21);
            this.labelResourcesCrystals.TabIndex = 3;
            this.labelResourcesCrystals.Text = "0";
            // 
            // labelResourcesIron
            // 
            this.labelResourcesIron.AutoSize = true;
            this.labelResourcesIron.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesIron.Location = new System.Drawing.Point(96, 93);
            this.labelResourcesIron.Name = "labelResourcesIron";
            this.labelResourcesIron.Size = new System.Drawing.Size(19, 21);
            this.labelResourcesIron.TabIndex = 4;
            this.labelResourcesIron.Text = "0";
            // 
            // labelResourcesFood
            // 
            this.labelResourcesFood.AutoSize = true;
            this.labelResourcesFood.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesFood.Location = new System.Drawing.Point(96, 9);
            this.labelResourcesFood.Name = "labelResourcesFood";
            this.labelResourcesFood.Size = new System.Drawing.Size(37, 21);
            this.labelResourcesFood.TabIndex = 5;
            this.labelResourcesFood.Text = "100";
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelFood.Location = new System.Drawing.Point(12, 9);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(83, 21);
            this.labelFood.TabIndex = 6;
            this.labelFood.Text = "Żywność:";
            // 
            // labelWood
            // 
            this.labelWood.AutoSize = true;
            this.labelWood.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelWood.Location = new System.Drawing.Point(12, 30);
            this.labelWood.Name = "labelWood";
            this.labelWood.Size = new System.Drawing.Size(78, 21);
            this.labelWood.TabIndex = 7;
            this.labelWood.Text = "Drewno: ";
            // 
            // labelStone
            // 
            this.labelStone.AutoSize = true;
            this.labelStone.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelStone.Location = new System.Drawing.Point(12, 51);
            this.labelStone.Name = "labelStone";
            this.labelStone.Size = new System.Drawing.Size(75, 21);
            this.labelStone.TabIndex = 8;
            this.labelStone.Text = "Kamień: ";
            // 
            // labelCrystals
            // 
            this.labelCrystals.AutoSize = true;
            this.labelCrystals.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelCrystals.Location = new System.Drawing.Point(12, 72);
            this.labelCrystals.Name = "labelCrystals";
            this.labelCrystals.Size = new System.Drawing.Size(84, 21);
            this.labelCrystals.TabIndex = 9;
            this.labelCrystals.Text = "Kryształy:";
            // 
            // labelIron
            // 
            this.labelIron.AutoSize = true;
            this.labelIron.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelIron.Location = new System.Drawing.Point(12, 93);
            this.labelIron.Name = "labelIron";
            this.labelIron.Size = new System.Drawing.Size(63, 21);
            this.labelIron.TabIndex = 10;
            this.labelIron.Text = "Żelazo:";
            // 
            // labelPopulation
            // 
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelPopulation.Location = new System.Drawing.Point(12, 114);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Size = new System.Drawing.Size(87, 21);
            this.labelPopulation.TabIndex = 11;
            this.labelPopulation.Text = "Populacja:";
            // 
            // labelResourcesPopulation
            // 
            this.labelResourcesPopulation.AutoSize = true;
            this.labelResourcesPopulation.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelResourcesPopulation.Location = new System.Drawing.Point(96, 114);
            this.labelResourcesPopulation.Name = "labelResourcesPopulation";
            this.labelResourcesPopulation.Size = new System.Drawing.Size(28, 21);
            this.labelResourcesPopulation.TabIndex = 12;
            this.labelResourcesPopulation.Text = "10";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonBuild.Location = new System.Drawing.Point(16, 504);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(115, 38);
            this.buttonBuild.TabIndex = 13;
            this.buttonBuild.Text = "Buduj";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonTraining.Location = new System.Drawing.Point(137, 504);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(115, 38);
            this.buttonTraining.TabIndex = 14;
            this.buttonTraining.Text = "Szkól";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // timerOrcsAttack
            // 
            this.timerOrcsAttack.Tick += new System.EventHandler(this.timerOrcsAttack_Tick);
            // 
            // timerWarnings
            // 
            this.timerWarnings.Tick += new System.EventHandler(this.timerWarnings_Tick);
            // 
            // timerCheckIfDefeat
            // 
            this.timerCheckIfDefeat.Tick += new System.EventHandler(this.timerCheckIfDefeat_Tick);
            // 
            // timerCrystalsProduction
            // 
            this.timerCrystalsProduction.Tick += new System.EventHandler(this.timerCrystalsProduction_Tick);
            // 
            // timerRatAttack
            // 
            this.timerRatAttack.Tick += new System.EventHandler(this.timerRatAttack_Tick);
            // 
            // timerAccidents
            // 
            this.timerAccidents.Tick += new System.EventHandler(this.timerAccidents_Tick);
            // 
            // timerFireInWarehouse
            // 
            this.timerFireInWarehouse.Tick += new System.EventHandler(this.timerFireInWarehouse_Tick);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonMenu.Location = new System.Drawing.Point(911, 9);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(115, 38);
            this.buttonMenu.TabIndex = 15;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1038, 554);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonTraining);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.labelResourcesPopulation);
            this.Controls.Add(this.labelPopulation);
            this.Controls.Add(this.labelIron);
            this.Controls.Add(this.labelCrystals);
            this.Controls.Add(this.labelStone);
            this.Controls.Add(this.labelWood);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.labelResourcesFood);
            this.Controls.Add(this.labelResourcesIron);
            this.Controls.Add(this.labelResourcesCrystals);
            this.Controls.Add(this.labelResourcesStone);
            this.Controls.Add(this.labelResourcesWood);
            this.Controls.Add(this.pictureBoxBackgroundElfieCity);
            this.MaximumSize = new System.Drawing.Size(1054, 593);
            this.MinimumSize = new System.Drawing.Size(1054, 593);
            this.Name = "FormMain";
            this.Text = "Elfie city";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgroundElfieCity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxBackgroundElfieCity;
        private System.Windows.Forms.Timer timerCounter;
        private System.Windows.Forms.Label labelResourcesWood;
        private System.Windows.Forms.Label labelResourcesStone;
        private System.Windows.Forms.Label labelResourcesCrystals;
        private System.Windows.Forms.Label labelResourcesIron;
        private System.Windows.Forms.Label labelResourcesFood;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Label labelWood;
        private System.Windows.Forms.Label labelStone;
        private System.Windows.Forms.Label labelCrystals;
        private System.Windows.Forms.Label labelIron;
        private System.Windows.Forms.Label labelPopulation;
        private System.Windows.Forms.Label labelResourcesPopulation;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Timer timerOrcsAttack;
        private System.Windows.Forms.Timer timerWarnings;
        private System.Windows.Forms.Timer timerCheckIfDefeat;
        private System.Windows.Forms.Timer timerCrystalsProduction;
        private System.Windows.Forms.Timer timerRatAttack;
        private System.Windows.Forms.Timer timerAccidents;
        private System.Windows.Forms.Timer timerFireInWarehouse;
        private System.Windows.Forms.Button buttonMenu;
    }
}

