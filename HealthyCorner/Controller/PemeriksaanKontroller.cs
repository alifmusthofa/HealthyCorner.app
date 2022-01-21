using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace HealthyCorner.Controller
{
    class PemeriksaanKontroller
    {
        // deklarasi object
        Model.Pemeriksaan pemeriksaan;
        View.HomePage home;
        View.PemeriksaanRutinAwal PemeriksaanRutinAwal;
        View.PemeriksaanRutinAkhir PemeriksaanRutinAkhir;

        public PemeriksaanKontroller(View.HomePage home)
        {
            pemeriksaan = new Model.Pemeriksaan();
            this.home = home;
        }
        public PemeriksaanKontroller(View.PemeriksaanRutinAwal PemeriksaanRutinAwal)
        {
            pemeriksaan = new Model.Pemeriksaan();
            this.PemeriksaanRutinAwal = PemeriksaanRutinAwal;
        }
        public PemeriksaanKontroller(View.PemeriksaanRutinAkhir PemeriksaanRutinAkhir)
        {
            pemeriksaan = new Model.Pemeriksaan();
            this.PemeriksaanRutinAkhir = PemeriksaanRutinAkhir;
        }

        public void DataPemeriksaan()
        {
            DataSet ds = pemeriksaan.RiwayatPemeriksaan();
            home.dgRiwayatPemeriksaan.ItemsSource = ds.Tables[0].DefaultView;
        }

        

        public void ShowpemeriksaanToday()
        {
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = pemeriksaan.PemeriksaanHariIni("guladarah", "detakjantung", "tekanandarah", "asamurat", "kolesterol", "suhubadan", tanggal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                home.lblguladarah.Content = ds.Tables[0].Rows[0][0];
                home.lbldetakjantung.Content = ds.Tables[0].Rows[0][1];
                home.lbltekanandarah.Content = ds.Tables[0].Rows[0][2];
                home.lblkolesterol.Content = ds.Tables[0].Rows[0][3];
                home.lblasamurat.Content = ds.Tables[0].Rows[0][4];
                home.lblsuhubadan.Content = ds.Tables[0].Rows[0][5];
            }
            else
            {
                home.lblguladarah.Content = "n/a";
                home.lbldetakjantung.Content = "n/a";
                home.lbltekanandarah.Content = "n/a";
                home.lblkolesterol.Content = "n/a";
                home.lblasamurat.Content = "n/a";
                home.lblsuhubadan.Content = "n/a";
            }
        }


        public void DataPemeriksaan2()
        {
            DataSet ds = pemeriksaan.RiwayatPemeriksaan2();
            PemeriksaanRutinAwal.dgrpemeriksaan.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void TambahRiwayatPemeriksaan()
        {
            // set data
            pemeriksaan.penuh = false;
            pemeriksaan.tanggal = PemeriksaanRutinAwal.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            pemeriksaan.tanggal_id = PemeriksaanRutinAwal.dtpTanggal.SelectedDate.Value.ToString("yyMMdd");
            pemeriksaan.id_record = pemeriksaan.GenerateId();
            pemeriksaan.id = Model.PenggunaModel.idUser;
            pemeriksaan.guladarah = PemeriksaanRutinAwal.txtguladarah.Text;
            pemeriksaan.detakjantung = PemeriksaanRutinAwal.txtDetakJantung.Text;
            pemeriksaan.tekanandarah1 = PemeriksaanRutinAwal.txtTekananDarah1.Text;
            pemeriksaan.tekanandarah2 = PemeriksaanRutinAwal.txtTekananDarah2.Text;
            pemeriksaan.asamurat = PemeriksaanRutinAwal.txtasamUrat.Text;
            pemeriksaan.kolesterol = PemeriksaanRutinAwal.txtkolesterol.Text;
            pemeriksaan.suhubadan = PemeriksaanRutinAwal.txtSuhuBadan.Text;

            if (pemeriksaan.penuh)
            {
                MessageBox.Show("Maaf data untuk Id seri " + pemeriksaan.tanggal + " sudah penuh");
            }
            else
            {
                // proses insert
                bool result = pemeriksaan.InsertPemeriksaan();

                // pesan / informasi
                if (result)
                {
                    MessageBox.Show("Data Pemeriksaan berhasil ditambahkan");
                }
                else
                {
                    MessageBox.Show("Maaf penambahan Data Pemeriksaan harus di inputkan dengan benar");
                }
            }
            


        }

        public void UbahPemeriksaan()
        {
            // set data
            pemeriksaan.tanggal = PemeriksaanRutinAkhir.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            pemeriksaan.id_record = View.PemeriksaanRutinAwal.id;
            pemeriksaan.guladarah = PemeriksaanRutinAkhir.txtguladarah.Text;
            pemeriksaan.detakjantung = PemeriksaanRutinAkhir.txtDetakJantung.Text;
            pemeriksaan.tekanandarah1 = PemeriksaanRutinAkhir.txtTekananDarah1.Text;
            pemeriksaan.tekanandarah2 = PemeriksaanRutinAkhir.txtTekananDarah2.Text;
            pemeriksaan.kolesterol = PemeriksaanRutinAkhir.txtkolesterol.Text;
            pemeriksaan.asamurat = PemeriksaanRutinAkhir.txtasamUrat.Text;
            pemeriksaan.suhubadan = PemeriksaanRutinAkhir.txtSuhuBadan.Text;

            //proses update
            bool result = pemeriksaan.UpdatePemeriksaan();
            //information
            if (result)
            {
                MessageBox.Show("Data Pemeriksaan berhasil diubah");

            }
            else
            {
                MessageBox.Show("Maaf, perubahan data Pemeriksaan tidak dapat dilakukan");
            }


        }

        public void HapusRiwayatpemeriksaan()
        {
            // set data
            pemeriksaan.id_record = PemeriksaanRutinAwal.idHapus;

            // proses insert
            bool result = pemeriksaan.HapusPemeriksaan();

            // pesan / informasi
            if (result)
            {
                MessageBox.Show("Data pemeriksaan berhasil dihapus");
            }
            else
            {
                MessageBox.Show("Maaf Data pemeriksaan tidak dapat dihapuskan dengan benar");
            }


        }



    }
}
