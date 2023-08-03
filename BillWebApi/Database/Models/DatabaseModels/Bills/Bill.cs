using BillWebApi.Database.Models.DatabaseModels.Users;
using Microsoft.EntityFrameworkCore;

namespace BillWebApi.Database.Models.DatabaseModels.Bills
{
    public class Bill
    {
        public int Id { get; set; }
        public string Shop { get; set; }
        public int Cash { get; set; }
        public User AddedBy { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
