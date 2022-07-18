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
    public partial class depo_durumu : Form
    {
        public depo_durumu()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        public string depbenzinlitre;
        string depdizel_litre;
        string deplpglitre;
        private void button1_Click(object sender, EventArgs e)
        {
            depo_durumu.ActiveForm.Hide();
            anasayfa ansyf = new anasayfa();
            ansyf.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            depo_durumu.ActiveForm.Hide();
            benzin_alma bnzn_alma = new benzin_alma();
            bnzn_alma.Show();
        }
  
        public void sil()
        {
            int fark = (Convert.ToInt32(depbenzinlitre) - Convert.ToInt32(benzin_alma.litre));
            SqlCommand sil = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p1 where yakit_adi='"+benzin_alma.yakitTuru+"' and idno=9 ", baglan.baglanti());
            sil.Parameters.AddWithValue("@p1", fark);
            sil.ExecuteNonQuery();
            lblbenzin.Text = fark.ToString();

            int farkdizel = (Convert.ToInt32(depdizel_litre) - Convert.ToInt32(benzin_alma.litre));
            SqlCommand sildizel = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p2 where yakit_adi='"+benzin_alma.yakitTuru+"' and idno=3 ", baglan.baglanti());
            sildizel.Parameters.AddWithValue("@p2", farkdizel);
            sildizel.ExecuteNonQuery();
            lbldizel.Text = farkdizel.ToString();


            int farklpg = (Convert.ToInt32(deplpglitre) - Convert.ToInt32(benzin_alma.litre));
            SqlCommand sil_lpg = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p3 where yakit_adi='"+benzin_alma.yakitTuru+"' and idno=4", baglan.baglanti());
            sil_lpg.Parameters.AddWithValue("@p3", farklpg);
            sil_lpg.ExecuteNonQuery();
            lbLpg.Text = farklpg.ToString();

            depo_oku();
        }
        public void depo_oku()
        {
            SqlCommand depo_benzin = new SqlCommand("select depo_litre from tbl_akaryakitAdi where yakit_adi='Benzin'" ,baglan.baglanti());
            SqlDataReader dr=depo_benzin.ExecuteReader();
            while (dr.Read())
            {
                depbenzinlitre = dr["depo_litre"].ToString();
                lblbenzin.Text = depbenzinlitre;
            }
            SqlCommand depo_dizel = new SqlCommand("select depo_litre from tbl_akaryakitAdi where yakit_adi='Dizel'", baglan.baglanti());
            SqlDataReader dr1 = depo_dizel.ExecuteReader();
            while (dr1.Read())
            {
                depdizel_litre= dr1["depo_litre"].ToString();
                lbldizel.Text = depdizel_litre;
            }
            SqlCommand depo_lpg = new SqlCommand("select depo_litre from tbl_akaryakitAdi where yakit_adi='LPG'", baglan.baglanti());
            SqlDataReader dr2 = depo_lpg.ExecuteReader();
            while (dr2.Read())
            {
                deplpglitre = dr2["depo_litre"].ToString();
                lbLpg.Text = deplpglitre;
            }
            progressBar1.Value = int.Parse(lblbenzin.Text);
            progressBar3.Value = int.Parse(lbldizel.Text);
            progressBar5.Value = int.Parse(lbLpg.Text);
        }
        public void temizle()
        {
            textBox1.Text = " ";
            textBox3.Text = " ";
            textBox5.Text = " ";
        }
        private void depo_durumu_Load(object sender, EventArgs e)
        {
            depo_oku();
            sil();
        }

        private void btnbenzinekle_Click(object sender, EventArgs e)
        {
            int toplam = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(depbenzinlitre));
            SqlCommand ekle = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p1 where idno=9 ", baglan.baglanti());
            ekle.Parameters.AddWithValue("@p1", toplam);
            ekle.ExecuteNonQuery();
            lblbenzin.Text = toplam.ToString();

            MessageBox.Show("Yakıt Eklendi");
  
            depo_oku();
            temizle();
        }

        private void btndizelekle_Click(object sender, EventArgs e)
        {
            int toplamdizel = (Convert.ToInt32(textBox3.Text) + Convert.ToInt32(depdizel_litre));
            SqlCommand ekledizel = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p2 where idno=3 ", baglan.baglanti());
            ekledizel.Parameters.AddWithValue("@p2", toplamdizel);
            ekledizel.ExecuteNonQuery();
            lbldizel.Text = toplamdizel.ToString();

            MessageBox.Show("Yakıt Eklendi");

            depo_oku();
            temizle();
        }

        private void btnlpgekle_Click(object sender, EventArgs e)
        {
            int toplamlpg = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(deplpglitre));
            SqlCommand ekle_lpg = new SqlCommand("update tbl_akaryakitAdi set depo_litre=@p3 where idno=4 ", baglan.baglanti());
            ekle_lpg.Parameters.AddWithValue("@p3", toplamlpg);
            ekle_lpg.ExecuteNonQuery();
            lbLpg.Text = toplamlpg.ToString();

            MessageBox.Show("Yakıt Eklendi");

            depo_oku();
            temizle();
        }
    }
}
