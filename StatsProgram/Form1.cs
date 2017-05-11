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
        List<RespondentDataGood> RDGood = new List<RespondentDataGood>();
        List<RespondentDataBad> RDBad = new List<RespondentDataBad>();
        public Form1()
        {
            InitializeComponent();


            using (informatikexamenEntities db = new informatikexamenEntities())
            {
                List<Respondent> RespondentList = db.Respondent.ToList();

                AllData AllData = new AllData();



                foreach (Respondent r in RespondentList)
                {

                    AllData ad = new AllData(r, AllData);

                    if (r.UITypeID == 8 && ad.GetAnswer(15) != "Annat")
                    {
                        RespondentDataGood rd = new RespondentDataGood();
                        rd.RespondentId = r.Id;
                        rd.Age = ad.GetAnswer(14);
                        rd.Gender = ad.GetAnswer(13);
                        rd.Language = ad.GetAnswer(15);
                        rd.InternetUse = ad.GetAnswer(17);
                        rd.InternetUseComp = ad.GetAnswer(18);
                        rd.InternetUseSmart = ad.GetAnswer(19);
                        rd.BrowserType = r.BrowserType;

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

                    else if (r.UITypeID == 9 && ad.GetAnswer(15) != "Annat")
                    {
                        RespondentDataBad rd = new RespondentDataBad();
                        rd.RespondentId = r.Id;
                        rd.Age = ad.GetAnswer(14);
                        rd.Gender = ad.GetAnswer(13);
                        rd.Language = ad.GetAnswer(15);
                        rd.InternetUse = ad.GetAnswer(17);
                        rd.InternetUseComp = ad.GetAnswer(18);
                        rd.InternetUseSmart = ad.GetAnswer(19);
                        rd.BrowserType = r.BrowserType;

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


        public List<RespondentDataGood> DeleteGoodNulls(List<RespondentDataGood> goodData) ///INPUT TILL DENNA FRÅN FILTERKNAPPAR
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
            }
            
            VariableDataGood(rg);
            return rg;
        }

        public List<RespondentDataBad> DeleteBadNulls(List<RespondentDataBad> badData)  ///INPUT TILL DENNA FRÅN FILTERKNAPPAR
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
            }
            
            VariableDataBad(rb);
            return rb;
        }

        public decimal getStats(List<decimal> theList, out decimal count)
        {
            theList.Sort();
            int noToRemove = Convert.ToInt16(theList.Count * 0.05);

            theList.RemoveRange(0, noToRemove);
            theList.RemoveRange(theList.Count - noToRemove, noToRemove);

            decimal total = theList.Sum();
            count = theList.Count;

            return total;
        }

        public void VariableDataGood(List<RespondentDataGood> fullList)
        {
            
            List<decimal> loginFindList = new List<decimal>();
            List<decimal> loginClickList = new List<decimal>();
            List<decimal> QstartList = new List<decimal>();
            List<decimal> TimeFirstQList = new List<decimal>();
            List<decimal> RQRTime2List = new List<decimal>();
            List<decimal> RQRTime3List = new List<decimal>();
            List<decimal> RQRTime4List = new List<decimal>();
            List<decimal> RQRTime5List = new List<decimal>();
            List<decimal> RQRTime6List = new List<decimal>();
            List<decimal> TimeLastRQRList = new List<decimal>();
            List<decimal> RQTTime1List = new List<decimal>();
            List<decimal> RQTTime2List = new List<decimal>();
            List<decimal> RQTTime3List = new List<decimal>();

            foreach(RespondentDataGood rd in fullList){
                if (rd.LogInFind != 0)
                {
                    loginFindList.Add(Convert.ToDecimal(rd.LogInFind));
                }
                if (rd.LogInClick != 0)
                {
                    loginClickList.Add(Convert.ToDecimal(rd.LogInClick));
                }
                if (rd.Qstart != 0)
                {
                    QstartList.Add(Convert.ToDecimal(rd.Qstart));
                }
                if (rd.TimeFirstQ != 0)
                {
                    TimeFirstQList.Add(Convert.ToDecimal(rd.TimeFirstQ));
                }
                if (rd.RQRTime2 != 0)
                {
                    RQRTime2List.Add(Convert.ToDecimal(rd.RQRTime2));
                }
                if (rd.RQRTime3 != 0)
                {
                    RQRTime3List.Add(Convert.ToDecimal(rd.RQRTime3));
                }
                if (rd.RQRTime4 != 0)
                {
                    RQRTime4List.Add(Convert.ToDecimal(rd.RQRTime4));
                }
                if (rd.RQRTime5 != 0)
                {
                    RQRTime5List.Add(Convert.ToDecimal(rd.RQRTime5));
                }
                if (rd.RQRTime6 != 0)
                {
                    RQRTime6List.Add(Convert.ToDecimal(rd.RQRTime6));
                }
                if (rd.TimeLastRQR != 0)
                {
                    TimeLastRQRList.Add(Convert.ToDecimal(rd.TimeLastRQR));
                }
                if (rd.RQTTime1 != 0)
                {
                    RQTTime1List.Add(Convert.ToDecimal(rd.RQTTime1));
                }
                if (rd.RQTTime2 != 0)
                {
                    RQTTime2List.Add(Convert.ToDecimal(rd.RQTTime2));
                }
                if (rd.RQTTime3 != 0)
                {
                    RQTTime3List.Add(Convert.ToDecimal(rd.RQTTime3));
                }
            }

            decimal countLoginFind = 0;
            decimal totalLoginFind = getStats(loginFindList, out countLoginFind);
            decimal countLoginClick = 0;
            decimal totalLoginClick = getStats(loginClickList, out countLoginClick);
            decimal countQstart = 0;
            decimal totalQstart = getStats(QstartList, out countQstart);
            decimal countTimeFirstQ = 0;
            decimal totalTimeFirstQ = getStats(TimeFirstQList, out countTimeFirstQ);
            decimal countRQRTime2 = 0;
            decimal totalRQRTime2 = getStats(RQRTime2List, out countRQRTime2);
            decimal countRQRTime3 = 0;
            decimal totalRQRTime3 = getStats(RQRTime3List, out countRQRTime3);
            decimal countRQRTime4 = 0;
            decimal totalRQRTime4 = getStats(RQRTime4List, out countRQRTime4);
            decimal countRQRTime5 = 0;
            decimal totalRQRTime5 = getStats(RQRTime5List, out countRQRTime5);
            decimal countRQRTime6 = 0;
            decimal totalRQRTime6 = getStats(RQRTime6List, out countRQRTime6);
            decimal countTimeLastRQR = 0;
            decimal totalTimeLastRQR = getStats(TimeLastRQRList, out countTimeLastRQR);
            decimal countRQTTime1 = 0;
            decimal totalRQTTime1 = getStats(RQTTime1List, out countRQTTime1);
            decimal countRQTTime2 = 0;
            decimal totalRQTTime2 = getStats(RQTTime2List, out countRQTTime2);
            decimal countRQTTime3 = 0;
            decimal totalRQTTime3 = getStats(RQTTime3List, out countRQTTime3);
            
            lblLogInFindCountG.Text = Convert.ToInt64(countLoginFind).ToString();
            lblLogInFindTotalG.Text = Convert.ToInt64(totalLoginFind).ToString();
            lblLogInFindAvgG.Text = Convert.ToInt64((totalLoginFind / countLoginFind)).ToString();

            lblLogInClickCountG.Text = Convert.ToInt64(countLoginClick).ToString();
            lblLogInClickTotalG.Text = Convert.ToInt64(totalLoginClick).ToString();
            lblLogInClickAvgG.Text = Convert.ToInt64((totalLoginClick / countLoginClick)).ToString();

            lblQstartCountG.Text = Convert.ToInt64(countQstart).ToString();
            lblQstartTotalG.Text = Convert.ToInt64(totalQstart).ToString();
            lblQstartAvgG.Text = Convert.ToInt64((totalQstart / countQstart)).ToString();

            lblFirstTimeQCountG.Text = Convert.ToInt64(countTimeFirstQ).ToString();
            lblFirstTimeQTotalG.Text = Convert.ToInt64(totalTimeFirstQ).ToString();
            lblFirstTimeQAvgG.Text = Convert.ToInt64((totalTimeFirstQ / countTimeFirstQ)).ToString();

            lblRQRTime2CountG.Text = Convert.ToInt64(countRQRTime2).ToString();
            lblRQRTime2TotalG.Text = Convert.ToInt64(totalRQRTime2).ToString();
            lblRQRTime2AvgG.Text = Convert.ToInt64((totalRQRTime2 / countRQRTime2)).ToString();

            lblRQRTime3CountG.Text = Convert.ToInt64(countRQRTime3).ToString();
            lblRQRTime3TotalG.Text = Convert.ToInt64(totalRQRTime3).ToString();
            lblRQRTime3AvgG.Text = Convert.ToInt64((totalRQRTime3 / countRQRTime3)).ToString();

            lblRQRTime4CountG.Text = Convert.ToInt64(countRQRTime4).ToString();
            lblRQRTime4TotalG.Text = Convert.ToInt64(totalRQRTime4).ToString();
            lblRQRTime4AvgG.Text = Convert.ToInt64((totalRQRTime4 / countRQRTime4)).ToString();

            lblRQRTime5CountG.Text = Convert.ToInt64(countRQRTime5).ToString();
            lblRQRTime5TotalG.Text = Convert.ToInt64(totalRQRTime5).ToString();
            lblRQRTime5AvgG.Text = Convert.ToInt64((totalRQRTime5 / countRQRTime5)).ToString();

            lblRQRTime6CountG.Text = Convert.ToInt64(countRQRTime6).ToString();
            lblRQRTime6TotalG.Text = Convert.ToInt64(totalRQRTime6).ToString();
            lblRQRTime6AvgG.Text = Convert.ToInt64((totalRQRTime6 / countRQRTime6)).ToString();

            lblTimeLastRQRCountG.Text = Convert.ToInt64(countTimeLastRQR).ToString();
            lblTimeLastRQRTotalG.Text = Convert.ToInt64(totalTimeLastRQR).ToString();
            lblTimeLastRQRAvgG.Text = Convert.ToInt64((totalTimeLastRQR / countTimeLastRQR)).ToString();

            lblRQTTime1CountG.Text = Convert.ToInt64(countRQTTime1).ToString();
            lblRQTTime1TotalG.Text = Convert.ToInt64(totalRQTTime1).ToString();
            lblRQTTime1AvgG.Text = Convert.ToInt64((totalRQTTime1 / countRQTTime1)).ToString();

            lblRQTTime2CountG.Text = Convert.ToInt64(countRQTTime2).ToString();
            lblRQTTime2TotalG.Text = Convert.ToInt64(totalRQTTime2).ToString();
            lblRQTTime2AvgG.Text = Convert.ToInt64((totalRQTTime2 / countRQTTime2)).ToString();

            lblRQTTime3CountG.Text = Convert.ToInt64(countRQTTime3).ToString();
            lblRQTTime3TotalG.Text = Convert.ToInt64(totalRQTTime3).ToString();
            lblRQTTime3AvgG.Text = Convert.ToInt64((totalRQTTime3 / countRQTTime3)).ToString();
        }

        public void VariableDataBad(List<RespondentDataBad> fullList)
        {
            List<decimal> loginFindList = new List<decimal>();
            List<decimal> loginClickList = new List<decimal>();
            List<decimal> QstartList = new List<decimal>();
            List<decimal> TimeFirstQList = new List<decimal>();
            List<decimal> RQRTime2List = new List<decimal>();
            List<decimal> RQRTime3List = new List<decimal>();
            List<decimal> RQRTime4List = new List<decimal>();
            List<decimal> RQRTime5List = new List<decimal>();
            List<decimal> RQRTime6List = new List<decimal>();
            List<decimal> TimeLastRQRList = new List<decimal>();
            List<decimal> RQTTime1List = new List<decimal>();
            List<decimal> RQTTime2List = new List<decimal>();
            List<decimal> RQTTime3List = new List<decimal>();

            foreach (RespondentDataBad rd in fullList)
            {
                if (rd.LogInFind != 0)
                {
                    loginFindList.Add(Convert.ToDecimal(rd.LogInFind));
                }
                if (rd.LogInClick != 0)
                {
                    loginClickList.Add(Convert.ToDecimal(rd.LogInClick));
                }
                if (rd.Qstart != 0)
                {
                    QstartList.Add(Convert.ToDecimal(rd.Qstart));
                }
                if (rd.TimeFirstQ != 0)
                {
                    TimeFirstQList.Add(Convert.ToDecimal(rd.TimeFirstQ));
                }
                if (rd.RQRTime2 != 0)
                {
                    RQRTime2List.Add(Convert.ToDecimal(rd.RQRTime2));
                }
                if (rd.RQRTime3 != 0)
                {
                    RQRTime3List.Add(Convert.ToDecimal(rd.RQRTime3));
                }
                if (rd.RQRTime4 != 0)
                {
                    RQRTime4List.Add(Convert.ToDecimal(rd.RQRTime4));
                }
                if (rd.RQRTime5 != 0)
                {
                    RQRTime5List.Add(Convert.ToDecimal(rd.RQRTime5));
                }
                if (rd.RQRTime6 != 0)
                {
                    RQRTime6List.Add(Convert.ToDecimal(rd.RQRTime6));
                }
                if (rd.TimeLastRQR != 0)
                {
                    TimeLastRQRList.Add(Convert.ToDecimal(rd.TimeLastRQR));
                }
                if (rd.RQTTime1 != 0)
                {
                    RQTTime1List.Add(Convert.ToDecimal(rd.RQTTime1));
                }
                if (rd.RQTTime2 != 0)
                {
                    RQTTime2List.Add(Convert.ToDecimal(rd.RQTTime2));
                }
                if (rd.RQTTime3 != 0)
                {
                    RQTTime3List.Add(Convert.ToDecimal(rd.RQTTime3));
                }
            }

            decimal countLoginFind = 0;
            decimal totalLoginFind = getStats(loginFindList, out countLoginFind);
            decimal countLoginClick = 0;
            decimal totalLoginClick = getStats(loginClickList, out countLoginClick);
            decimal countQstart = 0;
            decimal totalQstart = getStats(QstartList, out countQstart);
            decimal countTimeFirstQ = 0;
            decimal totalTimeFirstQ = getStats(TimeFirstQList, out countTimeFirstQ);
            decimal countRQRTime2 = 0;
            decimal totalRQRTime2 = getStats(RQRTime2List, out countRQRTime2);
            decimal countRQRTime3 = 0;
            decimal totalRQRTime3 = getStats(RQRTime3List, out countRQRTime3);
            decimal countRQRTime4 = 0;
            decimal totalRQRTime4 = getStats(RQRTime4List, out countRQRTime4);
            decimal countRQRTime5 = 0;
            decimal totalRQRTime5 = getStats(RQRTime5List, out countRQRTime5);
            decimal countRQRTime6 = 0;
            decimal totalRQRTime6 = getStats(RQRTime6List, out countRQRTime6);
            decimal countTimeLastRQR = 0;
            decimal totalTimeLastRQR = getStats(TimeLastRQRList, out countTimeLastRQR);
            decimal countRQTTime1 = 0;
            decimal totalRQTTime1 = getStats(RQTTime1List, out countRQTTime1);
            decimal countRQTTime2 = 0;
            decimal totalRQTTime2 = getStats(RQTTime2List, out countRQTTime2);
            decimal countRQTTime3 = 0;
            decimal totalRQTTime3 = getStats(RQTTime3List, out countRQTTime3);

            lblLogInFindCountB.Text = Convert.ToInt64(countLoginFind).ToString();
            lblLogInFindTotalB.Text = Convert.ToInt64(totalLoginFind).ToString();
            lblLogInFindAvgB.Text = Convert.ToInt64((totalLoginFind / countLoginFind)).ToString();

            lblLogInClickCountB.Text = Convert.ToInt64(countLoginClick).ToString();
            lblLogInClickTotalB.Text = Convert.ToInt64(totalLoginClick).ToString();
            lblLogInClickAvgB.Text = Convert.ToInt64((totalLoginClick / countLoginClick)).ToString();

            lblQstartCountB.Text = Convert.ToInt64(countQstart).ToString();
            lblQstartTotalB.Text = Convert.ToInt64(totalQstart).ToString();
            lblQstartAvgB.Text = Convert.ToInt64((totalQstart / countQstart)).ToString();

            lblFirstTimeQCountB.Text = Convert.ToInt64(countTimeFirstQ).ToString();
            lblFirstTimeQTotalB.Text = Convert.ToInt64(totalTimeFirstQ).ToString();
            lblFirstTimeQAvgB.Text = Convert.ToInt64((totalTimeFirstQ / countTimeFirstQ)).ToString();

            lblRQRTime2CountB.Text = Convert.ToInt64(countRQRTime2).ToString();
            lblRQRTime2TotalB.Text = Convert.ToInt64(totalRQRTime2).ToString();
            lblRQRTime2AvgB.Text = Convert.ToInt64((totalRQRTime2 / countRQRTime2)).ToString();

            lblRQRTime3CountB.Text = Convert.ToInt64(countRQRTime3).ToString();
            lblRQRTime3TotalB.Text = Convert.ToInt64(totalRQRTime3).ToString();
            lblRQRTime3AvgB.Text = Convert.ToInt64((totalRQRTime3 / countRQRTime3)).ToString();

            lblRQRTime4CountB.Text = Convert.ToInt64(countRQRTime4).ToString();
            lblRQRTime4TotalB.Text = Convert.ToInt64(totalRQRTime4).ToString();
            lblRQRTime4AvgB.Text = Convert.ToInt64((totalRQRTime4 / countRQRTime4)).ToString();

            lblRQRTime5CountB.Text = Convert.ToInt64(countRQRTime5).ToString();
            lblRQRTime5TotalB.Text = Convert.ToInt64(totalRQRTime5).ToString();
            lblRQRTime5AvgB.Text = Convert.ToInt64((totalRQRTime5 / countRQRTime5)).ToString();

            lblRQRTime6CountB.Text = Convert.ToInt64(countRQRTime6).ToString();
            lblRQRTime6TotalB.Text = Convert.ToInt64(totalRQRTime6).ToString();
            lblRQRTime6AvgB.Text = Convert.ToInt64((totalRQRTime6 / countRQRTime6)).ToString();

            lblTimeLastRQRCountB.Text = Convert.ToInt64(countTimeLastRQR).ToString();
            lblTimeLastRQRTotalB.Text = Convert.ToInt64(totalTimeLastRQR).ToString();
            lblTimeLastRQRAvgB.Text = Convert.ToInt64((totalTimeLastRQR / countTimeLastRQR)).ToString();

            lblRQTTime1CountB.Text = Convert.ToInt64(countRQTTime1).ToString();
            lblRQTTime1TotalB.Text = Convert.ToInt64(totalRQTTime1).ToString();
            lblRQTTime1AvgB.Text = Convert.ToInt64((totalRQTTime1 / countRQTTime1)).ToString();

            lblRQTTime2CountB.Text = Convert.ToInt64(countRQTTime2).ToString();
            lblRQTTime2TotalB.Text = Convert.ToInt64(totalRQTTime2).ToString();
            lblRQTTime2AvgB.Text = Convert.ToInt64((totalRQTTime2 / countRQTTime2)).ToString();

            lblRQTTime3CountB.Text = Convert.ToInt64(countRQTTime3).ToString();
            lblRQTTime3TotalB.Text = Convert.ToInt64(totalRQTTime3).ToString();
            lblRQTTime3AvgB.Text = Convert.ToInt64((totalRQTTime3 / countRQTTime3)).ToString();
        }



    }
}

