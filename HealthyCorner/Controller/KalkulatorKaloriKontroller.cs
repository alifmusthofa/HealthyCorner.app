using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyCorner.Controller
{
    class KalkulatorKaloriKontroller
    {
        public static string kethasil;
        Model.KalkulatorKaloriModel kalorimodel;
        View.Pemeriksaan kalorikalkulator;

        public KalkulatorKaloriKontroller(View.Pemeriksaan BMIkalkulator)
        {
            kalorimodel = new Model.KalkulatorKaloriModel();
            this.kalorikalkulator = BMIkalkulator;
        }
        public void HasilBMI()
        {
            kalorimodel.tinggi = Double.Parse(kalorikalkulator.txtkaloriTinggi.Text);
            kalorimodel.berat = Double.Parse(kalorikalkulator.txtkaloriBerat.Text);
            kalorimodel.umur = Double.Parse(kalorikalkulator.txtkaloriUmur.Text);
            if (kalorikalkulator.rdbkaloriLk.IsChecked == true)
            {
                kalorimodel.jk = "Laki - laki";
            }
            else
            {
                kalorimodel.jk = "Perempuan";
            }
            kalorimodel.jenisAktifitas = kalorikalkulator.cmbkaloriAktifitas.Text;
            kalorimodel.HitungKalori();
            kalorimodel.Hasil();
        }


    }
}
