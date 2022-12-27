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
    public partial class EmanetListe : Form
    {
        public EmanetListe()
        {
            InitializeComponent();
        }


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_emanet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update tbl_emanet set kisi_id=@p1,kitap_id=@p2,emanettarihi=@p3 where emanet_id=@p4", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
            komut3.Parameters.AddWithValue("@p3", textBox7.Text);
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox2.Text));
            

            komut3.ExecuteNonQuery();
            MessageBox.Show("Emanet güncelleme işlemi başarılı ile gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EmanetListe_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select * from tbl_uyeler";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            string sorgu3 = "select * from tbl_kitaplar";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from tbl_emanet  where emanet_id=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Emanet silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
