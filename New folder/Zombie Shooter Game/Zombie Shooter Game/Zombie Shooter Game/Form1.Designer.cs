namespace Zombie_Shooter_Game
{
    partial class Form1
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
            this.textAmmo = new System.Windows.Forms.Label();
            this.textScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // textAmmo
            // 
            this.textAmmo.AutoSize = true;
            this.textAmmo.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAmmo.ForeColor = System.Drawing.Color.White;
            this.textAmmo.Location = new System.Drawing.Point(12, 33);
            this.textAmmo.Name = "textAmmo";
            this.textAmmo.Size = new System.Drawing.Size(125, 29);
            this.textAmmo.TabIndex = 0;
            this.textAmmo.Text = "Ammo=0";
            // 
            // textScore
            // 
            this.textScore.AutoSize = true;
            this.textScore.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textScore.ForeColor = System.Drawing.Color.White;
            this.textScore.Location = new System.Drawing.Point(360, 33);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(84, 29);
            this.textScore.TabIndex = 0;
            this.textScore.Text = "kills:0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(559, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Health";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(672, 33);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(227, 23);
            this.healthBar.TabIndex = 1;
            this.healthBar.Value = 100;
            // 
            // player
            // 
            this.player.Image = global::Zombie_Shooter_Game.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(394, 531);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(922, 653);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textScore);
            this.Controls.Add(this.textAmmo);
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textAmmo;
        private System.Windows.Forms.Label textScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
    }
}

