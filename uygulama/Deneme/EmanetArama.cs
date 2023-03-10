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
    public partial class EmanetArama : Form
    {
        public EmanetArama()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void EmanetArama_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_emanet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Emanet ID")
            {
                string sorgu = "select * from tbl_emanet where emanet_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text == "Kişi ID")
            {
                string sorgu = "select * from tbl_emanet where kisi_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text == "Kitap ID")
            {
                string sorgu = "select * from tbl_emanet where kitap_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }



        }
    }
}
