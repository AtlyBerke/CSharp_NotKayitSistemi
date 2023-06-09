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
    public partial class FrmOgrenciDetay : Form
        
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
     
        }
        public string numara;
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-LC55U5G\\SQLEXPRESS;Initial Catalog=Databasenotkayit;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Ders where OGRNUMARA=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", lblnumara.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2] + " " + dr[3].ToString();
                lblsınav1.Text = dr[4].ToString();
                lblsınav2.Text = dr[5].ToString();
                lblsınav3.Text = dr[6].ToString();
                lblortalama.Text = dr[7].ToString();
                lbldurum.Text = dr[8].ToString();
                
            }
            if (lbldurum.Text=="True")
            {
                lbldurum.Text = "Geçti";  
            }
            else
            {
                lbldurum.Text = "Kaldı";
            }
            
        }
    }
}
