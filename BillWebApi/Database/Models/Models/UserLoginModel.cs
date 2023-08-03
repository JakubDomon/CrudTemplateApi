using System.ComponentModel.DataAnnotations;

namespace BillWebApi.Database.Models.Models
{
    public class UserLoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
