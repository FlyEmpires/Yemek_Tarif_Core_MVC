﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterMessage
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public AppUser SenderWriter { get; set; } // her mesajın yalnızca bir göndericisi ve bir alıcısı vardır.
        public AppUser ReceiverWriter { get; set; }
    }
}
