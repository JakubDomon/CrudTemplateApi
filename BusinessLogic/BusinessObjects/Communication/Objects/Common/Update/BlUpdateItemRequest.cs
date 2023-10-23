using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Update
{
    public class BlUpdateItemRequest<T> : IBlRequest
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
