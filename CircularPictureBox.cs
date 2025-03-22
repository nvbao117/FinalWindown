using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Image != null)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, this.Width, this.Height);

                this.Region = new Region(path);

                Graphics g = e.Graphics;
                g.SetClip(path);
                g.DrawImage(this.Image, 0, 0, this.Width, this.Height);

                //Pen pen = new Pen(Color.LightGray, 2);
                //g.DrawEllipse(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
