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
    public partial class gecmis_yakit_alanlar : Form
    {
        public gecmis_yakit_alanlar()
        {
            InitializeComponent();
        }
        Baglanti baglan = new Baglanti();
        void  listele()
        {
            SqlCommand listele = new SqlCommand("select * from tbl_benzinal", baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;         
        }
        void ara()
        {
            SqlCommand ara = new SqlCommand("select * from tbl_benzinal where plaka like'%" + txtplaka.Text + "%'", baglan.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtplaka.Text = "";
        }
        private void gecmis_yakit_alanlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            ara();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from tbl_benzinal where fisidno='"+txtsilid.Text+"'",baglan.baglanti());
            sil.ExecuteNonQuery();
            MessageBox.Show("Geçmiş Satış Silindi ");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtplaka.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsilid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gecmis_yakit_alanlar.ActiveForm.Hide();
            anasayfa ansyf = new anasayfa();
            ansyf.Show();
        }

       
    }
}
