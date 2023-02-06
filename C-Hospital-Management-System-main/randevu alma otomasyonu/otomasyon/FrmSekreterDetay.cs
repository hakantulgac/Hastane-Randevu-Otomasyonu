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

namespace otomasyon
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnumara;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TCnumara;

            //AdSoyad

            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_sekreterler where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları datagride Aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd From Tbl_branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları listeye aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd +' '+ DoktorSoyad) as 'Doktorlar',DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select HastaTc,RandevuDoktor,RandevuTarih From Tbl_Randevular where RandevuDurum='Beklemede'", bgl.baglanti());
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;

            
           

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnDuyuruOluştur_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli dr = new FrmDoktorPaneli();
            dr.Show();
        }

        private void BtnBarnsPanel_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frb = new FrmBransPaneli();
            frb.Show();
        }

        private void BtnListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr1 = new FrmRandevuListesi();
            fr1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void MskTarih_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void MskTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView3_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {   
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                try
                {
                    SqlCommand db = new SqlCommand("Select sikayet from Tbl_Randevular WHERE RandevuDurum = 'Beklemede' and HastaTc = " + richTextBox1.Text.ToString(), bgl.baglanti());
                    SqlDataReader dr = db.ExecuteReader();

                    while (dr.Read())
                    {
                        string sikayet = dr["sikayet"].ToString();
                        richTextBox2.Text = sikayet;
                       
                    }
                }
                catch (Exception)
                {
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                    MessageBox.Show("Geçersiz Tc Numarası!");
                }
            }
            else
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tcNumara = richTextBox1.Text;
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular Set RandevuDurum = 'Onaylandı' where RandevuDurum='Beklemede' and HastaTC ="+tcNumara, bgl.baglanti());

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Onaylandı");
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            dataGridView3.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tcNumara = richTextBox1.Text;
            SqlCommand komut = new SqlCommand("Delete from Tbl_Randevular where HastaTC =" + tcNumara, bgl.baglanti());

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silindi");
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            dataGridView3.Refresh();
        }
    }
}
