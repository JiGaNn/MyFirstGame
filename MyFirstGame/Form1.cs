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
        public Form1()
        {
            InitializeComponent();

            myEll = new MyEllipse(120, 120, 0);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            
            g.Transform = myEll.GetTransform();

            myEll.Render(g);
        }
    }
}
