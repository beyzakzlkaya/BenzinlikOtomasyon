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
    public partial class akaryakıt_ekle : Form
    {
        public akaryakıt_ekle()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        public static string birim_fiyat;
        public static string depo_litre;
        public void listele()
        {
            SqlCommand listele = new SqlCommand("select * from tbl_akaryakitAdi",baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void ekle()
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_akaryakitAdi (yakit_adi,litre_fiyat,depo_litre) values (@p1,@p2,@p3)",baglan.baglanti());
            ekle.Parameters.AddWithValue("@p1",txtakaryakitAd.Text);
            ekle.Parameters.AddWithValue("@p2",txtfiyat.Text);
            ekle.Parameters.AddWithValue("@p3",txtdepolitre.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi ");
            temizle();
            listele();
        }
        public void sil(int idno)
        {
            SqlCommand sil = new SqlCommand("delete tbl_akaryakitAdi where idno=@p1",baglan.baglanti());
            sil.Parameters.AddWithValue("@p1",idno);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi ");
            listele();
        }
        public void guncelle(int idno)
        {
            SqlCommand guncelle = new SqlCommand("update tbl_akaryakitAdi set yakit_adi='"+txtakaryakitAd.Text+"',litre_fiyat='"+txtfiyat.Text+"',depo_litre='"+txtdepolitre.Text+"' where idno=@p1",baglan.baglanti());
            guncelle.Parameters.AddWithValue("@p1",idno);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi ");
            listele();
        }
        public void temizle()
        {
            txtakaryakitAd.Text = " ";
            txtfiyat.Text = " "; 
            txtdepolitre.Text = " ";
        }
        private void akaryakıt_ekle_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns[0].Visible = false;
            birim_fiyat = txtfiyat.Text;
            depo_litre = txtdepolitre.Text;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Personel_Ekle.ActiveForm.Hide();
            anasayfa ansyf = new anasayfa();
            ansyf.Show();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            ekle();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Foreach döngüsü ile seçili olan kayıtların tümünün DataGridViewRow oluşturarak seçer ve her satırda idno ait numara bilgisi çekilerek sil metoduna gönderilir.Satırları Silmek
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                sil(numara);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtakaryakitAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdepolitre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)//foreach ile aktif olan satırı guncelle  
            {
                int guncel = Convert.ToInt32(drow.Cells[0].Value);
                guncelle(guncel);
            }
        }
        private void btnara_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select * from tbl_akaryakitAdi where yakit_adi like'%" + txtara.Text + "%'", baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtara.Text = "";
        }
    }
}
