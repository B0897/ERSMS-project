using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace webApplication.Models
{
    //owner
    public class AnimalUser
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Animal")]
        public int AnimalID { get; set; }

    }
}
