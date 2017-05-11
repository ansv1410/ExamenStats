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

                        rd.LogInFind = 0;
                        rd.LogInClick = 0;
                        rd.Qstart = 0;
                        if(r.LogInFind != null)
                        {
                            rd.LogInFind = r.LogInFind;
                        }
                        if (r.LogInClick != null)
                        {
                            rd.LogInClick = r.LogInClick;
                        }
                        if (r.QStart != null)
                        {
                            rd.Qstart = r.QStart;
                        }
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
                        rd.LogInFind = 0;
                        rd.LogInClick = 0;
                        rd.Qstart = 0;
                        if (r.LogInFind != null)
                        {
                            rd.LogInFind = r.LogInFind;
                        }
                        if (r.LogInClick != null)
                        {
                            rd.LogInClick = r.LogInClick;
                        }
                        if (r.QStart != null)
                        {
                            rd.Qstart = r.QStart;
                        }
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


                dtGood = ToDataTable(DeleteGoodNulls(RDGood));
                dtBad = ToDataTable(DeleteBadNulls(RDBad));

                dgvGood.DataSource = dtGood;
                dgvBad.DataSource = dtBad;

                MessageBox.Show("GOOD " + RDGood.Count.ToString());
                MessageBox.Show("NEW GOOD " + dtGood.Rows.Count);


                MessageBox.Show("BAD " + RDBad.Count.ToString());
                MessageBox.Show("NEW BAD " + dtBad.Rows.Count);

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


        public List<RespondentDataGood> DeleteGoodNulls(List<RespondentDataGood> goodData)
        {
            List<RespondentDataGood> rg = new List<RespondentDataGood>();

            decimal LfGood = 0;

            foreach (RespondentDataGood rdg in goodData)
            {
                if (!(rdg.LogInClick == 0 && rdg.LogInFind == 0 && rdg.Qstart == 0 &&
                    rdg.TimeFirstQ == 0 && rdg.RQRTime2 == 0 && rdg.RQRTime3 == 0 && rdg.RQRTime4 == 0 && rdg.RQRTime5 == 0 && rdg.RQRTime6 == 0 &&
                    rdg.TimeLastRQR == 0 && rdg.RQTTime1 == 0 && rdg.RQTTime2 == 0 && rdg.RQTTime3 == 0))
                {
                    rg.Add(rdg);
                }
                //if (!(rdg.LogInClick == 0 || rdg.LogInFind == 0 || rdg.Qstart == 0 ||
                //    rdg.TimeFirstQ == 0 || rdg.RQRTime2 == 0 || rdg.RQRTime3 == 0 || rdg.RQRTime4 == 0 || rdg.RQRTime5 == 0 || rdg.RQRTime6 == 0 ||
                //    rdg.TimeLastRQR == 0 || rdg.RQTTime1 == 0 || rdg.RQTTime2 == 0 || rdg.RQTTime3 == 0))
                //{
                //    rg.Add(rdg);
                //}
            }
            List<RespondentDataGood> sortedList = rg.OrderBy(x => x.LogInFind).ToList();

            sortedList.RemoveRange(0, 6);
            sortedList.RemoveRange(sortedList.Count - 6, 6);

            foreach (RespondentDataGood r in sortedList)
            {
                LfGood += Convert.ToDecimal(r.LogInFind);
            }

            MessageBox.Show("GOOD Snitt: " + Convert.ToString(LfGood / sortedList.Count));
            VariableDataGood(sortedList);
            return sortedList;
        }

        public List<RespondentDataBad> DeleteBadNulls(List<RespondentDataBad> badData)
        {
            List<RespondentDataBad> rb = new List<RespondentDataBad>();

            decimal LfBad = 0;

            foreach (RespondentDataBad rdb in badData)
            {
                if (!(rdb.LogInClick == 0 && rdb.LogInFind == 0 && rdb.Qstart == 0 &&
                    rdb.TimeFirstQ == 0 && rdb.RQRTime2 == 0 && rdb.RQRTime3 == 0 && rdb.RQRTime4 == 0 && rdb.RQRTime5 == 0 && rdb.RQRTime6 == 0 &&
                    rdb.TimeLastRQR == 0 && rdb.RQTTime1 == 0 && rdb.RQTTime2 == 0 && rdb.RQTTime3 == 0))
                {
                    rb.Add(rdb);
                }
                //if (!(rdb.LogInClick == 0 || rdb.LogInFind == 0 || rdb.Qstart == 0 ||
                //    rdb.TimeFirstQ == 0 || rdb.RQRTime2 == 0 || rdb.RQRTime3 == 0 || rdb.RQRTime4 == 0 || rdb.RQRTime5 == 0 || rdb.RQRTime6 == 0 ||
                //    rdb.TimeLastRQR == 0 || rdb.RQTTime1 == 0 || rdb.RQTTime2 == 0 || rdb.RQTTime3 == 0))
                //{
                //    rb.Add(rdb);
                //}
            }
            //rb.Sort((x, y) => x.LogInFind.CompareTo(y.LogInFind));
            List<RespondentDataBad> sortedList = rb.OrderBy(x => x.LogInFind).ToList();

            sortedList.RemoveRange(0, 6);
            sortedList.RemoveRange(sortedList.Count - 6, 6);

            foreach(RespondentDataBad r in sortedList)
            {
                LfBad += Convert.ToDecimal(r.LogInFind);
            }

            MessageBox.Show("BAD Snitt: " + Convert.ToString(LfBad / sortedList.Count));
            return sortedList;
        }

        public void VariableDataGood(List<RespondentDataGood> fullList)
        {
            decimal countLoginFind = 0;
            decimal totalLoginFind = 0;
            decimal countLoginClick = 0;
            decimal totalLoginClick = 0;
            decimal countQstart = 0;
            decimal totalQstart = 0;
            decimal countTimeFirstQ = 0;
            decimal totalTimeFirstQ = 0;
            decimal countRQRTime2 = 0;
            decimal totalRQRTime2 = 0;
            decimal countRQRTime3 = 0;
            decimal totalRQRTime3 = 0;
            decimal countRQRTime4 = 0;
            decimal totalRQRTime4 = 0;
            decimal countRQRTime5 = 0;
            decimal totalRQRTime5 = 0;
            decimal countRQRTime6 = 0;
            decimal totalRQRTime6 = 0;
            decimal countTimeLastRQR = 0;
            decimal totalTimeLastRQR = 0;
            decimal countRQTTime1 = 0;
            decimal totalRQTTime1 = 0;
            decimal countRQTTime2 = 0;
            decimal totalRQTTime2 = 0;
            decimal countRQTTime3 = 0;
            decimal totalRQTTime3 = 0;

            foreach(RespondentDataGood rd in fullList){
                if (rd.LogInFind != 0)
                {
                    countLoginFind++;
                    totalLoginFind += Convert.ToDecimal(rd.LogInFind);
                }
                if (rd.LogInClick != 0)
                {
                    countLoginClick++;
                    totalLoginClick += Convert.ToDecimal(rd.LogInClick);
                }
                if (rd.Qstart != 0)
                {
                    countQstart++;
                    totalQstart += Convert.ToDecimal(rd.Qstart);
                }
                if (rd.TimeFirstQ != 0)
                {
                    countTimeFirstQ++;
                    totalTimeFirstQ += Convert.ToDecimal(rd.TimeFirstQ);
                }
                if (rd.RQRTime2 != 0)
                {
                    countRQRTime2++;
                    totalRQRTime2 += Convert.ToDecimal(rd.RQRTime2);
                }
                if (rd.RQRTime3 != 0)
                {
                    countRQRTime3++;
                    totalRQRTime3 += Convert.ToDecimal(rd.RQRTime3);
                }
                if (rd.RQRTime4 != 0)
                {
                    countRQRTime4++;
                    totalRQRTime4 += Convert.ToDecimal(rd.RQRTime4);
                }
                if (rd.RQRTime5 != 0)
                {
                    countRQRTime5++;
                    totalRQRTime5 += Convert.ToDecimal(rd.RQRTime5);
                }
                if (rd.RQRTime6 != 0)
                {
                    countRQRTime6++;
                    totalRQRTime6 += Convert.ToDecimal(rd.RQRTime6);
                }
                if (rd.TimeLastRQR != 0)
                {
                    countTimeLastRQR++;
                    totalTimeLastRQR += Convert.ToDecimal(rd.TimeLastRQR);
                }
                if (rd.RQTTime1 != 0)
                {
                    countRQTTime1++;
                    totalRQTTime1 += Convert.ToDecimal(rd.RQTTime1);
                }
                if (rd.RQTTime2 != 0)
                {
                    countRQTTime2++;
                    totalRQTTime2 += Convert.ToDecimal(rd.RQTTime2);
                }
                if (rd.RQTTime3 != 0)
                {
                    countRQTTime3++;
                    totalRQTTime3 += Convert.ToDecimal(rd.RQTTime3);
                }
            }
            lblLogInFindCountG.Text = countLoginFind.ToString();
            lblLogInFindTotalG.Text = totalLoginFind.ToString();
            lblLogInFindAvgG.Text = (totalLoginFind / countLoginFind).ToString();
        }

    }
}

