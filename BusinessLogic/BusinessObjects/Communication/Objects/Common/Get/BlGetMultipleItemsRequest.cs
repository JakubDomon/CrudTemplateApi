using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Get
{
    public class BlGetMultipleItemsRequest<T> : IBlRequest
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
