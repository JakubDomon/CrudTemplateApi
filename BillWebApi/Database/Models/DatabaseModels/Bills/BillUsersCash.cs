using BillWebApi.Database.Models.DatabaseModels.Users;

namespace BillWebApi.Database.Models.DatabaseModels.Bills
{
    public class BillUsersCash
    {
        public int Id { get; set; }
        public int Cash { get; set; }
        public Bill Bill { get; set; }
        public User? UserID { get; set; }
    }
}
