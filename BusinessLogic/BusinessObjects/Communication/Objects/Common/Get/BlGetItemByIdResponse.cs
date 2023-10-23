using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Get
{
    public class BlGetItemByIdResponse<T> : IBlResponse
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
