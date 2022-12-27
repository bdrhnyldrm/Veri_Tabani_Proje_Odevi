using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deneme
{
    public partial class KitapListe : Form
    {
        public KitapListe()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Min")
            {

                
                int x = int.Parse(textBox3.Text);

                string sorgu = $"select * from kitapgetir2({x})";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            if (comboBox1.Text == "Max")
            {


                int x = int.Parse(textBox3.Text);

                string sorgu = $"select * from kitapgetir({x})";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_kitaplar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update tbl_kitaplar set kitapadi=@p1,sayfasayisi=@p2,yayinevi_id=@p3,yayintarihi=@p4 where kitap_id=@p5", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox6.Text));
            komut3.Parameters.AddWithValue("@p5", int.Parse(textBox2.Text));
            
            komut3.ExecuteNonQuery();
            MessageBox.Show("Kitap güncelleme işlemi başarılı ile gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kitapsayisi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from tbl_kitaplar where kitap_id=@p1", baglanti);
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete from kitapyazar where kitap_id=@p2", baglanti);

            if ("@p2" != "")
            {
                komut3.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
                komut3.ExecuteNonQuery();
            }
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void KitapListe_Load(object sender, EventArgs e)
        {

        }
    }
}









