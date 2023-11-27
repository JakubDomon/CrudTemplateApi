using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.Helpers.MapperObjectFiller
{
    internal interface IMapperObjectFiller<Item>
        where Item : BusinessModelBase
    {
        public Item Fill(Item item);
    }
}
