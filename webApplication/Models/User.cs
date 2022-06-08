using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApplication.Models
{
    public class User
    {
        [Key]
        public int? ID { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Login { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string? HashedPassword { get; set; }

        [Column(TypeName = "boolean")]
        //[MaxLength(1)]
        public bool? IsInstitution { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Surname { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? InstitutionName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string? Telephone { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Town { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Secret { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Paypal { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string? Coord { get; set; }
    }
}
