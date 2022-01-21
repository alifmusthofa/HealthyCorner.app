using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyCorner.Model
{
    class KalkulatorBMIModel
    {
        
        public double tinggi;
        public double berat;
        
        

        public  double HitungBMI()
        {
            return (berat / ((tinggi / 100) * (tinggi / 100)));
            
        }
        public void Hasil()
        {
            
            double var1 = HitungBMI();
            double var2 = Math.Round(var1, 2);
            double hasil = var2;
            string maxindex = "normal";
            if(hasil < 18.5){
                maxindex = "UnderWeight";
            }
            else if(hasil < 23) 
            {
                maxindex = "Normal";
            }
            else if (hasil < 25)
            {
                maxindex = "Resiko ke overweight";
            }
            else if (hasil < 30)
            {
                maxindex = "Overweigh";
            }
            else
            {
                maxindex = "Obese";
            }

            Controller.KalkulatorBMIKontroller.kethasil = "Index BMI Anda : " + hasil + ". Anda termasuk orang yang " + maxindex;
        }

        

    }
}
