namespace Gradius
{
    partial class PauseForm
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
            this.continueButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.mKeyLabel = new System.Windows.Forms.Label();
            this.downArrowLabel = new System.Windows.Forms.Label();
            this.rightArrowLabel = new System.Windows.Forms.Label();
            this.leftArrowLabel = new System.Windows.Forms.Label();
            this.upArrowLabel = new System.Windows.Forms.Label();
            this.upArrowTextLabel = new System.Windows.Forms.Label();
            this.downArrowTextLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.upJoystickTextLabel = new System.Windows.Forms.Label();
            this.downJoystickTextLabel = new System.Windows.Forms.Label();
            this.leftJoystickTextLabel = new System.Windows.Forms.Label();
            this.rightJoystickTextLabel = new System.Windows.Forms.Label();
            this.shootButtonTextLabel = new System.Windows.Forms.Label();
            this.mKeyTextLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.joystickImage = new System.Windows.Forms.PictureBox();
            this.shootImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.joystickImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shootImage)).BeginInit();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.ForeColor = System.Drawing.Color.White;
            this.continueButton.Location = new System.Drawing.Point(11, 391);
            this.continueButton.Margin = new System.Windows.Forms.Padding(2);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(67, 32);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            this.continueButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(447, 391);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(67, 32);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.button_Enter);
            // 
            // mKeyLabel
            // 
            this.mKeyLabel.BackColor = System.Drawing.Color.White;
            this.mKeyLabel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mKeyLabel.ForeColor = System.Drawing.Color.Black;
            this.mKeyLabel.Location = new System.Drawing.Point(115, 153);
            this.mKeyLabel.Name = "mKeyLabel";
            this.mKeyLabel.Size = new System.Drawing.Size(34, 32);
            this.mKeyLabel.TabIndex = 8;
            this.mKeyLabel.Text = "M";
            this.mKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downArrowLabel
            // 
            this.downArrowLabel.BackColor = System.Drawing.Color.White;
            this.downArrowLabel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downArrowLabel.ForeColor = System.Drawing.Color.Black;
            this.downArrowLabel.Location = new System.Drawing.Point(307, 153);
            this.downArrowLabel.Name = "downArrowLabel";
            this.downArrowLabel.Size = new System.Drawing.Size(34, 32);
            this.downArrowLabel.TabIndex = 9;
            this.downArrowLabel.Text = "v";
            this.downArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightArrowLabel
            // 
            this.rightArrowLabel.BackColor = System.Drawing.Color.White;
            this.rightArrowLabel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightArrowLabel.ForeColor = System.Drawing.Color.Black;
            this.rightArrowLabel.Location = new System.Drawing.Point(347, 153);
            this.rightArrowLabel.Name = "rightArrowLabel";
            this.rightArrowLabel.Size = new System.Drawing.Size(34, 32);
            this.rightArrowLabel.TabIndex = 10;
            this.rightArrowLabel.Text = ">";
            this.rightArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftArrowLabel
            // 
            this.leftArrowLabel.BackColor = System.Drawing.Color.White;
            this.leftArrowLabel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftArrowLabel.ForeColor = System.Drawing.Color.Black;
            this.leftArrowLabel.Location = new System.Drawing.Point(267, 153);
            this.leftArrowLabel.Name = "leftArrowLabel";
            this.leftArrowLabel.Size = new System.Drawing.Size(34, 32);
            this.leftArrowLabel.TabIndex = 11;
            this.leftArrowLabel.Text = "<";
            this.leftArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upArrowLabel
            // 
            this.upArrowLabel.BackColor = System.Drawing.Color.White;
            this.upArrowLabel.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upArrowLabel.ForeColor = System.Drawing.Color.Black;
            this.upArrowLabel.Location = new System.Drawing.Point(307, 112);
            this.upArrowLabel.Name = "upArrowLabel";
            this.upArrowLabel.Size = new System.Drawing.Size(34, 32);
            this.upArrowLabel.TabIndex = 12;
            this.upArrowLabel.Text = "^";
            this.upArrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upArrowTextLabel
            // 
            this.upArrowTextLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upArrowTextLabel.Location = new System.Drawing.Point(308, 69);
            this.upArrowTextLabel.Name = "upArrowTextLabel";
            this.upArrowTextLabel.Size = new System.Drawing.Size(33, 32);
            this.upArrowTextLabel.TabIndex = 13;
            this.upArrowTextLabel.Text = "UP";
            this.upArrowTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downArrowTextLabel
            // 
            this.downArrowTextLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downArrowTextLabel.Location = new System.Drawing.Point(289, 194);
            this.downArrowTextLabel.Name = "downArrowTextLabel";
            this.downArrowTextLabel.Size = new System.Drawing.Size(73, 32);
            this.downArrowTextLabel.TabIndex = 14;
            this.downArrowTextLabel.Text = "DOWN";
            this.downArrowTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "LEFT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(398, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "RIGHT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upJoystickTextLabel
            // 
            this.upJoystickTextLabel.Location = new System.Drawing.Point(308, 226);
            this.upJoystickTextLabel.Name = "upJoystickTextLabel";
            this.upJoystickTextLabel.Size = new System.Drawing.Size(33, 32);
            this.upJoystickTextLabel.TabIndex = 17;
            this.upJoystickTextLabel.Text = "UP";
            this.upJoystickTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downJoystickTextLabel
            // 
            this.downJoystickTextLabel.Location = new System.Drawing.Point(289, 337);
            this.downJoystickTextLabel.Name = "downJoystickTextLabel";
            this.downJoystickTextLabel.Size = new System.Drawing.Size(73, 32);
            this.downJoystickTextLabel.TabIndex = 18;
            this.downJoystickTextLabel.Text = "DOWN";
            this.downJoystickTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftJoystickTextLabel
            // 
            this.leftJoystickTextLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftJoystickTextLabel.Location = new System.Drawing.Point(215, 302);
            this.leftJoystickTextLabel.Name = "leftJoystickTextLabel";
            this.leftJoystickTextLabel.Size = new System.Drawing.Size(33, 32);
            this.leftJoystickTextLabel.TabIndex = 19;
            this.leftJoystickTextLabel.Text = "LEFT";
            this.leftJoystickTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightJoystickTextLabel
            // 
            this.rightJoystickTextLabel.Location = new System.Drawing.Point(398, 302);
            this.rightJoystickTextLabel.Name = "rightJoystickTextLabel";
            this.rightJoystickTextLabel.Size = new System.Drawing.Size(51, 32);
            this.rightJoystickTextLabel.TabIndex = 20;
            this.rightJoystickTextLabel.Text = "RIGHT";
            this.rightJoystickTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shootButtonTextLabel
            // 
            this.shootButtonTextLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shootButtonTextLabel.Location = new System.Drawing.Point(96, 258);
            this.shootButtonTextLabel.Name = "shootButtonTextLabel";
            this.shootButtonTextLabel.Size = new System.Drawing.Size(75, 32);
            this.shootButtonTextLabel.TabIndex = 21;
            this.shootButtonTextLabel.Text = "SHOOT";
            this.shootButtonTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mKeyTextLabel
            // 
            this.mKeyTextLabel.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mKeyTextLabel.Location = new System.Drawing.Point(96, 112);
            this.mKeyTextLabel.Name = "mKeyTextLabel";
            this.mKeyTextLabel.Size = new System.Drawing.Size(75, 32);
            this.mKeyTextLabel.TabIndex = 22;
            this.mKeyTextLabel.Text = "SHOOT";
            this.mKeyTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "CONTROLS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // joystickImage
            // 
            this.joystickImage.Image = global::Gradius.Properties.Resources.Red_circle;
            this.joystickImage.Location = new System.Drawing.Point(290, 271);
            this.joystickImage.Name = "joystickImage";
            this.joystickImage.Size = new System.Drawing.Size(70, 63);
            this.joystickImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.joystickImage.TabIndex = 7;
            this.joystickImage.TabStop = false;
            // 
            // shootImage
            // 
            this.shootImage.Image = global::Gradius.Properties.Resources.red_50x50;
            this.shootImage.Location = new System.Drawing.Point(114, 302);
            this.shootImage.Name = "shootImage";
            this.shootImage.Size = new System.Drawing.Size(35, 32);
            this.shootImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.shootImage.TabIndex = 2;
            this.shootImage.TabStop = false;
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(525, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mKeyTextLabel);
            this.Controls.Add(this.shootButtonTextLabel);
            this.Controls.Add(this.rightJoystickTextLabel);
            this.Controls.Add(this.leftJoystickTextLabel);
            this.Controls.Add(this.downJoystickTextLabel);
            this.Controls.Add(this.upJoystickTextLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downArrowTextLabel);
            this.Controls.Add(this.upArrowTextLabel);
            this.Controls.Add(this.upArrowLabel);
            this.Controls.Add(this.leftArrowLabel);
            this.Controls.Add(this.rightArrowLabel);
            this.Controls.Add(this.downArrowLabel);
            this.Controls.Add(this.mKeyLabel);
            this.Controls.Add(this.joystickImage);
            this.Controls.Add(this.shootImage);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.continueButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PauseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseForm";
            ((System.ComponentModel.ISupportInitialize)(this.joystickImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shootImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox shootImage;
        private System.Windows.Forms.PictureBox joystickImage;
        private System.Windows.Forms.Label mKeyLabel;
        private System.Windows.Forms.Label downArrowLabel;
        private System.Windows.Forms.Label rightArrowLabel;
        private System.Windows.Forms.Label leftArrowLabel;
        private System.Windows.Forms.Label upArrowLabel;
        private System.Windows.Forms.Label upArrowTextLabel;
        private System.Windows.Forms.Label downArrowTextLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label upJoystickTextLabel;
        private System.Windows.Forms.Label downJoystickTextLabel;
        private System.Windows.Forms.Label leftJoystickTextLabel;
        private System.Windows.Forms.Label rightJoystickTextLabel;
        private System.Windows.Forms.Label shootButtonTextLabel;
        private System.Windows.Forms.Label mKeyTextLabel;
        private System.Windows.Forms.Label label3;
    }
}