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
    public partial class Eczane : Form
    {
        public Eczane()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""){
                try
                {
                    SqlCommand db = new SqlCommand("Select ilaclar from Tbl_Receteler WHERE HastaTc = " + textBox1.Text.ToString(), bgl.baglanti());
                    SqlDataReader dr = db.ExecuteReader();

                    while (dr.Read())
                    {
                        string ilac = dr["ilaclar"].ToString();
                        label3.Text = ilac;
                        label2.Text = "Recete:";
                    }
                }
                catch(Exception) {
                    label3.Text = "";
                    label2.Text = "";
                    MessageBox.Show("Geçersiz Tc Numarası!");
                }
            }
            else {
                label3.Text = "";
                label2.Text = "";
            }
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Eczane_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
