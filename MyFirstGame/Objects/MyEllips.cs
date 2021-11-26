using System;
using System.Collections.Generic;
using System.Drawing;
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

        public override void Render(Graphics g)
        {
            base.Render(g);
            g.FillEllipse(new SolidBrush(Color.Aqua), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Cyan, 2), -15, -15, 30, 30);
        }
    }
}
