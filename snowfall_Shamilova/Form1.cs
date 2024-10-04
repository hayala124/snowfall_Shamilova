using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace snowfall_Shamilova
{
    public partial class Form1 : Form
    {
        private Snowflake snowflake;
        private List<PictureBox> snowFlakes;
        private Timer timerSnawFall = new Timer { Interval = 15 };

        public Form1()
        {
            InitializeComponent();

            Bitmap snowflakeImage = Properties.Resources.snowflake;
            var formHeight = Height;
            var formWidth = Width;
            snowflake = new Snowflake(20, formHeight, formWidth);

            snowFlakes = new List<PictureBox>();

            foreach (PictureBox snowflake in snowflake.GetSnowFlakes())
            {
                Controls.Add(snowflake);
                snowFlakes.Add(snowflake);
            }

            timerSnawFall.Tick += timerSnawFall_Tick;
            timerSnawFall.Start();
        }

        private void timerSnawFall_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            snowflake.UpdateSnow();

            foreach (PictureBox snowflake in snowFlakes)
            {
                snowflake.Top += 2;
                if (snowflake.Bottom > Height)
                {
                    snowflake.Top = -snowflake.Height;
                    snowflake.Left = random.Next(0, Width);
                }

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (PictureBox snowflake in snowFlakes)
            {
                e.Graphics.DrawImage(snowflake.Image, snowflake.Left, snowflake.Top);
            }
        }
    }
}
