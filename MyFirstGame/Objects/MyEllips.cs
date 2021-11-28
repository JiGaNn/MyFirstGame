using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame.Objects
{
    class MyEllipse : BaseObject
    {
        public MyEllipse(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(0, 0, 30, 30);
            return path;
        }
        public override void Render(Graphics g)
        {
            base.Render(g);
            g.FillEllipse(new SolidBrush(Color.Gold), 0, 0, 30, 30);
            g.DrawEllipse(new Pen(Color.DarkGoldenrod, 2), 0, 0, 30, 30);
        }
    }
}
