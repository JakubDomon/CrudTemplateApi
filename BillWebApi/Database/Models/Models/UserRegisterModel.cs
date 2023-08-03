using System.ComponentModel.DataAnnotations;

namespace BillWebApi.Database.Models.Models
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(maximumLength:30, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength:30, MinimumLength =2)]
        public string Surname { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength =6)]
        public string Password { get; set; }
    }
}
