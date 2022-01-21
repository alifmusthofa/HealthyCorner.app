using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace HealthyCorner.Model
{
    class agendaModel
    {
        ModelTemplate temp;
        public string id_record { get; set; }
        public string tanggal { get; set; }
        public string id { get; set; }
        public string agenda { get; set; }
        public string catatan { get; set; }
        public string tanggal_id { get; set; }
        public bool penuh { get; set; }

        public agendaModel()
        {
            temp = new ModelTemplate();
        }

        public DataSet RiwayatAgenda()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT agenda as [Agenda],CONVERT (VARCHAR(9),tanggal_agenda,6) as [Tanggal],catatan as [Catatan] from agenda where id = '" + Model.PenggunaModel.idUser + "' and tanggal_agenda = '"+tanggal+"'", "agenda");
            return ds;
        }

        public DataSet RiwayatAgenda2()
        {
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT id_agenda as[ID], agenda as [Agenda],CONVERT (VARCHAR(9),tanggal_agenda,6) as [Tanggal], catatan as [Catatan] from agenda where id = '" + Model.PenggunaModel.idUser + "' ", "agenda");
            return ds;
        }

        public bool InsertAgenda()
        {
            string tabel = "agenda";
            string data = "'" + id_record + "','" + tanggal + "','" + id + "','" + agenda + "','" + catatan + "'";
            return temp.Insert(tabel, data);
        }

        public bool HapusAgenda()
        {
            string tabel = "agenda";
            string kondisi = "id_agenda='" + id_record + "'";
            return temp.Delete(tabel, kondisi);
        }

        public bool UpdateAgenda()
        {
            string tabel = "agenda";
            string data = "tanggal_agenda = '" + tanggal + "',agenda = '" + agenda + "',catatan = '" + catatan + "' ";
            string kondisi = "id_agenda='" + id_record + "'";
            return temp.Update(tabel, data, kondisi);
        }

        public string GenerateId()
        {
            string id = "";
            string query = "SELECT max(RIGHT(id_agenda,3)) from agenda where tanggal_agenda = '" + tanggal + "'";
            DataSet data = new DataSet();
            data = temp.SelectData(query, "agenda");

            if (data.Tables[0].Rows[0][0].ToString() == "")
            {
                
                id = tanggal_id + "-" + "001";
            }
            else
            {

                

                int ambil1 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(0, 1));
                int ambil2 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 1));
                int ambil3 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                int nilai = 0;
                if (ambil1 == 9 && ambil2 == 9 && ambil3 == 9)
                {
                    penuh = true;
                }
                else if (ambil1 > 0)
                {
                    
                    nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(0, 3));
                    id = tanggal_id + "-" + (nilai + 1);
                }
                else
                {
                    ambil1 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 1));
                    ambil2 = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                    if (ambil1 == 9 && ambil2 == 9)
                    {
                        
                        nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                        id = tanggal_id + "-" + (nilai + 1);
                    }
                    else if (ambil1 > 0)
                    {
                       
                        nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                        id = tanggal_id + "-0" + (nilai + 1);
                    }
                    else
                    {
                        if (ambil2 == 9)
                        {
                            
                            nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(1, 2));
                            id = tanggal_id + "-0" + (nilai + 1);
                        }
                        else
                        {
                           
                            nilai = int.Parse(data.Tables[0].Rows[0][0].ToString().Substring(2, 1));
                            id = tanggal_id + "-00" + (nilai + 1);
                        }

                    }
                }

            }

            return id;
        }

    }
}
