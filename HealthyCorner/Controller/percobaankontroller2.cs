using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HealthyCorner.Controller
{
    class percobaankontroller2
    {
        Model.KlinisModel KlinisModel;
        View.percobaan2 percobaan;
        DataSet ds = new DataSet();
        View.RiwayatKliniz riwayatKliniz;

        public percobaankontroller2(View.percobaan2 percobaan)
        {
            KlinisModel = new Model.KlinisModel();
            this.percobaan = percobaan;
        }
        public percobaankontroller2(View.RiwayatKliniz riwayatKliniz)
        {
            KlinisModel = new Model.KlinisModel();
            this.riwayatKliniz = riwayatKliniz;
        }
        public void Dataklinis2()
        {
            ds = KlinisModel.RiwayatKlinis2();
           // riwayatKliniz.dgriwayatklinis.ItemsSource = ds.Tables[0].DefaultView;
        }
        public void hapusdataklinis(int row)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                //ds.Tables[0].Rows.Remove(row);
                ds.Tables[0].Rows.RemoveAt(row);
            }

        }

    }
}
