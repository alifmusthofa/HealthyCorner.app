using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyCorner.Controller
{
    class KalkulatorBMIKontroller
    {
        public static string kethasil;
        
        Model.KalkulatorBMIModel BMImodel;
        View.Pemeriksaan BMIkalkulator;
        

        public KalkulatorBMIKontroller(View.Pemeriksaan BMIkalkulator)
        {
            BMImodel = new Model.KalkulatorBMIModel();
            this.BMIkalkulator = BMIkalkulator;
        }
        public void HasilBMI()
        {
            BMImodel.tinggi = Double.Parse(BMIkalkulator.txtBMITinggi.Text);
            BMImodel.berat = Double.Parse(BMIkalkulator.txtBMIBerat.Text);
            BMImodel.HitungBMI();
            BMImodel.Hasil();
        }

    }
}
