using BillWebApi.Database.Models.DatabaseModels.Users;
using System.ComponentModel.DataAnnotations;

namespace BillWebApi.Database.Models.Models
{
    public class GroupAddModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<UserModel> Users { get; set; }  
    }
}
