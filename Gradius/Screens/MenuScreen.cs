using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;
using System.Threading;

namespace Gradius
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                onePlayerCoverLabel.Visible = true;
                this.Refresh();
                Thread.Sleep(150);

                onePlayerCoverLabel.Visible = false;
                this.Refresh();
                Thread.Sleep(150);
            }
            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void scoresButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                twoPlayerCoverLabel.Visible = true;
                this.Refresh();
                Thread.Sleep(200);

                twoPlayerCoverLabel.Visible = false;
                this.Refresh();
                Thread.Sleep(200);
            }

            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Enter(object sender, EventArgs e)
        {
            //start by changing all the buttons to the default colour
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.Black;
                }
               
            }

            //change the current button to the active colour
            Button btn = (Button)sender;
            btn.BackColor = Color.Black;

            if (btn.Text == "1 PLAYER" || btn.Text == "2 PLAYERS")
            {
                pictureBox2.Visible = true;
                pictureBox2.Location = new Point(btn.Location.X - 50, btn.Location.Y);
            }
            else
            {
                pictureBox2.Visible = false;
            }
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            creditsLabel.Text = "TM AND © 1986 \n KONAMI INDUSTRY CO.,LTD. \n LICENSED BY \n NINTENDO OF AMERICA INC.";
        }
    }
}
