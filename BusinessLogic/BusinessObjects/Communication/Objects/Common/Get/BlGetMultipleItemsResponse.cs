using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Get
{
    public class BlGetMultipleItemsResponse<T> : IBlResponse
        where T : IBlModel
    {
        public IEnumerable<T>? Items { get; set; }
    }
}
