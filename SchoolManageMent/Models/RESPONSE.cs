namespace SchoolManageMent.Models
{
    public class RESPONSE
    {

        public string status { get; set; }

        public string message { get; set; }

        public dynamic data { get; set; }

        public int  recordcount { get; set; }

        public int pagenumber { get; set; }
  
    }
}
