using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zombie_Shooter_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ل ربط مع الصفحة الأساسية
            RestartGame();
        }
        //التصريح عن المتحولات
        bool goleft, goRight, goUp, goDown, gameOver;
        string facing = "up"; 
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score;
        Random randNum = new Random();
        List<PictureBox> zombiesList = new List<PictureBox>();

      //لعدم تحريك الاعب أكتر من النموذج
        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
            }
            textAmmo.Text = "Ammo:" + ammo;
            textScore.Text = "Kills:" + score;

            if (goleft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 69)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
            
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag=="ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;

                    }
                }
                //لتحريك الزومبي الى اللاعب 
                if (x is PictureBox&&(string)x.Tag=="zombie")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }
                    if (x.Left> player.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                        
                    }

                    if (x.Left < player.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;

                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;

                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;

                    }


                }
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox&&(string)j.Tag=="bullet" && x is PictureBox&& ( string)x.Tag=="zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));        
                                Makezombies();
                        }
                    }   
                }

            }
        }

         //ل أستطبع تحريك الصورة مع ضغط أزرار التحرك
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver==true)
            {
                return;   
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "Right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "Up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "Down";
                player.Image = Properties.Resources.down;
            }
        }
        // هذا لعدم أستمرار اللاعب في التحرك عنند التوقف الضفط على أزرار التحرك 
         private void KeyIsup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;

            }
            if (e.KeyCode == Keys.Space &&ammo>0&& gameOver==false)
            {
                ammo--;
                ShootBullet(facing);
                if (ammo<1)
                {
                    DropAmmo();
                }

            }
            if (e.KeyCode==Keys.Enter && gameOver==true)
            {
                RestartGame();
            }
        }
        private void ShootBullet(string diraction)
       {
      Bullet shootBullet = new Bullet();
      shootBullet.direction = diraction;
      shootBullet.bulletLeft = player.Left + (player.Width / 2);
      shootBullet.bulletTop = player.Top + (player.Height / 2);
      shootBullet.MakeBullet(this); 
        }
        private void Makezombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
        }
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width-ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.up;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

                zombiesList.Clear();
            //عدد الزوبي يلي لح تنزل مرة وحدة
                for (int z = 0; z < 3; z++)
                {
                    Makezombies();
                }
                goUp = false;
                goDown = false;
                goleft = false;
                goRight = false;
                gameOver = false;
                playerHealth = 100;
                score = 0;
                ammo = 10;
                GameTimer.Start();

            }
        }
    }

