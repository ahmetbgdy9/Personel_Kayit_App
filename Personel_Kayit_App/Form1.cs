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

namespace Personel_Kayit_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-TCM0COR;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabanıDataSet1.Tbl_personel);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabanıDataSet1.Tbl_personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MaskedMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("p@6", label8);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void RdioEvli_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "true";
        }

        private void RdioBekar_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "false";
        }
    }
}
