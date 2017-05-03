using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatsProgram.Model;
using System.Reflection;

namespace StatsProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<RespondentDataGood> RDGood = new List<RespondentDataGood>();
            List<RespondentDataBad> RDBad = new List<RespondentDataBad>();

            using (informatikexamenEntities db = new informatikexamenEntities())
            {
                List<Respondent> RespondentList = db.Respondent.ToList();

                AllData AllData = new AllData();



                foreach (Respondent r in RespondentList)
                {

                    AllData ad = new AllData(r, AllData);
                    //RQR rqr = new RQR();
                    //int rID = rqr.RespondentID;
                    //int qrID = rqr.QuestionResponseID;


                    //QuestionResponse rq = new QuestionResponse();


                    //List<RQR> rqrList = db.RQR.Where(x => x.RespondentID == r.Id).ToList();

                    if (r.UITypeID == 8)
                    {
                        RespondentDataGood rd = new RespondentDataGood();
                        rd.RespondentId = r.Id;
                        rd.Age = ad.GetAnswer(14);
                        rd.Gender = ad.GetAnswer(13);
                        rd.Language = ad.GetAnswer(15);
                        rd.InternetUse = ad.GetAnswer(17);
                        rd.InternetUseComp = ad.GetAnswer(18);
                        rd.InternetUseSmart = ad.GetAnswer(19);

                        var webDesignAnswer = ad.GetAnswer(16);
                        if (webDesignAnswer == "Ja")
                        {
                            rd.WebDesign = true;
                        }
                        else if (webDesignAnswer == "Nej")
                        {
                            rd.WebDesign = false;
                        }

                        rd.LogInFind = r.LogInFind;
                        rd.LogInClick = r.LogInClick;
                        rd.Qstart = r.QStart;
                        rd.TimeFirstQ = ad.GetTime(13);
                        rd.RQRTime2 = ad.GetTime(14);
                        rd.RQRTime3 = ad.GetTime(15);
                        rd.RQRTime4 = ad.GetTime(16);
                        rd.RQRTime5 = ad.GetTime(17);
                        rd.RQRTime6 = ad.GetTime(18);
                        rd.TimeLastRQR = ad.GetTime(19);
                        rd.RQTTime1 = ad.GetTextTime(8);
                        rd.RQTTime2 = ad.GetTextTime(9);
                        rd.RQTTime3 = ad.GetTextTime(11);

                        RDGood.Add(rd);
                    }

                    else if (r.UITypeID == 9)
                    {
                        RespondentDataBad rd = new RespondentDataBad();
                        rd.RespondentId = r.Id;
                        rd.Age = ad.GetAnswer(14);
                        rd.Gender = ad.GetAnswer(13);
                        rd.Language = ad.GetAnswer(15);
                        rd.InternetUse = ad.GetAnswer(17);
                        rd.InternetUseComp = ad.GetAnswer(18);
                        rd.InternetUseSmart = ad.GetAnswer(19);

                        var webDesignAnswer = ad.GetAnswer(16);
                        if (webDesignAnswer == "Ja")
                        {
                            rd.WebDesign = true;
                        }
                        else if (webDesignAnswer == "Nej")
                        {
                            rd.WebDesign = false;
                        }

                        rd.LogInFind = r.LogInFind;
                        rd.LogInClick = r.LogInClick;
                        rd.Qstart = r.QStart;
                        rd.TimeFirstQ = ad.GetTime(13);
                        rd.RQRTime2 = ad.GetTime(14);
                        rd.RQRTime3 = ad.GetTime(15);
                        rd.RQRTime4 = ad.GetTime(16);
                        rd.RQRTime5 = ad.GetTime(17);
                        rd.RQRTime6 = ad.GetTime(18);
                        rd.TimeLastRQR = ad.GetTime(19);
                        rd.RQTTime1 = ad.GetTextTime(8);
                        rd.RQTTime2 = ad.GetTextTime(9);
                        rd.RQTTime3 = ad.GetTextTime(11);

                        RDBad.Add(rd);
                    }
                }

                DataTable dtGood = new DataTable();
                DataTable dtBad = new DataTable();

                dtGood = ToDataTable(RDGood);
                dtBad = ToDataTable(RDBad);


                dgvGood.DataSource = dtGood;
                dgvBad.DataSource = dtBad;

                MessageBox.Show("GOOD " + RDGood.Count.ToString());

                MessageBox.Show("BAD " + RDBad.Count.ToString());

            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}

