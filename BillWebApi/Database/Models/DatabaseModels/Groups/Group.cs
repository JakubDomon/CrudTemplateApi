using BillWebApi.Database.Models.DatabaseModels.Bills;
using BillWebApi.Database.Models.DatabaseModels.Users;

namespace BillWebApi.Database.Models.DatabaseModels.Groups
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
