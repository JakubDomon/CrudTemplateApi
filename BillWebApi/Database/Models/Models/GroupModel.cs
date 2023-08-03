using BillWebApi.Database.Models.DatabaseModels.Bills;
using BillWebApi.Database.Models.DatabaseModels.Users;

namespace BillWebApi.Database.Models.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserModel> Users { get; set; }
        public ICollection<BillModel> Bills { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
