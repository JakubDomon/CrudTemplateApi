namespace BillWebApi.Database.Models.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public string Shop { get; set; }
        public int Cash { get; set; }
        public UserModel AddedBy { get; set; }
        public DateTime AddDate { get; set; }
    }
}
