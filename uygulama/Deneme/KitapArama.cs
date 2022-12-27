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
    public partial class KitapArama : Form
    {
        public KitapArama()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void KitapArama_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_kitaplar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID Numarası")
            {
                string sorgu = "select * from tbl_kitaplar where kitap_id=@ID";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();
                
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            if (comboBox1.Text=="Kitap Adı")
            {
                string sorgu = "select * from tbl_kitaplar where kitapadi=@ad";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", textBox4.Text);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);

                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
                
            

            
        }
    }
}
