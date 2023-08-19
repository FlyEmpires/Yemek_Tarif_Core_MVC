﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public List<Recipe> Recipes { get; set; }
        //public City City { get; set; }
        //public District District { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public ICollection<Message> WriterSender { get; set; }
        public ICollection<Message> WriterReceiver { get; set; }

    }
}
