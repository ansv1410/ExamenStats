using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using StatsProgram.Model;


namespace StatsProgram.Model
{
    public class AllData
    {
        //using (informatikexamenEntities db = new informatikexamenEntities())
        //{

        //}

        public Respondent Resp { get; set; }
        public List<Question> QList { get; set; }
        public List<RQR> RQRList { get; set; }
        public List<RQT> RQTList { get; set; }
        public List<Response> RList { get; set; }
        public List<QuestionResponse> QRList { get; set; }



        public AllData()
        {
            using (informatikexamenEntities db = new informatikexamenEntities())
            {
                RQRList = db.RQR.ToList();
                RQTList = db.RQT.ToList();
                RList = db.Response.ToList();
                QRList = db.QuestionResponse.ToList();
                QList = db.Question.ToList();
            }
        }
        public AllData(Respondent r, AllData ad)
        {

            List<QuestionResponse> tempList = ad.QRList;

            RList = ad.RList;

            QRList = new List<QuestionResponse>();

            List<Question> ql = ad.QList;


            RQRList = ad.RQRList.Where(x => x.RespondentID == r.Id).ToList();
            RQTList = ad.RQTList.Where(x => x.RespondentID == r.Id).ToList();



            foreach (RQR rqr in RQRList)
            {
                foreach (QuestionResponse qr in tempList)
                {
                    if (qr.Id == rqr.QuestionResponseID)
                    {
                        QRList.Add(qr);
                    }
                }
            }

        }
        //public AllData(Respondent r)
        //{

        //    using (informatikexamenEntities db = new informatikexamenEntities())
        //    {

        //        List<QuestionResponse> tempList = db.QuestionResponse.ToList();

        //        RList = db.Response.ToList();

        //        QRList = new List<QuestionResponse>();

        //        List<Question> ql = db.Question.ToList();


        //        RQRList = db.RQR.Where(x => x.RespondentID == r.Id).ToList();
        //        RQTList = db.RQT.Where(x => x.RespondentID == r.Id).ToList();



        //        foreach (RQR rqr in RQRList)
        //        {
        //            foreach (QuestionResponse qr in tempList)
        //            {
        //                if (qr.Id == rqr.QuestionResponseID)
        //                {
        //                    QRList.Add(qr);
        //                }
        //            }
        //        }
        //    }
        //}
        public string GetAnswer(int qID)
        {
            Response response = new Response();
            response.ResponseText = "Saknas";
            using (informatikexamenEntities db = new informatikexamenEntities())
            {
                foreach (QuestionResponse qr in QRList)
                {
                    if (qr.QuestionID == qID)
                    {
                        response = RList.Where(x => x.Id == qr.ResponseID).FirstOrDefault();
                    }
                }
            }
            return response.ResponseText;
        }

        public decimal GetTime(int qID)
        {
            decimal time = 0;
            foreach (QuestionResponse qr in QRList)
            {
                if (qr.QuestionID == qID)
                {
                    foreach (RQR rqr in RQRList)
                    {
                        if (rqr.QuestionResponseID == qr.Id)
                        {
                            decimal.TryParse(Convert.ToString(rqr.Time), out time);
                        }
                    }
                }
            }
            return time;
        }

        public decimal GetTextTime(int qID)
        {
            decimal time = 0;
            foreach (RQT rqt in RQTList)
            {
                if (rqt.QuestionID == qID)
                {
                    decimal.TryParse(Convert.ToString(rqt.Time), out time);
                }
            }
            return time;
        }
    }
}
