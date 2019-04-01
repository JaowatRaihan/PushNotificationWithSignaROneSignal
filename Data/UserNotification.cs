﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserNotification
    {
        [Key]
        public Guid ID { get; set; }

        public string UserID { get; set; }

        public string PlayerID { get; set; }
    }
}
