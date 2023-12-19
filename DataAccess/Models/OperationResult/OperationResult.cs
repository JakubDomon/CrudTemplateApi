using DataAccessLayer.Models.OperationResult.Enums;

namespace DataAccessLayer.Models.OperationResult
{
    public class OperationResult<Entity>
    {
        public Entity? Object { get; set; }
        public OperationStatus Status { get; set; }
    }
}
