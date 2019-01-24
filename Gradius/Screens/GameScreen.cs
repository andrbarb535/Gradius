///Date:       2019-01-25
///Game Title: GRADIUS
///Created By: Andrew Barber

///<summary>
///Program Summary
///A recreation of the classic nintendo game Gradius will be made for the PC which retains much of the look and feel of the original.
///Program Outline
///Gradius is a side-scrolling shooter video game.In the game, the player controls a ship known as the Vic Viper.Players pilot the Vic Viper through several stages, shooting and dodging through deadly obstacles, while using various power-ups, including missiles, lasers, options and shields.The objective is to score the most points while surviving through all stages, and defeat all enemies. This version will retain the charm and feel of the original arcade classic by using similar graphics and sounds.
///Unique Selling Points
///Players will be able to play a one or two person game
///Power ups will be available for unique gameplay
///Classic feel of original game retained through use or retro graphics and sounds
///A point system is used to track each players points for scoring purposes
///Leader boards will track a players win loss records and scores
///Similar Competitive Products
///Scramble, Gradius(The Original), Salamander, Nemesis, Parodius, Otomedius
///</summary>

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
    public partial class GameScreen : UserControl
    {
        Graphics g;

        //GLOBAL VARIABLES 

        //player1 button control keys - DO NOT CHANGE 
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        int screenLength, screenHeight;

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed;
        SolidBrush heroBrush = new SolidBrush(Color.White);

        //vic viper heroOrientation
        string heroOrientation = "Upright";
        int heroDestroyedCounter = 0;
        int heroLives = 3;

        //fans orientation
        string fanOrientation = "Cross Explosion";
        int fanOrientationCounter = 0;

        //star list
        List<Point> starPoints = new List<Point>();
        int starCounter = 0;

        //bullet list
        int bulletCounter = 0;
        List<Rectangle> bulletRectangles = new List<Rectangle>();

        //fans list
        int fanCounter = 0;
        List<Rectangle> fanRectangles = new List<Rectangle>();

        //random generators
        Random starYGen = new Random();
        Random starXGen = new Random();
        Random fanYGen = new Random();

        //movement speeds
        int starSpeed = 4;
        int bulletSpeed = 20;
        int fanSpeed = 6;

        //star dimensions
        byte starH = 2;
        byte starW = 2;

        //pens
        Pen blackPen = new Pen(Color.Black, 2);
        Pen whitePen = new Pen(Color.White, 2);
        Pen redPen = new Pen(Color.Red, 2);
        Pen darkOrangePen = new Pen(Color.DarkOrange, 2);
        Pen yellowPen = new Pen(Color.Yellow, 2);
        Pen aquaPen = new Pen(Color.Aqua, 2);
        Pen bluePen = new Pen(Color.Blue, 2);
        Pen darkBluePen = new Pen(Color.DarkBlue, 2);

        Pen heroPen = new Pen(Color.Aqua, 2);

        SolidBrush starBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush transparentBrush = new SolidBrush(Color.Transparent);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
            g = CreateGraphics();
        }

        public void InitializeGameValues()
        {
            ///setup all initial game values here. Use this method
            ///each time you restart your game to reset all values.
            gameTimer.Enabled = true;

            heroX = this.Width / 7;
            heroY = this.Height / 2;
            heroSize = 13;
            heroSpeed = 8;

            heroLivesLabel.Text = heroLives + "";

            //randomly generate stars
            for (int i = 0; i < 30; i++)
            {
                int starYValue = starYGen.Next(0, this.Height - heroSize / 2 * 2 - 17 * 3);
                int starXValue = starYGen.Next(0, this.Width);

                starPoints.Add(new Point(starXValue + starXGen.Next(0, 10), starYValue));
            }

            //power up labels

            speedUpBoarderLabel.Location = new Point(this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            speedUpLabel.Location = new Point(this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            missileBoarderLabel.Location = new Point(2 * this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            missileLabel.Location = new Point(2 * this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            doubleBoarderLabel.Location = new Point(3 * this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            doubleLabel.Location = new Point(3 * this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            laserBoarderLabel.Location = new Point(4 * this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            laserLabel.Location = new Point(4 * this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            optionBoarderLabel.Location = new Point(5 * this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            optionLabel.Location = new Point(5 * this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            questionMarkBoarderLabel.Location = new Point(6 * this.Width / 7 - 62 / 2, this.Height - 17 * 3);
            questionMarkLabel.Location = new Point(6 * this.Width / 7 - speedUpLabel.Width / 2, this.Height - speedUpLabel.Height * 3 - 1 * 5);

            //record labels

            heroLivesLabel.Location = new Point(this.Width / 7 - 62 / 2, this.Height - 17 * 2);

            playerLabel.Location = new Point(2 * this.Width / 7 - 62 / 2, this.Height - 17 * 2);

            scoreLabel.Location = new Point(3 * this.Width / 7 - 62 / 2, this.Height - 17 * 2);

            hiLabel.Location = new Point(5 * this.Width / 7 - 62 / 2, this.Height - 17 * 2);

            highscoreLabel.Location = new Point(6 * this.Width / 7 - 62 / 2, this.Height - 17 * 2);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ///opens a pause screen is escape is pressed. Depending on what is pressed
            ///on pause screen the program will either continue or exit to main menu

            //pause screen
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = mDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }
            else if (e.KeyCode == Keys.C)
                Application.Exit();

            ///basic player 1 key down bools set below
            ///required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.M:
                    spaceDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    heroOrientation = "Up";
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    heroOrientation = "Down";
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            ///basic player 1 key up bools set below. Add remainging key up
            ///required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.M:
                    spaceDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }

            //hero orientation
            if (upArrowDown == false && downArrowDown == false)
            {
                heroOrientation = "Upright";
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //SET POINTS

            //set star points

            starCounter++;

            int starYValue = starYGen.Next(0, this.Height - heroSize / 2 * 2 - 17 * 3);
            int starXValue = starXGen.Next(0, this.Width);
            int newStarXValue = this.Width + starXGen.Next(0, 10);

            if (starCounter == 3)
            {
                starPoints.Add(new Point(newStarXValue, starYValue));
                starCounter = 0;
            }

            //set bullet rectangles

            bulletCounter++;

            int bulletYValue = heroY + 2;
            int bulletXValue = heroX + 50;

            if (bulletCounter >= 10 && spaceDown == true)
            {
                bulletRectangles.Add(new Rectangle(bulletXValue, bulletYValue, 16, 8));
                bulletCounter = 0;
            }

            //set fan rectangles

            fanCounter++;

            int fanYValue = fanYGen.Next(0, this.Height - heroSize / 2 * 2 - 17 * 3 - 16);
            int fanXValue = this.Width;


            if (fanCounter >= 100)
            {
                fanRectangles.Add(new Rectangle(fanXValue, fanYValue, 30, 32));

                fanRectangles.Add(new Rectangle(fanXValue + 50, fanYValue, 30, 32));

                fanRectangles.Add(new Rectangle(fanXValue + 100, fanYValue, 30, 32));

                fanRectangles.Add(new Rectangle(fanXValue + 150, fanYValue, 30, 32));
                fanCounter = 0;
            }

            //set hero rectangles

            Rectangle heroRectangle = new Rectangle(heroX - 1 * 2, heroY - 7 * 2, 2 * heroSize * 2, heroSize * 2);

            //MOVE MAIN CHARACTER

            //left arrow
            if (leftArrowDown == true)
            {
                heroX = heroX - heroSpeed;
            }

            //down arrow
            if (downArrowDown == true)
            {
                heroY = heroY + heroSpeed;
            }

            //right arrow
            if (rightArrowDown == true)
            {
                heroX = heroX + heroSpeed;
            }

            //up arrow
            if (upArrowDown == true)
            {
                heroY = heroY - heroSpeed;
            }

            //RESET HERO ON SCREEN

            //maximum

            int heroMaxX = this.Width - 2 * heroSize * 2 + 2;
            int heroMaxY = this.Height - heroSize / 2 * 2 - 17 * 3;

            //minimum "x"
            if (heroX > heroMaxX)
            {
                heroX = heroMaxX;
            }

            //minimum "y"
            if (heroY > heroMaxY)
            {
                heroY = heroMaxY;
            }

            //minimum

            int heroMinX = 0;
            int heroMinY = heroSize / 2 * 2 + 2 / 2;

            //minimum "x"
            if (heroX < heroMinX)
            {
                heroX = heroMinX;
            }

            //minimum "y"
            if (heroY < 0 + heroMinY)
            {
                heroY = 0 + heroMinY;
            }

            //MOVE NPC'S

            //move star points

            if (starPoints.Count > 0)
            {
                for (int i = 0; i < starPoints.Count; i++)
                {
                    starPoints[i] = new Point(starPoints[i].X - starSpeed, starPoints[i].Y);

                    if (starPoints[i].X <= 0)
                    {
                        starPoints.Remove(starPoints[i]);
                    }
                }
            }

            //move bullet rectangles

            if (bulletRectangles.Count > 0)
            {
                for (int i = 0; i < bulletRectangles.Count; i++)
                {
                    bulletRectangles[i] = new Rectangle(bulletRectangles[i].X + bulletSpeed, bulletRectangles[i].Y, 16, 8);

                    if (bulletRectangles[i].X >= this.Width)
                    {
                        bulletRectangles.Remove(bulletRectangles[i]);
                    }
                }
            }

            //move fan rectangles

            if (fanRectangles.Count > 0)
            {
                for (int i = 0; i < fanRectangles.Count; i++)
                {
                    fanRectangles[i] = new Rectangle(fanRectangles[i].X - fanSpeed, fanRectangles[i].Y, 30, 32);

                    if (fanRectangles[i].X <= 0)
                    {
                        fanRectangles.Remove(fanRectangles[i]);
                    }
                }
            }

            //COLLISIONS CHECKS

            //check intersections between bullets, and fans

            if (bulletRectangles.Count > 0)
            {
                for (int i = 0; i < bulletRectangles.Count; i++)
                {
                    for (int j = 0; j < fanRectangles.Count; j++)
                    {
                        if (bulletRectangles[i].IntersectsWith(fanRectangles[j]))
                        {
                            //remove bullet
                            bulletRectangles.RemoveAt(i);

                            //remove rectangles
                            fanRectangles.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            //check intersections between fans, and hero

            if (fanRectangles.Count > 0)
            {
                for (int i = 0; i < fanRectangles.Count; i++)
                {
                    if (fanRectangles[i].IntersectsWith(heroRectangle))
                    {
                        //remove fan
                        fanRectangles.RemoveAt(i);

                        //change orientation of hero rectangle
                        heroOrientation = "";
                        HeroDestroyedAnimation();
                        break;
                    }
                }
            }

            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }

        //everything that is to be drawn on the screen is done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //reference variables
            int lifeIconX = this.Width / 7 - 45;
            int lifeIconY = this.Height - 34 + 17 / 4;

            //DRAW BULLETS

            if (bulletRectangles.Count > 0)
            {
                for (int i = 0; i < bulletRectangles.Count; i++)
                {
                    /*
                    //draw rectangle outlining bullet
                    e.Graphics.FillEllipse(starBrush, bulletRectangles[i].X, bulletRectangles[i].Y, starW, starH);
                    */

                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X + 2, bulletRectangles[i].Y - 2, bulletRectangles[i].X + 4, bulletRectangles[i].Y - 2);
                    e.Graphics.DrawLine(whitePen, bulletRectangles[i].X + 4, bulletRectangles[i].Y - 2, bulletRectangles[i].X + 6, bulletRectangles[i].Y - 2);
                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X + 10, bulletRectangles[i].Y - 2, bulletRectangles[i].X + 12, bulletRectangles[i].Y - 2);
                    e.Graphics.DrawLine(whitePen, bulletRectangles[i].X + 12, bulletRectangles[i].Y - 2, bulletRectangles[i].X + 14, bulletRectangles[i].Y - 2);

                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X, bulletRectangles[i].Y, bulletRectangles[i].X + 2, bulletRectangles[i].Y);
                    e.Graphics.DrawLine(whitePen, bulletRectangles[i].X + 2, bulletRectangles[i].Y, bulletRectangles[i].X + 8, bulletRectangles[i].Y);
                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X + 8, bulletRectangles[i].Y, bulletRectangles[i].X + 10, bulletRectangles[i].Y);
                    e.Graphics.DrawLine(whitePen, bulletRectangles[i].X + 10, bulletRectangles[i].Y, bulletRectangles[i].X + 16, bulletRectangles[i].Y);

                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X + 2, bulletRectangles[i].Y + 2, bulletRectangles[i].X + 4, bulletRectangles[i].Y + 2);
                    e.Graphics.DrawLine(whitePen, bulletRectangles[i].X + 4, bulletRectangles[i].Y + 2, bulletRectangles[i].X + 6, bulletRectangles[i].Y + 2);
                    e.Graphics.DrawLine(aquaPen, bulletRectangles[i].X + 10, bulletRectangles[i].Y + 2, bulletRectangles[i].X + 12, bulletRectangles[i].Y + 2);
                }
            }

            //DRAW STARS

            if (starPoints.Count > 0)
            {
                for (int i = 0; i < starPoints.Count; i++)
                {
                    e.Graphics.FillEllipse(starBrush, starPoints[i].X, starPoints[i].Y, starW, starH);
                }
            }

            //DRAW LIFE ICON

            e.Graphics.DrawLine(bluePen, lifeIconX + 6, lifeIconY, lifeIconX + 8, lifeIconY);
            e.Graphics.DrawLine(bluePen, lifeIconX + 4, lifeIconY + 2, lifeIconX + 10, lifeIconY + 2);

            e.Graphics.DrawLine(bluePen, lifeIconX + 4, lifeIconY + 4, lifeIconX + 10, lifeIconY + 4);

            e.Graphics.DrawLine(bluePen, lifeIconX + 2, lifeIconY + 6, lifeIconX + 6, lifeIconY + 6);
            e.Graphics.DrawLine(whitePen, lifeIconX + 6, lifeIconY + 6, lifeIconX + 8, lifeIconY + 6);
            e.Graphics.DrawLine(bluePen, lifeIconX + 8, lifeIconY + 6, lifeIconX + 12, lifeIconY + 6);

            e.Graphics.DrawLine(bluePen, lifeIconX + 2, lifeIconY + 8, lifeIconX + 6, lifeIconY + 8);
            e.Graphics.DrawLine(whitePen, lifeIconX + 6, lifeIconY + 8, lifeIconX + 8, lifeIconY + 8);
            e.Graphics.DrawLine(bluePen, lifeIconX + 8, lifeIconY + 8, lifeIconX + 12, lifeIconY + 8);

            e.Graphics.DrawLine(bluePen, lifeIconX, lifeIconY + 10, lifeIconX + 14, lifeIconY + 10);
            e.Graphics.DrawLine(bluePen, lifeIconX, lifeIconY + 12, lifeIconX + 14, lifeIconY + 12);

            e.Graphics.DrawLine(bluePen, lifeIconX + 6, lifeIconY + 14, lifeIconX + 8, lifeIconY + 14);

            //DRAW VIC VIPER

            /*
            //draw rectangle to screen outlining hero
            e.Graphics.DrawRectangle(heroPen, heroX - 1 * 2, heroY - 7 * 2, 2 * heroSize * 2, heroSize * 2);
            */

            if (heroOrientation == "Up")
            {
                //UP ANIMATION

                //fire

                e.Graphics.DrawLine(redPen, heroX - 2, heroY, heroX + 2, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY - 2, heroX + 6, heroY - 2);
                e.Graphics.DrawLine(yellowPen, heroX + 2, heroY, heroX + 6, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY + 2, heroX + 6, heroY + 2);

                //ship
                e.Graphics.DrawLine(darkBluePen, heroX + 4, heroY - 8, heroX + 10, heroY - 8);
                e.Graphics.DrawLine(aquaPen, heroX + 16, heroY - 8, heroX + 18, heroY - 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY - 8, heroX + 26, heroY - 8);

                e.Graphics.DrawLine(darkBluePen, heroX + 6, heroY - 6, heroX + 14, heroY - 6);
                e.Graphics.DrawLine(aquaPen, heroX + 14, heroY - 6, heroX + 16, heroY - 6);
                e.Graphics.DrawLine(whitePen, heroX + 16, heroY - 6, heroX + 18, heroY - 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY - 6, heroX + 28, heroY - 6);
                e.Graphics.DrawLine(yellowPen, heroX + 28, heroY - 6, heroX + 38, heroY - 6);

                e.Graphics.DrawLine(darkBluePen, heroX + 8, heroY - 4, heroX + 12, heroY - 4);
                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY - 4, heroX + 14, heroY - 4);
                e.Graphics.DrawLine(whitePen, heroX + 14, heroY - 4, heroX + 16, heroY - 4);
                e.Graphics.DrawLine(darkBluePen, heroX + 18, heroY - 4, heroX + 34, heroY - 4);
                e.Graphics.DrawLine(yellowPen, heroX + 34, heroY - 4, heroX + 42, heroY - 4);

                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 2, heroX + 12, heroY - 2);
                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY - 2, heroX + 16, heroY - 2);
                e.Graphics.DrawLine(darkBluePen, heroX + 18, heroY - 2, heroX + 42, heroY - 2);
                e.Graphics.DrawLine(whitePen, heroX + 42, heroY - 2, heroX + 50, heroY - 2);

                e.Graphics.DrawLine(whitePen, heroX + 6, heroY, heroX + 8, heroY);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY, heroX + 12, heroY);
                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY, heroX + 48, heroY);

                e.Graphics.DrawLine(whitePen, heroX + 10, heroY + 2, heroX + 12, heroY + 2);
                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY + 2, heroX + 18, heroY + 2);
                e.Graphics.DrawLine(yellowPen, heroX + 26, heroY + 2, heroX + 30, heroY + 2);
                e.Graphics.DrawLine(yellowPen, heroX + 40, heroY + 2, heroX + 44, heroY + 2);

                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 4, heroX + 16, heroY + 4);
                e.Graphics.DrawLine(darkBluePen, heroX + 16, heroY + 4, heroX + 46, heroY + 4);

                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 6, heroX + 14, heroY + 6);
                e.Graphics.DrawLine(whitePen, heroX + 14, heroY + 6, heroX + 16, heroY + 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 18, heroY + 6, heroX + 38, heroY + 6);

                e.Graphics.DrawLine(aquaPen, heroX + 14, heroY + 8, heroX + 16, heroY + 8);
                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 8, heroX + 18, heroY + 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY + 8, heroX + 26, heroY + 8);
            }
            else if (heroOrientation == "Down")
            {
                //DOWN ANIMATION

                //fire

                e.Graphics.DrawLine(redPen, heroX - 2, heroY, heroX + 2, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY - 2, heroX + 6, heroY - 2);
                e.Graphics.DrawLine(yellowPen, heroX + 2, heroY, heroX + 6, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY + 2, heroX + 6, heroY + 2);

                //fin

                e.Graphics.DrawLine(whitePen, heroX + 6, heroY - 12, heroX + 8, heroY - 12);
                e.Graphics.DrawLine(whitePen, heroX + 8, heroY - 12, heroX + 12, heroY - 12);
                e.Graphics.DrawLine(darkBluePen, heroX + 10, heroY - 12, heroX + 20, heroY - 12);

                e.Graphics.DrawLine(whitePen, heroX + 8, heroY - 10, heroX + 10, heroY - 10);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 10, heroX + 14, heroY - 10);
                e.Graphics.DrawLine(darkBluePen, heroX + 16, heroY - 10, heroX + 28, heroY - 10);

                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 8, heroX + 12, heroY - 8);
                e.Graphics.DrawLine(whitePen, heroX + 12, heroY - 8, heroX + 18, heroY - 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY - 8, heroX + 40, heroY - 8);

                e.Graphics.DrawLine(whitePen, heroX + 12, heroY - 6, heroX + 14, heroY - 6);
                e.Graphics.DrawLine(whitePen, heroX + 14, heroY - 6, heroX + 22, heroY - 6);
                e.Graphics.DrawLine(yellowPen, heroX + 24, heroY - 6, heroX + 36, heroY - 6);
                e.Graphics.DrawLine(whitePen, heroX + 36, heroY - 6, heroX + 46, heroY - 6);

                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY - 4, heroX + 26, heroY - 4);
                e.Graphics.DrawLine(yellowPen, heroX + 26, heroY - 4, heroX + 40, heroY - 4);

                //body

                e.Graphics.DrawLine(whitePen, heroX + 6, heroY, heroX + 8, heroY);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 2, heroX + 12, heroY - 2);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY, heroX + 12, heroY);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY + 2, heroX + 12, heroY + 2);

                e.Graphics.DrawLine(whitePen, heroX + 16, heroY - 2, heroX + 30, heroY - 2);

                e.Graphics.DrawLine(whitePen, heroX + 16, heroY, heroX + 50, heroY);

                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY - 2, heroX + 16, heroY - 2);
                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY, heroX + 16, heroY);

                e.Graphics.DrawLine(yellowPen, heroX + 30, heroY - 4, heroX + 36, heroY - 4);
                e.Graphics.DrawLine(yellowPen, heroX + 36, heroY - 2, heroX + 42, heroY - 2);
                e.Graphics.DrawLine(whitePen, heroX + 42, heroY - 2, heroX + 50, heroY - 2);

                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY + 2, heroX + 40, heroY + 2);
                e.Graphics.DrawLine(whitePen, heroX + 40, heroY + 2, heroX + 42, heroY + 2);
                e.Graphics.DrawLine(whitePen, heroX + 44, heroY, heroX + 46, heroY);
                e.Graphics.DrawLine(darkBluePen, heroX + 46, heroY, heroX + 50, heroY);

                //wing

                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 4, heroX + 14, heroY + 4);

                e.Graphics.DrawLine(whitePen, heroX + 12, heroY + 6, heroX + 14, heroY + 6);
                e.Graphics.DrawLine(whitePen, heroX + 12, heroY + 8, heroX + 14, heroY + 8);
                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 10, heroX + 14, heroY + 10);

                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 4, heroX + 36, heroY + 4);
                e.Graphics.DrawLine(darkBluePen, heroX + 36, heroY + 4, heroX + 38, heroY + 4);
                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 6, heroX + 26, heroY + 6);
                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 8, heroX + 20, heroY + 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 26, heroY + 6, heroX + 32, heroY + 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY + 8, heroX + 24, heroY + 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 16, heroY + 10, heroX + 20, heroY + 10);
            }
            else if (heroOrientation == "Upright")
            {
                //UPRIGHT ANIMATION

                //fire

                e.Graphics.DrawLine(redPen, heroX - 2, heroY, heroX + 2, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY - 2, heroX + 6, heroY - 2);
                e.Graphics.DrawLine(yellowPen, heroX + 2, heroY, heroX + 6, heroY);
                e.Graphics.DrawLine(redPen, heroX + 2, heroY + 2, heroX + 6, heroY + 2);

                //fin

                e.Graphics.DrawLine(darkBluePen, heroX + 6, heroY - 12, heroX + 8, heroY - 12);
                e.Graphics.DrawLine(whitePen, heroX + 8, heroY - 12, heroX + 10, heroY - 12);
                e.Graphics.DrawLine(darkBluePen, heroX + 10, heroY - 12, heroX + 14, heroY - 12);

                e.Graphics.DrawLine(darkBluePen, heroX + 8, heroY - 10, heroX + 10, heroY - 10);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 10, heroX + 14, heroY - 10);
                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY - 10, heroX + 18, heroY - 10);

                e.Graphics.DrawLine(darkBluePen, heroX + 10, heroY - 8, heroX + 12, heroY - 8);
                e.Graphics.DrawLine(whitePen, heroX + 12, heroY - 8, heroX + 18, heroY - 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 18, heroY - 8, heroX + 22, heroY - 8);

                e.Graphics.DrawLine(darkBluePen, heroX + 12, heroY - 6, heroX + 14, heroY - 6);
                e.Graphics.DrawLine(whitePen, heroX + 14, heroY - 6, heroX + 22, heroY - 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 22, heroY - 6, heroX + 26, heroY - 6);

                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY - 4, heroX + 28, heroY - 4);

                //body

                e.Graphics.DrawLine(whitePen, heroX + 6, heroY, heroX + 8, heroY);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY - 2, heroX + 12, heroY - 2);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY, heroX + 12, heroY);
                e.Graphics.DrawLine(whitePen, heroX + 10, heroY + 2, heroX + 12, heroY + 2);

                e.Graphics.DrawLine(whitePen, heroX + 14, heroY - 2, heroX + 28, heroY - 2);
                e.Graphics.DrawLine(darkBluePen, heroX + 28, heroY - 2, heroX + 30, heroY - 2);
                e.Graphics.DrawLine(whitePen, heroX + 14, heroY, heroX + 50, heroY);

                e.Graphics.DrawLine(yellowPen, heroX + 30, heroY - 4, heroX + 36, heroY - 4);
                e.Graphics.DrawLine(yellowPen, heroX + 32, heroY - 2, heroX + 40, heroY - 2);

                e.Graphics.DrawLine(darkBluePen, heroX + 40, heroY - 2, heroX + 42, heroY - 2);

                e.Graphics.DrawLine(darkBluePen, heroX + 14, heroY + 2, heroX + 40, heroY + 2);
                e.Graphics.DrawLine(whitePen, heroX + 40, heroY + 2, heroX + 44, heroY + 2);
                e.Graphics.DrawLine(darkBluePen, heroX + 44, heroY + 2, heroX + 46, heroY + 2);

                //wing

                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 4, heroX + 14, heroY + 4);
                e.Graphics.DrawLine(aquaPen, heroX + 12, heroY + 6, heroX + 14, heroY + 6);

                e.Graphics.DrawLine(whitePen, heroX + 14, heroY + 6, heroX + 16, heroY + 6);
                e.Graphics.DrawLine(aquaPen, heroX + 14, heroY + 8, heroX + 16, heroY + 8);
                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 8, heroX + 18, heroY + 8);
                e.Graphics.DrawLine(aquaPen, heroX + 16, heroY + 10, heroX + 18, heroY + 10);

                e.Graphics.DrawLine(whitePen, heroX + 16, heroY + 4, heroX + 38, heroY + 4);
                e.Graphics.DrawLine(darkBluePen, heroX + 38, heroY + 4, heroX + 42, heroY + 4);
                e.Graphics.DrawLine(whitePen, heroX + 18, heroY + 6, heroX + 26, heroY + 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 26, heroY + 6, heroX + 32, heroY + 6);
                e.Graphics.DrawLine(darkBluePen, heroX + 20, heroY + 8, heroX + 28, heroY + 8);
                e.Graphics.DrawLine(darkBluePen, heroX + 22, heroY + 10, heroX + 24, heroY + 10);
            }
            else
            {

            }

            //DRAW FANS
            
            if (fanRectangles.Count > 0)
            {
                for (int i = 0; i < fanRectangles.Count; i++)
                {
                    //draw rectangle to screen outlining fan
                    e.Graphics.DrawRectangle(heroPen, fanRectangles[i]);
                }
            }

            if (fanRectangles.Count > 0)
            {
                for (int i = 0; i < fanRectangles.Count; i++)
                {
                    if (fanOrientation == "Left")
                    {
                        //LEFT ANIMATION

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 2, fanRectangles[i].X + 18, fanRectangles[i].Y + 2);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 4, fanRectangles[i].X + 14, fanRectangles[i].Y + 4);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 14, fanRectangles[i].Y + 4, fanRectangles[i].X + 16, fanRectangles[i].Y + 4);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 4, fanRectangles[i].X + 20, fanRectangles[i].Y + 4);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 6, fanRectangles[i].X + 10, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 10, fanRectangles[i].Y + 6, fanRectangles[i].X + 14, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 6, fanRectangles[i].X + 16, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 16, fanRectangles[i].Y + 6, fanRectangles[i].X + 18, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 6, fanRectangles[i].X + 22, fanRectangles[i].Y + 6);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 8, fanRectangles[i].X + 8, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 8, fanRectangles[i].Y + 8, fanRectangles[i].X + 12, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 12, fanRectangles[i].Y + 8, fanRectangles[i].X + 18, fanRectangles[i].Y + 8);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 10, fanRectangles[i].X + 8, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 8, fanRectangles[i].Y + 10, fanRectangles[i].X + 10, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 10, fanRectangles[i].X + 16, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 10, fanRectangles[i].X + 24, fanRectangles[i].Y + 10);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 12, fanRectangles[i].X + 12, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 12, fanRectangles[i].X + 18, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 18, fanRectangles[i].Y + 12, fanRectangles[i].X + 22, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 12, fanRectangles[i].X + 26, fanRectangles[i].Y + 12);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 14, fanRectangles[i].X + 10, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 14, fanRectangles[i].X + 16, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 14, fanRectangles[i].X + 20, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 20, fanRectangles[i].Y + 14, fanRectangles[i].X + 24, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 14, fanRectangles[i].X + 26, fanRectangles[i].Y + 14);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 16, fanRectangles[i].X + 8, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 16, fanRectangles[i].X + 16, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 16, fanRectangles[i].X + 22, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 22, fanRectangles[i].Y + 16, fanRectangles[i].X + 24, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 16, fanRectangles[i].X + 28, fanRectangles[i].Y + 16);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 18, fanRectangles[i].X + 4, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 18, fanRectangles[i].X + 6, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 18, fanRectangles[i].X + 12, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 18, fanRectangles[i].X + 18, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 20, fanRectangles[i].Y + 18, fanRectangles[i].X + 22, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 22, fanRectangles[i].Y + 18, fanRectangles[i].X + 24, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 18, fanRectangles[i].X + 28, fanRectangles[i].Y + 18);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 20, fanRectangles[i].X + 6, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 6, fanRectangles[i].Y + 20, fanRectangles[i].X + 8, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 20, fanRectangles[i].X + 20, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 20, fanRectangles[i].X + 26, fanRectangles[i].Y + 20);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 22, fanRectangles[i].X + 6, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 6, fanRectangles[i].Y + 22, fanRectangles[i].X + 10, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 22, fanRectangles[i].X + 12, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 22, fanRectangles[i].X + 16, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 22, fanRectangles[i].X + 20, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 22, fanRectangles[i].X + 26, fanRectangles[i].Y + 22);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 24, fanRectangles[i].X + 8, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 8, fanRectangles[i].Y + 24, fanRectangles[i].X + 14, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 24, fanRectangles[i].X + 20, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 24, fanRectangles[i].X + 24, fanRectangles[i].Y + 24);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 26, fanRectangles[i].X + 16, fanRectangles[i].Y + 26);

                        if (fanOrientationCounter >= 100)
                        {
                            //change animation
                            fanOrientation = "Right";
                            fanOrientationCounter = 0;
                        }
                        else
                        {
                            fanOrientationCounter++;
                        }
                    }
                    else if (fanOrientation == "Right")
                    {
                        //RIGHT ANIMATION

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 12, fanRectangles[i].Y + 4, fanRectangles[i].X + 18, fanRectangles[i].Y + 4);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 6, fanRectangles[i].X + 6, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 6, fanRectangles[i].X + 14, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 14, fanRectangles[i].Y + 6, fanRectangles[i].X + 20, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 20, fanRectangles[i].Y + 6, fanRectangles[i].X + 22, fanRectangles[i].Y + 6);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 8, fanRectangles[i].X + 6, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 8, fanRectangles[i].X + 12, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 8, fanRectangles[i].X + 16, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 8, fanRectangles[i].X + 18, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 18, fanRectangles[i].Y + 8, fanRectangles[i].X + 22, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 8, fanRectangles[i].X + 24, fanRectangles[i].Y + 8);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 10, fanRectangles[i].X + 6, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 10, fanRectangles[i].X + 20, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 20, fanRectangles[i].Y + 10, fanRectangles[i].X + 22, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 10, fanRectangles[i].X + 24, fanRectangles[i].Y + 10);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 12, fanRectangles[i].X + 4, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 12, fanRectangles[i].X + 6, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 12, fanRectangles[i].X + 8, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 12, fanRectangles[i].X + 12, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 12, fanRectangles[i].X + 22, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 22, fanRectangles[i].Y + 12, fanRectangles[i].X + 24, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 12, fanRectangles[i].X + 26, fanRectangles[i].Y + 12);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 14, fanRectangles[i].X + 4, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 14, fanRectangles[i].X + 6, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 14, fanRectangles[i].X + 10, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 14, fanRectangles[i].X + 16, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 20, fanRectangles[i].Y + 14, fanRectangles[i].X + 26, fanRectangles[i].Y + 14);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 16, fanRectangles[i].X + 4, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 16, fanRectangles[i].X + 8, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 16, fanRectangles[i].X + 10, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 16, fanRectangles[i].X + 16, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 16, fanRectangles[i].X + 20, fanRectangles[i].Y + 16);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 18, fanRectangles[i].X + 6, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 6, fanRectangles[i].Y + 18, fanRectangles[i].X + 10, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 18, fanRectangles[i].X + 12, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 18, fanRectangles[i].X + 22, fanRectangles[i].Y + 18);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 20, fanRectangles[i].X + 10, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 12, fanRectangles[i].Y + 20, fanRectangles[i].X + 18, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 18, fanRectangles[i].Y + 20, fanRectangles[i].X + 20, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 20, fanRectangles[i].Y + 20, fanRectangles[i].X + 22, fanRectangles[i].Y + 20);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 22, fanRectangles[i].X + 16, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 16, fanRectangles[i].Y + 22, fanRectangles[i].X + 20, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 20, fanRectangles[i].Y + 22, fanRectangles[i].X + 22, fanRectangles[i].Y + 22);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 24, fanRectangles[i].X + 10, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 10, fanRectangles[i].Y + 24, fanRectangles[i].X + 12, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 12, fanRectangles[i].Y + 24, fanRectangles[i].X + 14, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 14, fanRectangles[i].Y + 24, fanRectangles[i].X + 18, fanRectangles[i].Y + 24);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 24, fanRectangles[i].X + 22, fanRectangles[i].Y + 24);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 26, fanRectangles[i].X + 12, fanRectangles[i].Y + 26);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 26, fanRectangles[i].X + 14, fanRectangles[i].Y + 26);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 26, fanRectangles[i].X + 20, fanRectangles[i].Y + 26);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 28, fanRectangles[i].X + 18, fanRectangles[i].Y + 28);

                        if (fanOrientationCounter >= 100)
                        {
                            //change animation
                            fanOrientation = "Down";
                            fanOrientationCounter = 0;
                        }
                        else
                        {
                            fanOrientationCounter++;
                        }
                    }
                    else
                    {
                        //DOWN ANIMATION

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 2, fanRectangles[i].X + 18, fanRectangles[i].Y + 2);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 4, fanRectangles[i].X + 22, fanRectangles[i].Y + 4);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 6, fanRectangles[i].X + 12, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 6, fanRectangles[i].X + 18, fanRectangles[i].Y + 6);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 6, fanRectangles[i].X + 22, fanRectangles[i].Y + 6);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 8, fanRectangles[i].X + 6, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 8, fanRectangles[i].X + 10, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 10, fanRectangles[i].Y + 8, fanRectangles[i].X + 14, fanRectangles[i].Y + 8);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 8, fanRectangles[i].X + 18, fanRectangles[i].Y + 8);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 10, fanRectangles[i].X + 6, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 10, fanRectangles[i].X + 10, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 10, fanRectangles[i].Y + 10, fanRectangles[i].X + 12, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 12, fanRectangles[i].Y + 10, fanRectangles[i].X + 16, fanRectangles[i].Y + 10);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 10, fanRectangles[i].X + 24, fanRectangles[i].Y + 10);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 12, fanRectangles[i].X + 4, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 12, fanRectangles[i].X + 6, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 12, fanRectangles[i].X + 8, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 12, fanRectangles[i].X + 12, fanRectangles[i].Y + 12);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 12, fanRectangles[i].X + 24, fanRectangles[i].Y + 12);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 14, fanRectangles[i].X + 2, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 2, fanRectangles[i].Y + 14, fanRectangles[i].X + 4, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 14, fanRectangles[i].X + 10, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 14, fanRectangles[i].X + 16, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 14, fanRectangles[i].X + 20, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 20, fanRectangles[i].Y + 14, fanRectangles[i].X + 22, fanRectangles[i].Y + 14);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 14, fanRectangles[i].X + 26, fanRectangles[i].Y + 14);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 16, fanRectangles[i].X + 4, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 16, fanRectangles[i].X + 6, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 6, fanRectangles[i].Y + 16, fanRectangles[i].X + 10, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(darkOrangePen, fanRectangles[i].X + 12, fanRectangles[i].Y + 16, fanRectangles[i].X + 16, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 16, fanRectangles[i].X + 20, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 20, fanRectangles[i].Y + 16, fanRectangles[i].X + 24, fanRectangles[i].Y + 16);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 16, fanRectangles[i].X + 26, fanRectangles[i].Y + 16);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X, fanRectangles[i].Y + 18, fanRectangles[i].X + 4, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 4, fanRectangles[i].Y + 18, fanRectangles[i].X + 8, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 8, fanRectangles[i].Y + 18, fanRectangles[i].X + 12, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 18, fanRectangles[i].X + 22, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 22, fanRectangles[i].Y + 18, fanRectangles[i].X + 24, fanRectangles[i].Y + 18);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 24, fanRectangles[i].Y + 18, fanRectangles[i].X + 26, fanRectangles[i].Y + 18);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 2, fanRectangles[i].Y + 20, fanRectangles[i].X + 6, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 6, fanRectangles[i].Y + 20, fanRectangles[i].X + 10, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 10, fanRectangles[i].Y + 20, fanRectangles[i].X + 14, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 16, fanRectangles[i].Y + 20, fanRectangles[i].X + 20, fanRectangles[i].Y + 20);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 20, fanRectangles[i].Y + 20, fanRectangles[i].X + 24, fanRectangles[i].Y + 20);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 4, fanRectangles[i].Y + 22, fanRectangles[i].X + 12, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 22, fanRectangles[i].X + 18, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 18, fanRectangles[i].Y + 22, fanRectangles[i].X + 22, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 22, fanRectangles[i].Y + 22, fanRectangles[i].X + 24, fanRectangles[i].Y + 22);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 22, fanRectangles[i].X + 16, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(whitePen, fanRectangles[i].X + 16, fanRectangles[i].Y + 22, fanRectangles[i].X + 18, fanRectangles[i].Y + 22);
                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 18, fanRectangles[i].Y + 22, fanRectangles[i].X + 22, fanRectangles[i].Y + 22);

                        e.Graphics.DrawLine(aquaPen, fanRectangles[i].X + 14, fanRectangles[i].Y + 24, fanRectangles[i].X + 18, fanRectangles[i].Y + 24);

                        if (fanOrientationCounter >= 100)
                        {
                            //change animation
                            fanOrientation = "Left";
                            fanOrientationCounter = 0;
                        }
                        else
                        {
                            fanOrientationCounter++;
                        }
                    }
                }
            }

            /*
            if (fanRectangles.Count > 0)
            {
                for (int i = 0; i < fanRectangles.Count; i++)
                {

            if (fanOrientation == "Small Explosion")
            {
                //DESTROYED ANIMATION

                //small explosion

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 4, this.Width / 2 + 16, this.Height / 2 + 4);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 6, this.Width / 2 + 16, this.Height / 2 + 6);

                e.Graphics.DrawLine(yellowPen, this.Width / 2 + 6, this.Height / 2 + 8, this.Width / 2 + 8, this.Height / 2 + 8);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 8, this.Height / 2 + 8, this.Width / 2 + 10, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 8, this.Width / 2 + 12, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 8, this.Width / 2 + 16, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 8, this.Width / 2 + 20, this.Height / 2 + 8);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 20, this.Height / 2 + 8, this.Width / 2 + 22, this.Height / 2 + 8);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 8, this.Height / 2 + 10, this.Width / 2 + 12, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 10, this.Width / 2 + 16, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 10, this.Width / 2 + 22, this.Height / 2 + 10);
                
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 12, this.Width / 2 + 14, this.Height / 2 + 12);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 12, this.Width / 2 + 16, this.Height / 2 + 12);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 12, this.Width / 2 + 18, this.Height / 2 + 12);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 14, this.Width / 2 + 20, this.Height / 2 + 14);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 14, this.Width / 2 + 22, this.Height / 2 + 14);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 22, this.Height / 2 + 14, this.Width / 2 + 24, this.Height / 2 + 14);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 4, this.Height / 2 + 16, this.Width / 2 + 6, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 6, this.Height / 2 + 16, this.Width / 2 + 10, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 10, this.Height / 2 + 16, this.Width / 2 + 16, this.Height / 2 + 16);
                
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 18, this.Width / 2 + 14, this.Height / 2 + 18);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 18, this.Width / 2 + 16, this.Height / 2 + 18);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 18, this.Width / 2 + 18, this.Height / 2 + 18);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 8, this.Height / 2 + 20, this.Width / 2 + 12, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 20, this.Width / 2 + 16, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 20, this.Width / 2 + 22, this.Height / 2 + 20);
                
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 8, this.Height / 2 + 22, this.Width / 2 + 10, this.Height / 2 + 22);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 22, this.Width / 2 + 12, this.Height / 2 + 22);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 22, this.Width / 2 + 16, this.Height / 2 + 22);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 22, this.Width / 2 + 20, this.Height / 2 + 22);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 20, this.Height / 2 + 22, this.Width / 2 + 22, this.Height / 2 + 22);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 24, this.Width / 2 + 16, this.Height / 2 + 24);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 26, this.Width / 2 + 16, this.Height / 2 + 26);
            }
            else if (fanOrientation == "Large Explosion")
            {
                //DESTROYED ANIMATION

                //large explosion

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2, this.Width / 2 + 16, this.Height / 2);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 2, this.Width / 2 + 16, this.Height / 2 + 2);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 18, this.Height / 2 + 2, this.Width / 2 + 20, this.Height / 2 + 2);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 4, this.Height / 2 + 4, this.Width / 2 + 6, this.Height / 2 + 4);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 10, this.Height / 2 + 4, this.Width / 2 + 12, this.Height / 2 + 4);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 4, this.Width / 2 + 16, this.Height / 2 + 4);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 4, this.Width / 2 + 20, this.Height / 2 + 4);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 24, this.Height / 2 + 4, this.Width / 2 + 26, this.Height / 2 + 4);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 6, this.Height / 2 + 6, this.Width / 2 + 8, this.Height / 2 + 6);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 6, this.Width / 2 + 12, this.Height / 2 + 6);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 6, this.Width / 2 + 16, this.Height / 2 + 6);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 18, this.Height / 2 + 6, this.Width / 2 + 20, this.Height / 2 + 6);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 22, this.Height / 2 + 6, this.Width / 2 + 24, this.Height / 2 + 6);

                e.Graphics.DrawLine(yellowPen, this.Width / 2 + 6, this.Height / 2 + 8, this.Width / 2 + 8, this.Height / 2 + 8);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 8, this.Width / 2 + 14, this.Height / 2 + 8);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 8, this.Width / 2 + 18, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 18, this.Height / 2 + 8, this.Width / 2 + 22, this.Height / 2 + 8);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 4, this.Height / 2 + 10, this.Width / 2 + 6, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 12, this.Height / 2 + 10, this.Width / 2 + 14, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 18, this.Height / 2 + 10, this.Width / 2 + 20, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 20, this.Height / 2 + 10, this.Width / 2 + 24, this.Height / 2 + 10);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 24, this.Height / 2 + 10, this.Width / 2 + 26, this.Height / 2 + 10);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 6, this.Height / 2 + 12, this.Width / 2 + 8, this.Height / 2 + 12);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 8, this.Height / 2 + 12, this.Width / 2 + 10, this.Height / 2 + 12);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 12, this.Height / 2 + 12, this.Width / 2 + 14, this.Height / 2 + 12);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 12, this.Width / 2 + 16, this.Height / 2 + 12);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 16, this.Height / 2 + 12, this.Width / 2 + 18, this.Height / 2 + 12);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 12, this.Width / 2 + 20, this.Height / 2 + 12);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 20, this.Height / 2 + 12, this.Width / 2 + 22, this.Height / 2 + 12);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 14, this.Width / 2 + 12, this.Height / 2 + 14);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 14, this.Width / 2 + 14, this.Height / 2 + 14);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 14, this.Width / 2 + 18, this.Height / 2 + 14);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 22, this.Height / 2 + 14, this.Width / 2 + 26, this.Height / 2 + 14);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 26, this.Height / 2 + 14, this.Width / 2 + 28, this.Height / 2 + 14);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 28, this.Height / 2 + 14, this.Width / 2 + 30, this.Height / 2 + 14);

                e.Graphics.DrawLine(whitePen, this.Width / 2, this.Height / 2 + 16, this.Width / 2 + 2, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 2, this.Height / 2 + 16, this.Width / 2 + 4, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 4, this.Height / 2 + 16, this.Width / 2 + 8, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 12, this.Height / 2 + 16, this.Width / 2 + 16, this.Height / 2 + 16);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 16, this.Width / 2 + 18, this.Height / 2 + 16);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 16, this.Width / 2 + 20, this.Height / 2 + 16);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 8, this.Height / 2 + 18, this.Width / 2 + 10, this.Height / 2 + 18);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 18, this.Width / 2 + 12, this.Height / 2 + 18);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 12, this.Height / 2 + 18, this.Width / 2 + 18, this.Height / 2 + 18);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 20, this.Height / 2 + 18, this.Width / 2 + 22, this.Height / 2 + 18);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 22, this.Height / 2 + 18, this.Width / 2 + 24, this.Height / 2 + 18);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 4, this.Height / 2 + 20, this.Width / 2 + 6, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 6, this.Height / 2 + 20, this.Width / 2 + 10, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 10, this.Height / 2 + 20, this.Width / 2 + 12, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 16, this.Height / 2 + 20, this.Width / 2 + 18, this.Height / 2 + 20);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 24, this.Height / 2 + 20, this.Width / 2 + 26, this.Height / 2 + 20);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 8, this.Height / 2 + 22, this.Width / 2 + 12, this.Height / 2 + 22);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 22, this.Width / 2 + 14, this.Height / 2 + 22);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 22, this.Width / 2 + 18, this.Height / 2 + 22);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 6, this.Height / 2 + 24, this.Width / 2 + 8, this.Height / 2 + 24);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 10, this.Height / 2 + 24, this.Width / 2 + 12, this.Height / 2 + 24);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 24, this.Width / 2 + 16, this.Height / 2 + 24);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 24, this.Width / 2 + 20, this.Height / 2 + 24);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 22, this.Height / 2 + 24, this.Width / 2 + 24, this.Height / 2 + 24);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 4, this.Height / 2 + 26, this.Width / 2 + 6, this.Height / 2 + 26);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 26, this.Width / 2 + 12, this.Height / 2 + 26);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 14, this.Height / 2 + 26, this.Width / 2 + 16, this.Height / 2 + 26);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 18, this.Height / 2 + 26, this.Width / 2 + 20, this.Height / 2 + 26);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 24, this.Height / 2 + 26, this.Width / 2 + 26, this.Height / 2 + 26);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 10, this.Height / 2 + 28, this.Width / 2 + 12, this.Height / 2 + 28);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 28, this.Width / 2 + 16, this.Height / 2 + 28);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 30, this.Width / 2 + 16, this.Height / 2 + 30);
            }
            else
            {
                //DESTROYED ANIMATION

                //cross explosion
                
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 2, this.Height / 2 + 2, this.Width / 2 + 4, this.Height / 2 + 2);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 26, this.Height / 2 + 2, this.Width / 2 + 28, this.Height / 2 + 2);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 4, this.Height / 2 + 4, this.Width / 2 + 6, this.Height / 2 + 4);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 24, this.Height / 2 + 4, this.Width / 2 + 26, this.Height / 2 + 4);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 6, this.Height / 2 + 6, this.Width / 2 + 8, this.Height / 2 + 6);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 22, this.Height / 2 + 6, this.Width / 2 + 24, this.Height / 2 + 6);

                e.Graphics.DrawLine(yellowPen, this.Width / 2 + 6, this.Height / 2 + 8, this.Width / 2 + 8, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 8, this.Height / 2 + 8, this.Width / 2 + 10, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 8, this.Width / 2 + 16, this.Height / 2 + 8);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 20, this.Height / 2 + 8, this.Width / 2 + 22, this.Height / 2 + 8);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 10, this.Width / 2 + 12, this.Height / 2 + 10);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 10, this.Width / 2 + 20, this.Height / 2 + 10);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 12, this.Width / 2 + 14, this.Height / 2 + 12);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 12, this.Width / 2 + 18, this.Height / 2 + 12);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 10, this.Height / 2 + 14, this.Width / 2 + 12, this.Height / 2 + 14);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 14, this.Width / 2 + 16, this.Height / 2 + 14);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 20, this.Height / 2 + 14, this.Width / 2 + 22, this.Height / 2 + 14);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 8, this.Height / 2 + 16, this.Width / 2 + 10, this.Height / 2 + 16);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 14, this.Height / 2 + 16, this.Width / 2 + 16, this.Height / 2 + 16);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 18, this.Height / 2 + 16, this.Width / 2 + 20, this.Height / 2 + 16);

                ///

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 2, this.Height / 2 + 28, this.Width / 2 + 4, this.Height / 2 + 28);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 26, this.Height / 2 + 28, this.Width / 2 + 28, this.Height / 2 + 28);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 4, this.Height / 2 + 26, this.Width / 2 + 6, this.Height / 2 + 26);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 24, this.Height / 2 + 26, this.Width / 2 + 26, this.Height / 2 + 26);

                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 6, this.Height / 2 + 24, this.Width / 2 + 8, this.Height / 2 + 24);
                e.Graphics.DrawLine(darkBluePen, this.Width / 2 + 22, this.Height / 2 + 24, this.Width / 2 + 24, this.Height / 2 + 24);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 8, this.Height / 2 + 22, this.Width / 2 + 10, this.Height / 2 + 22);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 14, this.Height / 2 + 22, this.Width / 2 + 16, this.Height / 2 + 22);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 20, this.Height / 2 + 22, this.Width / 2 + 22, this.Height / 2 + 22);

                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 10, this.Height / 2 + 20, this.Width / 2 + 12, this.Height / 2 + 20);
                e.Graphics.DrawLine(darkOrangePen, this.Width / 2 + 18, this.Height / 2 + 20, this.Width / 2 + 20, this.Height / 2 + 20);

                e.Graphics.DrawLine(whitePen, this.Width / 2 + 12, this.Height / 2 + 18, this.Width / 2 + 14, this.Height / 2 + 18);
                e.Graphics.DrawLine(whitePen, this.Width / 2 + 16, this.Height / 2 + 18, this.Width / 2 + 18, this.Height / 2 + 18);

            }
        }
    }
    */

        }

        public void HeroDestroyedAnimation()
        {
            while (heroDestroyedCounter <= 3)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = mDown = false;
                heroDestroyedCounter++;

                if (heroDestroyedCounter == 1)
                {
                    Refresh();
                    Thread.Sleep(100);

                    g.FillRectangle(transparentBrush, heroX - 2, heroY - 14, 4 * heroSize, heroSize * 2);
                    //DESTROYED ANIMATION

                    //small explosion

                    g.DrawLine(redPen, heroX + 20, heroY - 6, heroX + 24, heroY - 6);

                    g.DrawLine(redPen, heroX + 16, heroY - 4, heroX + 28, heroY - 4);

                    g.DrawLine(redPen, heroX + 8, heroY - 2, heroX + 18, heroY - 2);
                    g.DrawLine(whitePen, heroX + 18, heroY - 2, heroX + 26, heroY - 2);
                    g.DrawLine(redPen, heroX + 26, heroY - 2, heroX + 36, heroY - 2);

                    g.DrawLine(redPen, heroX + 2, heroY, heroX + 8, heroY);
                    g.DrawLine(darkOrangePen, heroX + 8, heroY, heroX + 14, heroY);
                    g.DrawLine(whitePen, heroX + 14, heroY, heroX + 30, heroY);
                    g.DrawLine(darkOrangePen, heroX + 30, heroY, heroX + 36, heroY);
                    g.DrawLine(redPen, heroX + 36, heroY, heroX + 42, heroY);

                    g.DrawLine(redPen, heroX + 8, heroY + 2, heroX + 18, heroY + 2);
                    g.DrawLine(whitePen, heroX + 18, heroY + 2, heroX + 26, heroY + 2);
                    g.DrawLine(redPen, heroX + 26, heroY + 2, heroX + 36, heroY + 2);

                    g.DrawLine(redPen, heroX + 16, heroY + 4, heroX + 28, heroY + 4);

                    g.DrawLine(redPen, heroX + 20, heroY + 6, heroX + 24, heroY + 6);
                    Thread.Sleep(100);
                }
                else if (heroDestroyedCounter == 2)
                {
                    //DESTROYED ANIMATION

                    //medium explosion

                    g.DrawLine(redPen, heroX + 20, heroY - 8, heroX + 24, heroY - 8);

                    g.DrawLine(redPen, heroX + 16, heroY - 6, heroX + 28, heroY - 6);

                    g.DrawLine(redPen, heroX + 10, heroY - 4, heroX + 18, heroY - 4);
                    g.DrawLine(darkOrangePen, heroX + 18, heroY - 4, heroX + 26, heroY - 4);
                    g.DrawLine(redPen, heroX + 26, heroY - 4, heroX + 34, heroY - 4);

                    g.DrawLine(redPen, heroX + 4, heroY - 2, heroX + 12, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 12, heroY - 2, heroX + 20, heroY - 2);
                    g.DrawLine(whitePen, heroX + 20, heroY - 2, heroX + 24, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 24, heroY - 2, heroX + 32, heroY - 2);
                    g.DrawLine(redPen, heroX + 32, heroY - 2, heroX + 40, heroY - 2);

                    g.DrawLine(redPen, heroX - 2, heroY, heroX + 6, heroY);
                    g.DrawLine(darkOrangePen, heroX + 6, heroY, heroX + 14, heroY);
                    g.DrawLine(whitePen, heroX + 14, heroY, heroX + 30, heroY);
                    g.DrawLine(darkOrangePen, heroX + 30, heroY, heroX + 38, heroY);
                    g.DrawLine(redPen, heroX + 38, heroY, heroX + 46, heroY);

                    g.DrawLine(redPen, heroX + 4, heroY + 2, heroX + 12, heroY + 2);
                    g.DrawLine(darkOrangePen, heroX + 12, heroY + 2, heroX + 20, heroY + 2);
                    g.DrawLine(whitePen, heroX + 20, heroY + 2, heroX + 24, heroY + 2);
                    g.DrawLine(darkOrangePen, heroX + 24, heroY + 2, heroX + 32, heroY + 2);
                    g.DrawLine(redPen, heroX + 32, heroY + 2, heroX + 40, heroY + 2);

                    g.DrawLine(redPen, heroX + 10, heroY + 4, heroX + 18, heroY + 4);
                    g.DrawLine(darkOrangePen, heroX + 18, heroY + 4, heroX + 26, heroY + 4);
                    g.DrawLine(redPen, heroX + 26, heroY + 4, heroX + 34, heroY + 4);

                    g.DrawLine(redPen, heroX + 16, heroY + 6, heroX + 28, heroY + 6);

                    g.DrawLine(redPen, heroX + 20, heroY + 8, heroX + 24, heroY + 8);

                    Thread.Sleep(100);
                }
                else if (heroDestroyedCounter == 3)
                {
                    //DESTROYED ANIMATION

                    //large explosion

                    g.DrawLine(redPen, heroX + 14, heroY - 10, heroX + 30, heroY - 10);

                    g.DrawLine(redPen, heroX + 6, heroY - 8, heroX + 16, heroY - 8);
                    g.DrawLine(darkOrangePen, heroX + 16, heroY - 8, heroX + 28, heroY - 8);
                    g.DrawLine(redPen, heroX + 28, heroY - 8, heroX + 38, heroY - 8);

                    g.DrawLine(redPen, heroX + 2, heroY - 6, heroX + 12, heroY - 6);
                    g.DrawLine(darkOrangePen, heroX + 12, heroY - 6, heroX + 20, heroY - 6);
                    g.DrawLine(whitePen, heroX + 20, heroY - 6, heroX + 24, heroY - 6);
                    g.DrawLine(darkOrangePen, heroX + 24, heroY - 6, heroX + 32, heroY - 6);
                    g.DrawLine(redPen, heroX + 32, heroY - 6, heroX + 42, heroY - 6);

                    g.DrawLine(redPen, heroX - 2, heroY - 4, heroX + 10, heroY - 4);
                    g.DrawLine(darkOrangePen, heroX + 8, heroY - 4, heroX + 16, heroY - 4);
                    g.DrawLine(whitePen, heroX + 16, heroY - 4, heroX + 28, heroY - 4);
                    g.DrawLine(darkOrangePen, heroX + 28, heroY - 4, heroX + 34, heroY - 4);
                    g.DrawLine(redPen, heroX + 34, heroY - 4, heroX + 46, heroY - 4);

                    g.DrawLine(redPen, heroX - 2, heroY - 2, heroX + 8, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 8, heroY - 2, heroX + 14, heroY - 2);
                    g.DrawLine(whitePen, heroX + 14, heroY - 2, heroX + 30, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 30, heroY - 2, heroX + 36, heroY - 2);
                    g.DrawLine(redPen, heroX + 36, heroY - 2, heroX + 46, heroY - 2);

                    g.DrawLine(redPen, heroX - 4, heroY, heroX + 6, heroY);
                    g.DrawLine(darkOrangePen, heroX + 6, heroY, heroX + 12, heroY);
                    g.DrawLine(whitePen, heroX + 12, heroY, heroX + 32, heroY);
                    g.DrawLine(darkOrangePen, heroX + 32, heroY, heroX + 38, heroY);
                    g.DrawLine(redPen, heroX + 38, heroY, heroX + 48, heroY);

                    g.DrawLine(redPen, heroX - 2, heroY + 2, heroX + 8, heroY + 2);
                    g.DrawLine(darkOrangePen, heroX + 8, heroY + 2, heroX + 14, heroY + 2);
                    g.DrawLine(whitePen, heroX + 14, heroY + 2, heroX + 30, heroY + 2);
                    g.DrawLine(darkOrangePen, heroX + 30, heroY + 2, heroX + 36, heroY + 2);
                    g.DrawLine(redPen, heroX + 36, heroY + 2, heroX + 46, heroY + 2);

                    g.DrawLine(redPen, heroX - 2, heroY + 4, heroX + 10, heroY + 4);
                    g.DrawLine(darkOrangePen, heroX + 8, heroY + 4, heroX + 16, heroY + 4);
                    g.DrawLine(whitePen, heroX + 16, heroY + 4, heroX + 28, heroY + 4);
                    g.DrawLine(darkOrangePen, heroX + 28, heroY + 4, heroX + 34, heroY + 4);
                    g.DrawLine(redPen, heroX + 34, heroY + 4, heroX + 46, heroY + 4);

                    g.DrawLine(redPen, heroX + 2, heroY + 6, heroX + 12, heroY + 6);
                    g.DrawLine(darkOrangePen, heroX + 12, heroY + 6, heroX + 20, heroY + 6);
                    g.DrawLine(whitePen, heroX + 20, heroY + 6, heroX + 24, heroY + 6);
                    g.DrawLine(darkOrangePen, heroX + 24, heroY + 6, heroX + 32, heroY + 6);
                    g.DrawLine(redPen, heroX + 32, heroY + 6, heroX + 42, heroY + 6);

                    g.DrawLine(redPen, heroX + 6, heroY + 8, heroX + 16, heroY + 8);
                    g.DrawLine(darkOrangePen, heroX + 16, heroY + 8, heroX + 28, heroY + 8);
                    g.DrawLine(redPen, heroX + 28, heroY + 8, heroX + 38, heroY + 8);

                    g.DrawLine(redPen, heroX + 14, heroY + 10, heroX + 30, heroY + 10);
                    Thread.Sleep(100);
                }
                else
                {
                    //DESTROYED ANIMATION

                    //cross explosion

                    g.DrawLine(redPen, heroX + 20, heroY - 10, heroX + 24, heroY - 10);

                    g.DrawLine(redPen, heroX + 20, heroY - 8, heroX + 24, heroY - 8);

                    g.DrawLine(redPen, heroX + 18, heroY - 6, heroX + 26, heroY - 6);

                    g.DrawLine(redPen, heroX + 16, heroY - 4, heroX + 20, heroY - 4);
                    g.DrawLine(whitePen, heroX + 20, heroY - 4, heroX + 24, heroY - 4);
                    g.DrawLine(redPen, heroX + 24, heroY - 4, heroX + 28, heroY - 4);

                    g.DrawLine(redPen, heroX + 8, heroY - 2, heroX + 16, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 16, heroY - 2, heroX + 18, heroY - 2);
                    g.DrawLine(whitePen, heroX + 18, heroY - 2, heroX + 26, heroY - 2);
                    g.DrawLine(darkOrangePen, heroX + 26, heroY - 2, heroX + 28, heroY - 2);
                    g.DrawLine(redPen, heroX + 28, heroY - 2, heroX + 36, heroY - 2);

                    g.DrawLine(redPen, heroX + 8, heroY, heroX + 16, heroY);
                    g.DrawLine(darkOrangePen, heroX + 16, heroY - 2, heroX + 18, heroY);
                    g.DrawLine(whitePen, heroX + 18, heroY, heroX + 26, heroY);
                    g.DrawLine(darkOrangePen, heroX + 28, heroY, heroX + 28, heroY);
                    g.DrawLine(redPen, heroX + 28, heroY, heroX + 36, heroY);

                    g.DrawLine(redPen, heroX + 16, heroY + 2, heroX + 20, heroY + 2);
                    g.DrawLine(whitePen, heroX + 20, heroY + 2, heroX + 24, heroY + 2);
                    g.DrawLine(redPen, heroX + 24, heroY + 2, heroX + 28, heroY + 2);

                    g.DrawLine(redPen, heroX + 18, heroY + 4, heroX + 26, heroY + 4);

                    g.DrawLine(redPen, heroX + 20, heroY + 6, heroX + 24, heroY + 6);

                    g.DrawLine(redPen, heroX + 20, heroY + 8, heroX + 24, heroY + 8);

                    if (heroLives > 1)
                    {
                        heroLives = heroLives - 1;
                        heroLivesLabel.Text = heroLives + "";
                    }
                    else
                    {
                        ///Errors out crashing the program
                        
                        MainForm.ChangeScreen(this, "MenuScreen");

                        /*
                        Application.Restart();
                        */
                    }
                }
            }
            //reset hero values
            heroDestroyedCounter = 0;
            heroX = this.Width / 7;
            heroY = this.Height / 2;
            heroOrientation = "Upright";

            //resume game timer
            gameTimer.Enabled = true;
        }
    }
}