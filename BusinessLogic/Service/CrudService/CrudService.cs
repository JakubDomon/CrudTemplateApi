using BusinessLayer.BusinessLogic.Crud;
using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Communication;

namespace BusinessLayer.Service.CrudService
{
    public class CrudService<Item> : ICrudService<Item>
        where Item : BusinessModelBase
    {
        ICrudBusinessLogic<Item> BusinessLogic { get; set; }

        public CrudService(ICrudBusinessLogic<Item> crudBusinessLogic)
        {
            BusinessLogic = crudBusinessLogic;
        }

        public ErrorableResponse<IEnumerable<Item>> Query(Item item) => BusinessLogic.Query(item);
        public ErrorableResponse<Item> GetById(int id) => BusinessLogic.GetById(id);
        public ErrorableResponse<IEnumerable<Item>> GetAll() => BusinessLogic.GetAll();
        public ErrorableResponse<Item> Add(Item item) => BusinessLogic.Add(item);
        public ErrorableResponse<Item> Update(Item item) => BusinessLogic.Update(item);
        public ErrorableResponse<Item> Delete(Item item) => BusinessLogic.Delete(item);
    }
}
