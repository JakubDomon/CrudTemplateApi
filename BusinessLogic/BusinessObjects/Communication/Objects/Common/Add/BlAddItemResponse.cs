using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Add
{
    public class BlAddItemResponse<T> : IBlResponse
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
