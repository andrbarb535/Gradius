namespace Gradius
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.speedUpLabel = new System.Windows.Forms.Label();
            this.speedUpBoarderLabel = new System.Windows.Forms.Label();
            this.missileLabel = new System.Windows.Forms.Label();
            this.missileBoarderLabel = new System.Windows.Forms.Label();
            this.doubleLabel = new System.Windows.Forms.Label();
            this.doubleBoarderLabel = new System.Windows.Forms.Label();
            this.laserLabel = new System.Windows.Forms.Label();
            this.laserBoarderLabel = new System.Windows.Forms.Label();
            this.optionLabel = new System.Windows.Forms.Label();
            this.optionBoarderLabel = new System.Windows.Forms.Label();
            this.questionMarkLabel = new System.Windows.Forms.Label();
            this.questionMarkBoarderLabel = new System.Windows.Forms.Label();
            this.heroLivesLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.hiLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // speedUpLabel
            // 
            this.speedUpLabel.BackColor = System.Drawing.Color.Blue;
            this.speedUpLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedUpLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedUpLabel.ForeColor = System.Drawing.Color.Black;
            this.speedUpLabel.Location = new System.Drawing.Point(11, 279);
            this.speedUpLabel.Name = "speedUpLabel";
            this.speedUpLabel.Size = new System.Drawing.Size(60, 15);
            this.speedUpLabel.TabIndex = 0;
            this.speedUpLabel.Text = "SPEED UP";
            this.speedUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedUpBoarderLabel
            // 
            this.speedUpBoarderLabel.BackColor = System.Drawing.Color.White;
            this.speedUpBoarderLabel.Enabled = false;
            this.speedUpBoarderLabel.Location = new System.Drawing.Point(10, 278);
            this.speedUpBoarderLabel.Name = "speedUpBoarderLabel";
            this.speedUpBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.speedUpBoarderLabel.TabIndex = 1;
            // 
            // missileLabel
            // 
            this.missileLabel.BackColor = System.Drawing.Color.Blue;
            this.missileLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.missileLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missileLabel.ForeColor = System.Drawing.Color.Black;
            this.missileLabel.Location = new System.Drawing.Point(81, 279);
            this.missileLabel.Name = "missileLabel";
            this.missileLabel.Size = new System.Drawing.Size(60, 15);
            this.missileLabel.TabIndex = 2;
            this.missileLabel.Text = "MISSILE";
            this.missileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // missileBoarderLabel
            // 
            this.missileBoarderLabel.BackColor = System.Drawing.Color.White;
            this.missileBoarderLabel.Enabled = false;
            this.missileBoarderLabel.Location = new System.Drawing.Point(80, 278);
            this.missileBoarderLabel.Name = "missileBoarderLabel";
            this.missileBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.missileBoarderLabel.TabIndex = 3;
            // 
            // doubleLabel
            // 
            this.doubleLabel.BackColor = System.Drawing.Color.Blue;
            this.doubleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doubleLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doubleLabel.ForeColor = System.Drawing.Color.Black;
            this.doubleLabel.Location = new System.Drawing.Point(151, 279);
            this.doubleLabel.Name = "doubleLabel";
            this.doubleLabel.Size = new System.Drawing.Size(60, 15);
            this.doubleLabel.TabIndex = 4;
            this.doubleLabel.Text = "DOUBLE";
            this.doubleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBoarderLabel
            // 
            this.doubleBoarderLabel.BackColor = System.Drawing.Color.White;
            this.doubleBoarderLabel.Enabled = false;
            this.doubleBoarderLabel.Location = new System.Drawing.Point(150, 278);
            this.doubleBoarderLabel.Name = "doubleBoarderLabel";
            this.doubleBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.doubleBoarderLabel.TabIndex = 5;
            // 
            // laserLabel
            // 
            this.laserLabel.BackColor = System.Drawing.Color.Blue;
            this.laserLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laserLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserLabel.ForeColor = System.Drawing.Color.Black;
            this.laserLabel.Location = new System.Drawing.Point(221, 279);
            this.laserLabel.Name = "laserLabel";
            this.laserLabel.Size = new System.Drawing.Size(60, 15);
            this.laserLabel.TabIndex = 6;
            this.laserLabel.Text = "LASER";
            this.laserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laserBoarderLabel
            // 
            this.laserBoarderLabel.BackColor = System.Drawing.Color.White;
            this.laserBoarderLabel.Enabled = false;
            this.laserBoarderLabel.Location = new System.Drawing.Point(220, 278);
            this.laserBoarderLabel.Name = "laserBoarderLabel";
            this.laserBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.laserBoarderLabel.TabIndex = 7;
            // 
            // optionLabel
            // 
            this.optionLabel.BackColor = System.Drawing.Color.Blue;
            this.optionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionLabel.ForeColor = System.Drawing.Color.Black;
            this.optionLabel.Location = new System.Drawing.Point(291, 279);
            this.optionLabel.Name = "optionLabel";
            this.optionLabel.Size = new System.Drawing.Size(60, 15);
            this.optionLabel.TabIndex = 8;
            this.optionLabel.Text = "OPTION";
            this.optionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optionBoarderLabel
            // 
            this.optionBoarderLabel.BackColor = System.Drawing.Color.White;
            this.optionBoarderLabel.Enabled = false;
            this.optionBoarderLabel.Location = new System.Drawing.Point(290, 278);
            this.optionBoarderLabel.Name = "optionBoarderLabel";
            this.optionBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.optionBoarderLabel.TabIndex = 9;
            // 
            // questionMarkLabel
            // 
            this.questionMarkLabel.BackColor = System.Drawing.Color.Blue;
            this.questionMarkLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.questionMarkLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionMarkLabel.ForeColor = System.Drawing.Color.Black;
            this.questionMarkLabel.Location = new System.Drawing.Point(361, 279);
            this.questionMarkLabel.Name = "questionMarkLabel";
            this.questionMarkLabel.Size = new System.Drawing.Size(60, 15);
            this.questionMarkLabel.TabIndex = 10;
            this.questionMarkLabel.Text = "?";
            this.questionMarkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionMarkBoarderLabel
            // 
            this.questionMarkBoarderLabel.BackColor = System.Drawing.Color.White;
            this.questionMarkBoarderLabel.Enabled = false;
            this.questionMarkBoarderLabel.Location = new System.Drawing.Point(360, 278);
            this.questionMarkBoarderLabel.Name = "questionMarkBoarderLabel";
            this.questionMarkBoarderLabel.Size = new System.Drawing.Size(62, 17);
            this.questionMarkBoarderLabel.TabIndex = 11;
            // 
            // heroLivesLabel
            // 
            this.heroLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroLivesLabel.Enabled = false;
            this.heroLivesLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heroLivesLabel.ForeColor = System.Drawing.Color.White;
            this.heroLivesLabel.Location = new System.Drawing.Point(10, 305);
            this.heroLivesLabel.Name = "heroLivesLabel";
            this.heroLivesLabel.Size = new System.Drawing.Size(62, 17);
            this.heroLivesLabel.TabIndex = 12;
            this.heroLivesLabel.Text = "3";
            this.heroLivesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerLabel
            // 
            this.playerLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerLabel.Enabled = false;
            this.playerLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.White;
            this.playerLabel.Location = new System.Drawing.Point(80, 305);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(62, 17);
            this.playerLabel.TabIndex = 13;
            this.playerLabel.Text = "1P";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Enabled = false;
            this.scoreLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(150, 305);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(62, 17);
            this.scoreLabel.TabIndex = 14;
            this.scoreLabel.Text = "0000000";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hiLabel
            // 
            this.hiLabel.BackColor = System.Drawing.Color.Transparent;
            this.hiLabel.Enabled = false;
            this.hiLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiLabel.ForeColor = System.Drawing.Color.White;
            this.hiLabel.Location = new System.Drawing.Point(290, 305);
            this.hiLabel.Name = "hiLabel";
            this.hiLabel.Size = new System.Drawing.Size(62, 17);
            this.hiLabel.TabIndex = 15;
            this.hiLabel.Text = "HI";
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.highscoreLabel.Enabled = false;
            this.highscoreLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.ForeColor = System.Drawing.Color.White;
            this.highscoreLabel.Location = new System.Drawing.Point(360, 305);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(62, 17);
            this.highscoreLabel.TabIndex = 16;
            this.highscoreLabel.Text = "0000000";
            this.highscoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.hiLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.heroLivesLabel);
            this.Controls.Add(this.doubleLabel);
            this.Controls.Add(this.doubleBoarderLabel);
            this.Controls.Add(this.laserLabel);
            this.Controls.Add(this.laserBoarderLabel);
            this.Controls.Add(this.optionLabel);
            this.Controls.Add(this.optionBoarderLabel);
            this.Controls.Add(this.questionMarkLabel);
            this.Controls.Add(this.questionMarkBoarderLabel);
            this.Controls.Add(this.missileLabel);
            this.Controls.Add(this.missileBoarderLabel);
            this.Controls.Add(this.speedUpLabel);
            this.Controls.Add(this.speedUpBoarderLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(500, 375);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label speedUpLabel;
        private System.Windows.Forms.Label speedUpBoarderLabel;
        private System.Windows.Forms.Label missileLabel;
        private System.Windows.Forms.Label missileBoarderLabel;
        private System.Windows.Forms.Label doubleLabel;
        private System.Windows.Forms.Label doubleBoarderLabel;
        private System.Windows.Forms.Label laserLabel;
        private System.Windows.Forms.Label laserBoarderLabel;
        private System.Windows.Forms.Label optionLabel;
        private System.Windows.Forms.Label optionBoarderLabel;
        private System.Windows.Forms.Label questionMarkLabel;
        private System.Windows.Forms.Label questionMarkBoarderLabel;
        private System.Windows.Forms.Label heroLivesLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label hiLabel;
        private System.Windows.Forms.Label highscoreLabel;
    }
}
