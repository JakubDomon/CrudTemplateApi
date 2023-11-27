namespace DataAccessLayer.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
