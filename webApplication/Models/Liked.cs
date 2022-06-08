using System.ComponentModel.DataAnnotations.Schema;
namespace webApplication.Models
{
    public class Liked
    {
        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Animal")]
        public int AnimalID { get; set; }
    }
}
