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
using System.IO;

namespace Nesne_Benzin
{
    public partial class Personel_Ekle : Form
    {
        public Personel_Ekle()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        public string DosyaYolu;
        void listele()
        {
            SqlCommand listele = new SqlCommand("select * from tbl_personel", baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        string klasor_hedef = @"C:\Users\beyza\OneDrive\Masaüstü\nesne_benzin\nesne_benzin\Nesne_Benzin\bin\Image\";//image klasörünün hedef yolu
        void ekle()
        {
            SqlCommand ekle = new SqlCommand("insert into tbl_personel (pertc,perad,persad,perdgmtrh,pertel,mail,maas) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglan.baglanti());
            ekle.Parameters.AddWithValue("@p1", msktc.Text);
            ekle.Parameters.AddWithValue("@p2", txtperad.Text);
            ekle.Parameters.AddWithValue("@p3", txtpersad.Text);
            ekle.Parameters.AddWithValue("@p4", mskDgmTarh.Text);
            ekle.Parameters.AddWithValue("@p5", msktel.Text);
            ekle.Parameters.AddWithValue("@p6", txtmail.Text);
            ekle.Parameters.AddWithValue("@p7", txtmaas.Text);

            FileStream fs = new FileStream(DosyaYolu, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //byte[] fotolar = br.ReadBytes((int)fs.Length);
            //br.Close();
            //fs.Close();
            //ekle.Parameters.Add("@p8", SqlDbType.Image, fotolar.Length).Value = fotolar;
            File.Copy(DosyaYolu, klasor_hedef + Path.GetFileName(DosyaYolu));//resmi klasöre atma
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi");
            temizle();
            listele();

        }
        void sil(int idno)
        {
            SqlCommand sil = new SqlCommand("delete tbl_personel where idno=@p1", baglan.baglanti());
            sil.Parameters.AddWithValue("@p1", idno);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            listele();
        }
        void guncelle(int idno)
        {
            SqlCommand guncelle = new SqlCommand("update tbl_personel set pertc='"+msktc.Text+"', perad='" + txtperad.Text + "',persad='" + txtpersad.Text + "',perdgmtrh='" + mskDgmTarh.Text + "',pertel='" +msktel.Text + "',mail='" + txtmail.Text + "',maas='" + txtmaas.Text + "' where idno=@p1", baglan.baglanti());
            guncelle.Parameters.AddWithValue("@p1", idno);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            listele();
        }
        void temizle()
        {
            msktc.Text = " ";
            txtperad.Text = " ";
            txtpersad.Text = " ";
            mskDgmTarh.Text = " ";
            txtmaas.Text = " ";
            txtmail.Text = " ";
            msktel.Text = " ";
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel_Ekle.ActiveForm.Hide();
            anasayfa ansyf= new anasayfa();
            ansyf.Show();
          
        }
        private void Personel_Ekle_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns[0].Visible = false;
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            ekle();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) //aktif kayıt sil
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                sil(numara);
            }
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)//foreach ile aktif olan satırı guncelle  
            {
                int guncel = Convert.ToInt32(drow.Cells[0].Value);
                guncelle(guncel);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            msktc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtperad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtpersad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            mskDgmTarh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            msktel.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtmaas.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.Image = Image.FromFile(klasor_hedef + msktc.Text + ".jpg");

        }

        private void btnara_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select * from tbl_personel where pertc like'%" + mskaratc.Text + "%'", baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mskaratc.Text = "";
        }

        private void btngozat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaper = new OpenFileDialog();
            dosyaper.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Tüm Dosyalar |*.*";
            dosyaper.Title = "Personel Resmi Seç ";
            dosyaper.ShowDialog();
            DosyaYolu = dosyaper.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
        }

        private void btnresimsil_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;//pictureboxın değerini boşaltır
        }

      
    }
}
