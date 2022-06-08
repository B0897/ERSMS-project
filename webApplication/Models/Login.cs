using System.ComponentModel.DataAnnotations.Schema;

namespace webApplication.Models
{
    public class Login
    {
        [Column(TypeName = "nvarchar(30)")]
        public string login { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string password { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string code { get; set; }

    }
}
