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
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        DarkRectangle rect;
        MyEllipse[] ellipse = new MyEllipse[2];
        Random rnd = new Random();
        int score = 0;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            marker = new Marker(pbMain.Width / 2 + 150, pbMain.Height / 2 + 150, 0);
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnEllipseOverlap += (e) =>
            {
                score++;
                txtScore.Text = "Очки: " + score;
                objects.Remove(e);
                RemoveEllipse(e);
            };

            rect = new DarkRectangle(0, pbMain.Height, 0);
            rect.OnDarkOverlap += (d) =>
            {
                d.color = Color.White;
            };

            objects.Add(rect);
            objects.Add(marker);
            objects.Add(player);

            for (int i = 0; i < ellipse.Length; i++)
            {
                ellipse[i] = new MyEllipse(rnd.Next() % (pbMain.Width - 50) + 15, rnd.Next() % (pbMain.Height - 50) + 15, 0);
                objects.Add(ellipse[i]);
            }

        }
        public void RemoveEllipse(MyEllipse e)
        {
            objects.Remove(e);
            for (int i = 0; i < ellipse.Length; i++)
            {
                if (ellipse[i] == e)
                {
                    ellipse[i] = new MyEllipse(rnd.Next() % (pbMain.Width - 50) + 15, rnd.Next() % (pbMain.Height - 50) + 15, 0);
                    objects.Add(ellipse[i]);
                }
            }
        }
        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && obj != rect && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
                if(obj != rect && rect.Overlaps(obj, g))
                {
                    rect.Overlap(obj);

                }
            }

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
                obj.color = obj.defaultColor;
            }
        }
        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);

                dx /= length;
                dy /= length;

                // по сути мы теперь используем вектор dx, dy
                // как вектор ускорения, точнее даже вектор притяжения
                // который притягивает игрока к маркеру
                // 0.5 просто коэффициент который подобрал на глаз
                // и который дает естественное ощущение движения
                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                // расчитываем угол поворота игрока
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            // тормозящий момент,
            // нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // пересчет позиции игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rect.X > pbMain.Width + 400)
            {
                rect.X = 0;
            }
            rect.X += 3;
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if(marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (var el in ellipse)
            {
                if (el.n > 0)
                {
                    el.n--;
                }
                else
                {
                    RemoveEllipse(el);
                }
            }
        }
    }
}
