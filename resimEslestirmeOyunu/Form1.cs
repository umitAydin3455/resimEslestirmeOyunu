using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resimEslestirmeOyunu
{
    public partial class Form1 : Form
    {
        Label ilkTiklanan = null;
        Label sonTiklanan = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };
        
        private void LblResimAtama() 
        {
            foreach (Control etiket in tableLayoutPanel1.Controls)
            {
                Label resimEtiket = etiket as Label;
                if(resimEtiket != null)
                {
                    int randomsayi = random.Next(icons.Count);
                    resimEtiket.Text = icons[randomsayi];
                    resimEtiket.ForeColor = resimEtiket.BackColor;
                    icons.RemoveAt(randomsayi);
                }

            }
        }
        public Form1()
        {
            InitializeComponent();
            LblResimAtama();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
            {
                return;
            }
            Label secilenEtiket = sender as Label;
            if(secilenEtiket != null)
            {
                if (secilenEtiket.ForeColor == Color.Black)
                {
                    return;
                }
                if (ilkTiklanan == null)
                {
                    ilkTiklanan = secilenEtiket;
                    ilkTiklanan.ForeColor = Color.Black;
                    return;
                }
                sonTiklanan = secilenEtiket;
                sonTiklanan.ForeColor = Color.Black;
                oyunSonu();
                if(ilkTiklanan.Text == sonTiklanan.Text)
                {
                    ilkTiklanan = null;
                    sonTiklanan = null;
                    return;
                }
                timer.Start();
            }
        }
        private void oyunSonu()
        {
            foreach (Control etiket in tableLayoutPanel1.Controls)
            {
                Label resimEtiket = etiket as Label;
                if(resimEtiket != null)
                {
                    if(resimEtiket.ForeColor == resimEtiket.BackColor)
                    {
                        return ;
                    }
                }
            }
            MessageBox.Show("Oyun Bitti");
            Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ilkTiklanan.ForeColor = ilkTiklanan.BackColor;
            sonTiklanan.ForeColor = sonTiklanan.BackColor;
            ilkTiklanan = null;
            sonTiklanan = null;
        }
    }
}
