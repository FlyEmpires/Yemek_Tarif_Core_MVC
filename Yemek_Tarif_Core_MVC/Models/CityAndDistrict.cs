using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Yemek_Tarif_Core_MVC.Models
{
    public class CityAndDistrict
    {
        public int SelectedCityID { get; set; }
        public List<City> City{ get; set; }
        public List<District> District{ get; set; }
        public int DistrictID{ get; set; }


    }
}
