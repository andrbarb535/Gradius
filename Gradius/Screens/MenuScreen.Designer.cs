namespace Gradius
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button onePlayerButton;
            this.twoPlayerButton = new System.Windows.Forms.Button();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playLabel = new System.Windows.Forms.Label();
            this.selectLabel = new System.Windows.Forms.Label();
            this.onePlayerCoverLabel = new System.Windows.Forms.Label();
            this.twoPlayerCoverLabel = new System.Windows.Forms.Label();
            onePlayerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            onePlayerButton.BackColor = System.Drawing.Color.Transparent;
            onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            onePlayerButton.FlatAppearance.BorderSize = 0;
            onePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            onePlayerButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            onePlayerButton.ForeColor = System.Drawing.Color.White;
            onePlayerButton.Location = new System.Drawing.Point(119, 117);
            onePlayerButton.Margin = new System.Windows.Forms.Padding(2);
            onePlayerButton.Name = "onePlayerButton";
            onePlayerButton.Size = new System.Drawing.Size(70, 20);
            onePlayerButton.TabIndex = 1;
            onePlayerButton.Tag = "GameScreen";
            onePlayerButton.Text = "1 PLAYER";
            onePlayerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            onePlayerButton.UseVisualStyleBackColor = false;
            onePlayerButton.Click += new System.EventHandler(this.playButton_Click);
            onePlayerButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.BackColor = System.Drawing.Color.Black;
            this.twoPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.twoPlayerButton.FlatAppearance.BorderSize = 0;
            this.twoPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayerButton.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.ForeColor = System.Drawing.Color.White;
            this.twoPlayerButton.Location = new System.Drawing.Point(119, 141);
            this.twoPlayerButton.Margin = new System.Windows.Forms.Padding(2);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(70, 20);
            this.twoPlayerButton.TabIndex = 2;
            this.twoPlayerButton.Text = "2 PLAYERS";
            this.twoPlayerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.scoresButton_Click);
            this.twoPlayerButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // creditsLabel
            // 
            this.creditsLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsLabel.ForeColor = System.Drawing.Color.White;
            this.creditsLabel.Location = new System.Drawing.Point(17, 174);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(259, 72);
            this.creditsLabel.TabIndex = 7;
            this.creditsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::Gradius.Properties.Resources.Vic_Viper;
            this.pictureBox2.Location = new System.Drawing.Point(74, 118);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gradius.Properties.Resources.Gradius_Title;
            this.pictureBox1.Location = new System.Drawing.Point(20, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // playLabel
            // 
            this.playLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.Color.White;
            this.playLabel.Location = new System.Drawing.Point(99, 91);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(38, 17);
            this.playLabel.TabIndex = 9;
            this.playLabel.Text = "PLAY";
            this.playLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectLabel
            // 
            this.selectLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLabel.ForeColor = System.Drawing.Color.White;
            this.selectLabel.Location = new System.Drawing.Point(154, 91);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(51, 17);
            this.selectLabel.TabIndex = 10;
            this.selectLabel.Text = "SELECT";
            this.selectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // onePlayerCoverLabel
            // 
            this.onePlayerCoverLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerCoverLabel.Location = new System.Drawing.Point(120, 118);
            this.onePlayerCoverLabel.Name = "onePlayerCoverLabel";
            this.onePlayerCoverLabel.Size = new System.Drawing.Size(69, 19);
            this.onePlayerCoverLabel.TabIndex = 11;
            this.onePlayerCoverLabel.Visible = false;
            // 
            // twoPlayerCoverLabel
            // 
            this.twoPlayerCoverLabel.Location = new System.Drawing.Point(116, 137);
            this.twoPlayerCoverLabel.Name = "twoPlayerCoverLabel";
            this.twoPlayerCoverLabel.Size = new System.Drawing.Size(69, 19);
            this.twoPlayerCoverLabel.TabIndex = 12;
            this.twoPlayerCoverLabel.Visible = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.twoPlayerCoverLabel);
            this.Controls.Add(this.onePlayerCoverLabel);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(onePlayerButton);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(294, 264);
            this.Load += new System.EventHandler(this.MenuScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        protected internal System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Label onePlayerCoverLabel;
        private System.Windows.Forms.Label twoPlayerCoverLabel;
    }
}
