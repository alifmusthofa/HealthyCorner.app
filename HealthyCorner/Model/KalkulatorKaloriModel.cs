using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyCorner.Model
{
    class KalkulatorKaloriModel
    {
        
        

        public double tinggi;
        public double berat;
        public double umur;
        public string jk;
        public string jenisAktifitas;



        


        public double HitungKalori()
        {
            double kalori = 0;
            if(jk == "Laki - laki")
            {
               kalori = 66.5 + (13.7 * berat ) + (5 * tinggi) - (6.8 * umur);
            }
            else
            {
                kalori = 655 + (9.6 * berat) + (1.8 * tinggi) - (4.7 * umur);
            }

            if(jenisAktifitas == "Kaum Rebahan")
            {
                kalori = kalori * 1.3;
            }else if(jenisAktifitas == "Aktifitas Ringan")
            {
                kalori = kalori * 1.55;
            }
            else if (jenisAktifitas == "Aktifitas Sedang")
            {
                kalori = kalori * 1.65;
            }
            else
            {
                kalori = kalori * 1.8;
            }

            return kalori;

        }

        public double beratIdeal()
        {
            double beratideal = 0;
            
            if (jk == "Laki - laki")
            {
                beratideal = (tinggi - 100) - ((tinggi - 100) * 0.10);
            }
            else
            {
                beratideal = (tinggi - 100) - ((tinggi - 100) * 0.15);
            }

            return beratideal;
        }
        public void Hasil()
        {
            double var1 = HitungKalori();
            double var2 = Math.Round(var1, 0);
            double ideal = beratIdeal();
            double hasil = var2;
            Controller.KalkulatorKaloriKontroller.kethasil = "Kebutuhan kalori :" + hasil + " kalori. Berat Badan Ideal : "+ideal+" kg";
        }

    }
}
