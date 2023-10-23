using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Add
{
    public class BlAddItemRequest<T> : IBlRequest
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
