using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilanOyunu
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();
        string yon = "sol";
        private void label3_Click(object sender, EventArgs e)
        {
            panel_temizle();
            label2.Text = "0";
            parca = new Panel();
            parca.Location = new Point(100,100);
            parca.Size = new Size(10, 10);
            parca.BackColor = Color.Black;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);
            timer1.Start();
            elma_olustur();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;
            elma_yedimi();
            hareket();
            carpisma_kontrol();
            kazandi();
            if (yon=="sağ")
            {
                if(locX<390)
                {
                    locX += 10;
                }
                else
                {
                    locX = 0;
                }
            }
            if (yon == "sol")
            {
                if (locX > 0)
                {
                    locX -= 10;
                }
                else
                {
                    locX = 390;
                }
            }
            if (yon == "aşağı")
            {
                if (locY < 390)
                {
                    locY += 10;
                }
                else
                {
                    locY = 0;
                }
            }
            if (yon == "yukarı")
            {
                if (locY > 0)
                {
                    locY -= 10;
                }
                else
                {
                    locY = 390;
                }
            }
            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                yon = "sağ";
            }
            else if(e.KeyCode==Keys.Up)
            {
                yon = "yukarı";
            }
            else if(e.KeyCode==Keys.Left)
            {
                yon = "sol";
            }
            else if(e.KeyCode==Keys.Down)
            {
                yon = "aşağı";
            }
        }
        void elma_olustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(390);
            elmaY = rnd.Next(390);
            elmaX -= elmaX % 10;
            elmaY -= elmaY % 10;
            elma.Size = new Size(10, 10);
            elma.Location = new Point(elmaX, elmaY);
            elma.BackColor = Color.Red;
            panel1.Controls.Add(elma);
        }
        void elma_yedimi()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location==elma.Location)
            {
                panel1.Controls.Remove(elma);
                parca_ekle();
                puan += 10;
                label2.Text = puan.ToString();
                elma_olustur();
            }
        }
        void parca_ekle()
        {
            Panel ekparca = new Panel();
            ekparca.Size =new Size (10, 10);
            ekparca.BackColor = Color.Black;
            yilan.Add(ekparca);
            panel1.Controls.Add(ekparca);
        }
        void hareket()
        {
            for (int i = yilan.Count-1; i > 0; i--)
            {
                yilan[i].Location = yilan[i-1].Location;
            }
        }
        void carpisma_kontrol()
        {
            for(int i=2;i<yilan.Count;i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible = true;
                    label4.Text = "KAYBETTİNİZ";
                    timer1.Stop();
                }
            }
        }
        void panel_temizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible = false;
        }
        void kazandi()
        {
            if(label2.Text=="500")
            {
                label4.Text = "KAZANDINIZ";
                label4.Visible = true;
                
                timer1.Stop();
            }
        }
    }
}
