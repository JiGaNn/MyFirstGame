using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFirstGame.Objects;

namespace MyFirstGame
{
    public partial class Form1 : Form
    {
        MyEllipse myEll;
        List<BaseObject> objects = new();
        Player player;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            objects.Add(player);
            objects.Add(new MyEllipse(120, 120, 0));
            objects.Add(new MyEllipse(200, 220, 0));
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            foreach(var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }
    }
}
