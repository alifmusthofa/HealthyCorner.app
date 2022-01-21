using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace HealthyCorner.Controller
{
    class kliniskontroller
    {
        Model.KlinisModel KlinisModel;
        View.HomePage home;
        View.RiwayatKlinisViewAwal riwayatKliniz;
        View.RiwayatKlinisViewakhir riwayatklinizAkhir;

        public kliniskontroller(View.HomePage home)
        {
            KlinisModel = new Model.KlinisModel();
            this.home = home;
        }
        public kliniskontroller(View.RiwayatKlinisViewAwal riwayatKliniz)
        {
            KlinisModel = new Model.KlinisModel();
            this.riwayatKliniz = riwayatKliniz;
        }
        public kliniskontroller(View.RiwayatKlinisViewakhir riwayatklinizAkhir)
        {
            KlinisModel = new Model.KlinisModel();
            this.riwayatklinizAkhir = riwayatklinizAkhir;
        }
        public void Dataklinis()
        {
            DataSet ds = KlinisModel.RiwayatKlinis();
            home.dgklinis.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void Dataklinis2()
        {
            DataSet ds = KlinisModel.RiwayatKlinis2();
            riwayatKliniz.dgriwayatklinis.ItemsSource = ds.Tables[0].DefaultView;
        }


        public void TambahRiwayatKlinis()
        {
            // set data
            KlinisModel.penuh = false;
            KlinisModel.tanggal = riwayatKliniz.dtptanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            KlinisModel.tanggal_id = riwayatKliniz.dtptanggal.SelectedDate.Value.ToString("yyMMdd");
            KlinisModel.id_record = KlinisModel.GenerateId();
            KlinisModel.id = Model.PenggunaModel.idUser;
            KlinisModel.nama = riwayatKliniz.txtpenyakit.Text;
            
            
            KlinisModel.ket = riwayatKliniz.txtketeranganKlinis.Text;

            if (KlinisModel.penuh)
            {
                MessageBox.Show("Maaf data untuk Id seri " + KlinisModel.tanggal + " sudah penuh");
            }
            else
            {
                // proses insert
                bool result = KlinisModel.Insertklinis();

                // pesan / informasi
                if (result)
                {
                    MessageBox.Show("Data klinis berhasil ditambahkan");
                }
                else
                {
                    MessageBox.Show("Maaf penambahan Data klinis harus di inputkan dengan benar");
                }
            }

        }

        public void UbahKlinis()
        {
            // set data
            KlinisModel.tanggal = riwayatklinizAkhir.dtptanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            KlinisModel.id_record = View.RiwayatKlinisViewAwal.id;
            KlinisModel.nama = riwayatklinizAkhir.txtpenyakit.Text;
            KlinisModel.ket = riwayatklinizAkhir.txtketeranganKlinis.Text;

            //proses update
            bool result = KlinisModel.UpdateKlinis();
            //information
            if (result)
            {
                MessageBox.Show("Data klinis berhasil diubah");

            }
            else
            {
                MessageBox.Show("Maaf, perubahan data klinis tidak dapat dilakukan");
            }
           

        }

        public void HapusRiwayatKlinis()
        {
            // set data
            KlinisModel.id_record = riwayatKliniz.idHapus;

            // proses insert
            bool result = KlinisModel.HapusKlinis();

            // pesan / informasi
            if (result)
            {
                MessageBox.Show("Data klinis berhasil dihapus");
            }
            else
            {
                MessageBox.Show("Maaf Data klinis tidak dapat dihapuskan dengan benar");
            }


        }


    }
}
