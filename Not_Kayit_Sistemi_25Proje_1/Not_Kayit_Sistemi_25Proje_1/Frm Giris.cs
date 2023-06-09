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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LC55U5G\\SQLEXPRESS;Initial Catalog=Databasenotkayit;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Ders where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrenciDetay ogrenci = new FrmOgrenciDetay();
                ogrenci.numara = maskedTextBox1.Text;
                ogrenci.Show();                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Parola Ya da Şifre Yanlış");
            }
            baglanti.Close();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text=="1111")
            {
                FrmOgretmendetay frmogretmen = new FrmOgretmendetay();
                frmogretmen.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
