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
    public partial class YazarEkle : Form
    {
        public YazarEkle()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("call yazar_ekle(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut1.Parameters.AddWithValue("@p1",int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p2",textBox3.Text);
            komut1.Parameters.AddWithValue("@p3",textBox4.Text);
            komut1.Parameters.AddWithValue("@p4",textBox5.Text);
            komut1.Parameters.AddWithValue("@p5",comboBox1.Text);
            komut1.Parameters.AddWithValue("@p6",textBox1.Text);
            komut1.Parameters.AddWithValue("@p7",int.Parse(textBox6.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yazar Ekleme İşlemi Başarılı");
        }

        

        private void YazarEkle_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from adresler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            string sorgu2 = "select * from yazarlar";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            
            string sorgu3 = "select * from kisi";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];


        }
    }
}
