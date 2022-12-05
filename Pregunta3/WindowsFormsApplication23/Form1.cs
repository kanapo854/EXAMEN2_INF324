using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int x, y;

        int mR = 0, mG = 0, mB = 0;

        int[] segmentos = new int[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPGE|*.jpg|Archivos GIF|*.gif" ;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

        }

        //seleccionar color
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            textBox4.Text = x.ToString();
            textBox5.Text = y.ToString();
            Color c = new Color();
            c = bmp.GetPixel(x,y);
            mR = 0; mG = 0; mB = 0;

            for (int i = x; i < x+10; i++)
            {
                for (int j = y; j < y+10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            }
            mR = mR/100;
            mG = mG/100;
            mB = mB/100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();

        }

        //pintar segmentos con el primer color
        private void button8_Click(object sender, EventArgs e)
        {
            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            segmentos[0] = mR;
            segmentos[1] = mG;
            segmentos[2] = mB;
            for (int i = 0; i < bmp.Width-10; i=i+10)
                for (int j = 0; j < bmp.Height-10; j=j+10)
                {
                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }
                    
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                    if (ver(segmentos[0], segmentos[1], segmentos[2], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.Yellow);
                            }
                    }
                    else if (ver(segmentos[3], segmentos[4], segmentos[5], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.White);
                            }
                    }
                    else if (ver(segmentos[6], segmentos[7], segmentos[8], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.LightBlue);
                            }
                    }
                    else {
                            for (int i2 = i; i2 < i + 10; i2++)
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R,c.G,c.B));
                                }
                        }
                }
            pictureBox1.Image = bmp2;
        }


        //pintar segmentos con el segundo color
        private void button3_Click_1(object sender, EventArgs e)
        {
            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            segmentos[3] = mR;
            segmentos[4] = mG;
            segmentos[5] = mB;
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {
                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }

                    mRn = mRn / 100;
                    mGn = mGn / 100;
                    mBn = mBn / 100;

                    if (ver(segmentos[3], segmentos[4], segmentos[5], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.White);
                            }
                    } else if (ver(segmentos[0], segmentos[1], segmentos[2], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.Yellow);
                            }
                    }
                    else if (ver(segmentos[6], segmentos[7], segmentos[8], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.LightBlue);
                            }
                    }
                    else
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                }
            pictureBox1.Image = bmp2;
        }

        //pintar segmentos con el tercer color
        private void button4_Click_1(object sender, EventArgs e)
        {
            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            segmentos[6] = mR;
            segmentos[7] = mG;
            segmentos[8] = mB;
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {
                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }

                    mRn = mRn / 100;
                    mGn = mGn / 100;
                    mBn = mBn / 100;

                    if (ver(segmentos[6], segmentos[7], segmentos[8], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.LightBlue);
                            }
                    }
                    else if (ver(segmentos[0], segmentos[1], segmentos[2], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.Yellow);
                            }
                    }
                    else if (ver(segmentos[3], segmentos[4], segmentos[5], mRn, mGn, mBn))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.White);
                            }
                    }
                    else
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                }
            pictureBox1.Image = bmp2;
        }


        public bool ver(int x, int y , int z, int mx, int my, int mz)
        {
            return (x - 10 <= mx) && (mx <= x + 10) &&
                      ((y - 10 <= my) && (my <= y + 10) &&
                      (z - 10 <= mz) && (mz <= z + 10));
        }
    }
}
