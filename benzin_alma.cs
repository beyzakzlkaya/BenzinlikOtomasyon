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
    public partial class benzin_alma : Form
    {
        public benzin_alma()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        public static string plaka;
        public static string litre;
        public static string yakitTuru;
        public static string perad;
        public static string alimtrh;
        public static string birim_fiyat;
        public static string fisidno;

        public void al()
        {
            SqlCommand al = new SqlCommand("insert into tbl_benzinal (plaka,litre,yakitTur,personelAdi,alimTarih) values (@p1,@p2,@p3,@p4,@p5)",baglan.baglanti());
            al.Parameters.AddWithValue("@p1",txtplaka.Text);
            al.Parameters.AddWithValue("@p2", txtlitre.Text);
            al.Parameters.AddWithValue("@p3", comboBox1.Text);
            al.Parameters.AddWithValue("@p4", comboBox2.Text);
            al.Parameters.AddWithValue("@p5", dateTimePicker1.Value);
            al.ExecuteNonQuery();
            MessageBox.Show("Fiş Yazdırılıyor ");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            al();
            benzin_alma.ActiveForm.Hide();
            plaka = txtplaka.Text;
            litre = txtlitre.Text;
            yakitTuru = comboBox1.Text;
            perad = comboBox2.Text;
            birim_fiyat = txtfiyat.Text;
            alimtrh = dateTimePicker1.Value.ToString();
            fıs_yazdırma fıs_yzdrma = new fıs_yazdırma();
            fıs_yzdrma.Show();
           
        }
        fıs_yazdırma fis = new fıs_yazdırma();
        akaryakıt_ekle yakit = new akaryakıt_ekle();
        private void benzin_alma_Load(object sender, EventArgs e)
        {
            //yakıt adı cmbye ekle
            SqlCommand komut = new SqlCommand("select * from tbl_akaryakitAdi ",baglan.baglanti());
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(1)).ToString();                            
            }
            
            //cmbye persad,sad ekle
            SqlCommand komut2 = new SqlCommand("select * from tbl_personel", baglan.baglanti());
            komut2.CommandType = CommandType.Text;
            SqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["perad"]+" "+dr2["persad"]);      
            }
            //fiş yazdırmaya id alma
            SqlCommand id = new SqlCommand("select * from tbl_benzinal", baglan.baglanti());
            id.CommandType = CommandType.Text;
            SqlDataReader oku;
            oku = id.ExecuteReader();
            while (oku.Read())
            {  
                fisidno =(oku["fisidno"]).ToString();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand al = new SqlCommand("select litre_fiyat from tbl_akaryakitAdi where yakit_adi=@p1",baglan.baglanti());
            al.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader oku=al.ExecuteReader();
            while (oku.Read())
            {
                txtfiyat.Text = oku[0].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            benzin_alma.ActiveForm.Hide();
            anasayfa asyf = new anasayfa();
            asyf.Show();
        }
    }
}
