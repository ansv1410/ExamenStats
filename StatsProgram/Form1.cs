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

namespace StatsProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<RespondentData> RDGood = new List<RespondentData>();
            List<RespondentData> RDBad = new List<RespondentData>();


            using (informatikexamenEntities db = new informatikexamenEntities())
            {

                foreach (Respondent r in db.Respondent.ToList())
                {
                    AllData ad = new AllData(r);

                    //RQR rqr = new RQR();
                    //int rID = rqr.RespondentID;
                    //int qrID = rqr.QuestionResponseID;


                    //QuestionResponse rq = new QuestionResponse();


                    //List<RQR> rqrList = db.RQR.Where(x => x.RespondentID == r.Id).ToList();



                    if (r.UITypeID == 8)
                    {
                        RespondentData rd = new RespondentData();
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


                        //if (RDGood.Count % 10 == 0)
                        //{
                        //    MessageBox.Show(RDGood.Count.ToString());

                        //}

                    }

                    else if (r.UITypeID == 9)
                    {

                    }

                }

                MessageBox.Show(RDGood.Count.ToString());

            }


        }
    }
}

