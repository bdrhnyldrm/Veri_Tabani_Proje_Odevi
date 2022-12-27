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
    public partial class YazarArama : Form
    {
        public YazarArama()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID Numarası")
            {
                string sorgu = "select * from yazarlar where kisi_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text == "ad")
            {
                string sorgu = "select * from yazarlar where ad=@ad";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", textBox4.Text);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text == "soyad")
            {
                string sorgu = "select * from yazarlar where soyad=@soyad";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@soyad", textBox4.Text);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text == "adres ID")
            {
                string sorgu = "select * from yazarlar where adres_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
        }

        private void YazarArama_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from yazarlar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
