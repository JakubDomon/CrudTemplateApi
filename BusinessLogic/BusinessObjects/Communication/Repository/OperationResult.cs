using BusinessLayer.BusinessObjects.Communication.Repository.Enums;

namespace BusinessLayer.BusinessObjects.Communication.Repository
{
    internal class OperationResult<Item>
    {
        public Item? Object { get; set; }
        public OperationStatus Status { get; set; }
    }
}
