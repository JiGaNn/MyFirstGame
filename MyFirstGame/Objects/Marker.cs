using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame.Objects
{
    class Marker : BaseObject
    {
        public Marker(float x, float y, float angle) : base(x, y, angle) 
        {
            color = defaultColor = Color.Red;
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }

        public override void Render(Graphics g)
        {
            base.Render(g);
            g.FillEllipse(new SolidBrush(color), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(color, 2), -6, -6, 12, 12);
            g.DrawEllipse(new Pen(color, 2), -10, -10, 20, 20);
        }
    }

}
