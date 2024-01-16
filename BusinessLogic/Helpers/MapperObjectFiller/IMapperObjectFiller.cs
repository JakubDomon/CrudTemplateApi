using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.Helpers.MapperObjectFiller
{
    internal interface IMapperObjectFiller<Item>
        where Item : IBusinessModel
    {
        public Item Fill(Item item);
    }
}
