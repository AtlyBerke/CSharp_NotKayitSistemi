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

namespace Not_Kayit_Sistemi_25Proje_1
{
    public partial class FrmOgretmendetay : Form
    {
        public FrmOgretmendetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LC55U5G\\SQLEXPRESS;Initial Catalog=Databasenotkayit;Integrated Security=True");       
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmOgretmendetay_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ders", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);
            ortalama = (s1 + s3 + s2) / 3;
            lblortalama.Text = ortalama.ToString();

            if (ortalama>=50)
            {
                durum = "True"; 
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update Tbl_Ders set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,OGRORTALAMA=@p4,DURUM=@p5 where OGRNUMARA=@p6", baglanti);
            
            komut2.Parameters.AddWithValue("@p1", txtsınav1.Text);
            komut2.Parameters.AddWithValue("@p2", txtsınav2.Text);
            komut2.Parameters.AddWithValue("@p3", txtsınav3.Text);
            komut2.Parameters.AddWithValue("@p4", decimal.Parse(lblortalama.Text));
            komut2.Parameters.AddWithValue("@p5", durum);
            komut2.Parameters.AddWithValue("@p6", msknumara.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into Tbl_Ders(OGRNUMARA,OGRAD,OGRSOYAD) values (@t1,@t2,@t3)", baglanti);
            komut3.Parameters.AddWithValue("@t1", msknumara.Text);
            komut3.Parameters.AddWithValue("@t2", textBox1.Text);
            komut3.Parameters.AddWithValue("@t3", textBox2.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Başarıyla Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ders", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
