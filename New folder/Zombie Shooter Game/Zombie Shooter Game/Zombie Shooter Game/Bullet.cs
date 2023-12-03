using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ضفناها مشان الألوان الخاصة بالطلقة
using System.Drawing;
//و هي لحتى نحسن نحرك الطلقة 
using System.Windows.Forms;       

namespace Zombie_Shooter_Game
{
    class Bullet
    {
            public string direction;
            public int bulletLeft;
            public int bulletTop;

            private int speed = 20;
            private PictureBox bullet = new PictureBox();
            private Timer bulletTimer = new Timer();
        // يلي تحت لحتى أحسن اربضو مع النموذج private هاد ال  
        //طيب ليش بدنا نربط :مشان نحسن نضيف الرصاصة على النموذج
            public void MakeBullet (Form form)
            {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5,5);
            bullet.Tag ="bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront ();
            form.Controls.Add(bullet);           
            bulletTimer. Interval = speed;
            bulletTimer.Tick += new EventHandler(BullteTimerEvent);
            bulletTimer.Start();
    }
        //مشان أحسن نحرك الطلقة بكل الأتجاهات 
        private void BullteTimerEvent(object sender, EventArgs e)
        {
            if (direction =="left")
	{
		 bullet.Left-=speed;
	}
             if (direction =="Right")
	{
		 bullet.Left+=speed;
	}
             if (direction =="Up")
	{
		 bullet.Top-=speed;

	}
             if (direction=="Down")
	{
		 bullet.Top+=speed;
	}
            //مشان الطلقة توصل لجزء مُعين و تختفي
       if (bullet.Left < 10 || bullet.Left > 860 || bullet. Top < 10 || bullet. Top > 600)
        {
         bulletTimer.Stop();
         bulletTimer.Dispose();
         bullet. Dispose();
         bulletTimer = null;
         bullet = null;

             }
           }        
        }
    }