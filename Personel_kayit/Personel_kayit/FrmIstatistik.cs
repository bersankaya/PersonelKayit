﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_kayit
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-AGQ4V6UP\\WOLVOX8;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel sayısı
            baglanti.Open();

            SqlCommand Komut1 = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = Komut1.ExecuteReader();
            while (dr1.Read())
            {
                Lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            //Evli Personel Sayısı 
            baglanti.Open();
            SqlCommand Komut2 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=1", baglanti);
            SqlDataReader dr2 = Komut2.ExecuteReader();
            while (dr2.Read())
            {
                Lblevlipersonel.Text = dr2[0].ToString();

            }

            baglanti.Close();
            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=0",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                Lblbekarpersonel.Text = dr3[0].ToString();
            }


            baglanti.Close();
            //Şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(Distinct(PerSehir)) From Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                Lblsehirsayısı.Text = dr4[0].ToString();
            }

            baglanti.Close();
            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                Lbltoplammaas.Text = dr5[0].ToString();
            }

            baglanti.Close();
            //Ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                Lblortalamamaas.Text = dr6[0].ToString();
            }


            baglanti.Close();
        }
    }
}
