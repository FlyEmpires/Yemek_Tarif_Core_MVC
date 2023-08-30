using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl{ get; set; }
        //public string UserName { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }

        public int DistrictID { get; set; }
        public District District { get; set; }

        public List<Recipe> Recipe { get; set; }


        public ICollection<WriterMessage> WriterSender { get; set; }
        public ICollection<WriterMessage> WriterReceiver { get; set; }
    }
}
