using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Communication.API;

namespace BusinessLayer.Service.CrudService
{
    public interface ICrudService<Item>
        where Item : BusinessModelBase
    {
        ErrorableResponse<IEnumerable<Item>> Query(Item item);
        ErrorableResponse<Item> GetById(int id);
        ErrorableResponse<IEnumerable<Item>> GetAll();
        ErrorableResponse<Item> Add(Item item);
        ErrorableResponse<Item> Update(Item item);
        ErrorableResponse<Item> Delete(Item item);
    }
}
