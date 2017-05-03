using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsProgram.Model
{
    class QuestionInfo
    {
        public Question Q { get; set; }
        public List<Response> R { get; set; }
        public List<QuestionResponse> QR { get; set; }

        public QuestionInfo(Question q)
        {
            Q = q;
            R = new List<Response>();

            using (informatikexamenEntities db = new informatikexamenEntities())
            {
                QR = db.QuestionResponse.Where(x => x.QuestionID == Q.Id).ToList();

                foreach (QuestionResponse qr in QR)
                {
                    R.Add(db.Response.Where(x => x.Id == qr.ResponseID).FirstOrDefault());


                }

            } 
        }
    }
}
