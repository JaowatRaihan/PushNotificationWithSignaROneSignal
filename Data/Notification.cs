using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Notification
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }

        public string Message { get; set; }

        public string Url { get; set; }

        public int? StatusID { get; set; }

        public DateTime? readDate { get; set; }

        public int? PostedBy { get; set; }

        public DateTime? PostedDate { get; set; }


    }
}
