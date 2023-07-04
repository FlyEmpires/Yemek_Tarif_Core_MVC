using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer.ViewModel
{
    public class WriterCityViewModel
    {
        //public List<City> Cities { get; set; }
        //public int SelectedCityId { get; set; }
        public Writer Writers { get; set; }

        public int SelectedCityID { get; set; }
        public List<City> City { get; set; }
        public List<District> District { get; set; }
        public int DistrictID { get; set; }
    }
}
