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

namespace Deneme
{
    public partial class YazarListe : Form
    {
        public YazarListe()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yazarlar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update yazarlar set ad=@p1,soyad=@p2,kisituru=@p3,cinsiyet=@p4,telefon=@p5,adres_id=@p6 where kisi_id=@p7", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", textBox5.Text);
            komut3.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut3.Parameters.AddWithValue("@p5", textBox6.Text);
            komut3.Parameters.AddWithValue("@p6", int.Parse(textBox7.Text));
            komut3.Parameters.AddWithValue("@p7", int.Parse(textBox2.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("Yazar güncelleme işlemi başarılı ile gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void label4_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yazarsayisi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from yazarlar where kisi_id=@p1",baglanti);
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete from kitapyazar where kisi_id=@p2", baglanti);

            if ("@p2" != "")
            {
                komut3.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                komut3.ExecuteNonQuery();
            }

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yazar silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void YazarListe_Load(object sender, EventArgs e)
        {

        }
    }
}
