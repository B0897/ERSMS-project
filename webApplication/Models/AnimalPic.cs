using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApplication.Models
{
    public class AnimalPic
    {
        [Key]
        public int ID {get;set;}

        [ForeignKey("Animal")]
        public int AnimalID { get; set; }

        [ForeignKey("Picture")]
        public int PicID { get; set; }
    }
}
