namespace BusinessLayer.BusinessObjects.BusinessObjects
{
    public class BusinessModelBase : IBusinessModel
    {
        public int? Id { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
