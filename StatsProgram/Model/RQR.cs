//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatsProgram.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RQR
    {
        public int Id { get; set; }
        public int RespondentID { get; set; }
        public int QuestionResponseID { get; set; }
        public Nullable<decimal> Time { get; set; }
    
        public virtual QuestionResponse QuestionResponse { get; set; }
        public virtual Respondent Respondent { get; set; }
    }
}
