﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MTBS.NotificationAPI.Models
{
    public class EmailLog
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string LogText { get; set; }
        public DateTime EmailSent { get; set; }
    }
}
