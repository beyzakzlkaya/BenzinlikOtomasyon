using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nesne_Benzin
{
    public partial class fıs_yazdırma : Form
    {
        public fıs_yazdırma()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        
        SqlCommand fisno = new SqlCommand("select fisidno tbl_benzinal");
        //string fisno;
        private void fıs_yazdırma_Load(object sender, EventArgs e)
        {
          
            benzin_alma bnznal = new benzin_alma();
            label11.Text = benzin_alma.plaka;
            label10.Text = benzin_alma.alimtrh;
            label12.Text = benzin_alma.litre;
            label22.Text = benzin_alma.perad;
            label16.Text = benzin_alma.yakitTuru;
            label14.Text = benzin_alma.birim_fiyat;
            label8.Text = benzin_alma.fisidno;

            label18.Text =( (Convert.ToInt32(label12.Text) * (Convert.ToInt32(label14.Text))).ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fıs_yazdırma.ActiveForm.Hide();
            anasayfa ansyf = new anasayfa();
            ansyf.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
        }


    }
}
