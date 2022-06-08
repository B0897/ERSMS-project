using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace webApplication.Models
{
    public class LikedFront
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string AnimalType { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Breed { get; set; }

        [Column(TypeName = "int32")]
        public int Price { get; set; }

        [Column(TypeName = "int32")]
        public int Age { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string coord { get; set; }

        public int UserID { get; set; }
    }
}
