using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame.Objects
{
    class DarkRectangle : BaseObject
    {
        public Action<BaseObject> OnDarkOverlap;
        public DarkRectangle(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddRectangle(new Rectangle(-300, -Convert.ToInt32(Y), 300, Convert.ToInt32(Y)));
            return path;
        }
        public override void Render(Graphics g)
        {
            base.Render(g);
            g.FillRectangle(new SolidBrush(Color.Black), -300, -Convert.ToInt32(Y), 300, Convert.ToInt32(Y));
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            OnDarkOverlap(obj);
        }
    }
}
