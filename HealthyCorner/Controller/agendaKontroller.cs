using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace HealthyCorner.Controller
{
    class agendaKontroller
    {
        Model.agendaModel agenda;
        View.HomePage home;
        View.AgendaAwal agendaAwal;
        View.agendaAkhir agendaAkhir;
     

        public agendaKontroller(View.HomePage home)
        {
            agenda = new Model.agendaModel();
            this.home = home;
        }

        public agendaKontroller(View.AgendaAwal agendaAwal)
        {
            agenda = new Model.agendaModel();
            this.agendaAwal = agendaAwal;
        }
        public agendaKontroller(View.agendaAkhir agendaAkhir)
        {
            agenda = new Model.agendaModel();
            this.agendaAkhir = agendaAkhir;
        }
        public void DataAgenda()
        {
            agenda.tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = agenda.RiwayatAgenda();
            home.dgagenda.ItemsSource = ds.Tables[0].DefaultView;
        }
        public void DataAgenda2()
        {
            DataSet ds = agenda.RiwayatAgenda2();
            agendaAwal.dgragenda.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void TambahRiwayatAgenda()
        {
            // set data
            agenda.penuh = false;
            agenda.tanggal = agendaAwal.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            agenda.tanggal_id = agendaAwal.dtpTanggal.SelectedDate.Value.ToString("yyMMdd");
            agenda.id_record = agenda.GenerateId();
            agenda.id = Model.PenggunaModel.idUser;
            agenda.agenda = agendaAwal.txtagenda.Text;
            agenda.catatan = agendaAwal.txtcatatan.Text;

            
            if (agenda.penuh)
            {
                MessageBox.Show("Maaf data untuk Id seri " + agenda.tanggal + " sudah penuh");
            }
            else
            {
                // proses insert
                bool result = agenda.InsertAgenda();

                // pesan / informasi
                if (result)
                {
                    MessageBox.Show("Data Agenda berhasil ditambahkan");
                }
                else
                {
                    MessageBox.Show("Maaf penambahan Data Agenda di inputkan dengan benar");
                }
            }

        }

        public void UbahAgenda()
        {
            // set data
            agenda.tanggal = agendaAkhir.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            agenda.id_record = View.AgendaAwal.id;
            agenda.agenda = agendaAkhir.txtagenda.Text;
            agenda.catatan = agendaAkhir.txtcatatan.Text;

            //proses update
            bool result = agenda.UpdateAgenda();
            //information
            if (result)
            {
                MessageBox.Show("Data Agenda berhasil diubah");

            }
            else
            {
                MessageBox.Show("Maaf, perubahan data Agenda tidak dapat dilakukan");
            }


        }

        public void HapusRiwayatAgenda()
        {
            // set data
            agenda.id_record = agendaAwal.idHapus;

            // proses insert
            bool result = agenda.HapusAgenda();

            // pesan / informasi
            if (result)
            {
                MessageBox.Show("Data agenda berhasi dihapus");
            }
            else
            {
                MessageBox.Show("Maaf Data agenda tidak dapat dihapuskan dengan benar");
            }


        }

    }
}
