using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public City City { get; set; }
        public int Id { get; set; }
    }
}
