using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Benzin
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             anasayfa.ActiveForm.Hide();
            
            Personel_Ekle prsn = new Personel_Ekle();

            prsn.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anasayfa.ActiveForm.Hide();
            akaryakıt_ekle akryt_ekle = new akaryakıt_ekle();
            akryt_ekle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfa.ActiveForm.Hide();
            benzin_alma bnzn_alma = new benzin_alma();
            bnzn_alma.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anasayfa.ActiveForm.Hide();
            depo_durumu dp_durumu = new depo_durumu();
            dp_durumu.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            anasayfa.ActiveForm.Hide();
            gecmis_yakit_alanlar gcms_ykt = new gecmis_yakit_alanlar();
            gcms_ykt.Show();
        }
    }
}
