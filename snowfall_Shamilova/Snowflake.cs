using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace snowfall_Shamilova
{
    internal class Snowflake
    {
        private List<PictureBox> snowFlakes;
        private Random random;
        private int formHeight;
        private int formWidth;

        /// <summary>
        /// Инициализирует новый экземпляр класса с заданным количеством снежинок и размерами формы.
        /// </summary>
        public Snowflake(int count, int height, int width)
        {
            snowFlakes = new List<PictureBox>();
            random = new Random();
            formHeight = height;
            formWidth = width;
            CreateSnowFlakes(count);
        }

        private void CreateSnowFlakes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var size = random.Next(10, 20);
                PictureBox snowflake = new PictureBox
                {
                    Image = Properties.Resources.snowflake,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(size, size),
                    BackColor = Color.Transparent,
                    Top = random.Next(0, formHeight),
                    Left = random.Next(0, formWidth)
                };
                snowFlakes.Add(snowflake);
            }
        }

        /// <summary>
        /// Возвращает список всех созданных снежинок.
        /// </summary>
        public List<PictureBox> GetSnowFlakes()
        {
            return snowFlakes;
        }

        /// <summary>
        /// Обновляет позиции всех снежинок, двигая их вниз и перенося на новое положение при выходе за пределы формы.
        /// </summary>
        public void UpdateSnow()
        {
            foreach (PictureBox snowflake in snowFlakes)
            {
                snowflake.Top += 15;
                if (snowflake.Bottom > formHeight)
                {
                    snowflake.Top = -snowflake.Height;
                    snowflake.Left = random.Next(0, formWidth);
                }
            }
        }
    }
}
