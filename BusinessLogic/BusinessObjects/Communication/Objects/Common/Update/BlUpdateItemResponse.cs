using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.BusinessObjects.Communication.Objects.Common.Update
{
    public class BlUpdateItemResponse<T> : IBlResponse
        where T : IBlModel
    {
        public T? Item { get; set; }
    }
}
