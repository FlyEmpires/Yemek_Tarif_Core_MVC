using System.ComponentModel.DataAnnotations;

namespace YemekTarifApi.Controllers.EntityLayer.Concrete
{
    public class NewsLetters
    {
        [Key]
        public int MailID { get; set; }
        public string? Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
