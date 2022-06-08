using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApplication.Models
{
    public class Picture
    {
        [Key]
        public int PicID { get; set; }

        [Display(Name = "Image")]
        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
