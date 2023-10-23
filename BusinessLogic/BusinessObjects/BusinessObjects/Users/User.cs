namespace BusinessLayer.BusinessObjects.BusinessObjects.Users
{
    public class User : IBlModel
    {
        public int? Id { get; set; }
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
