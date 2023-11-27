using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Communication;

namespace BusinessLayer.BusinessLogic.Crud
{
    public interface ICrudBusinessLogic<T>
        where T : BusinessModelBase
    {
        ErrorableResponse<IEnumerable<T>> Query(T item);
        ErrorableResponse<T> GetById(int id);
        ErrorableResponse<IEnumerable<T>> GetAll();
        ErrorableResponse<T> Add(T item);
        ErrorableResponse<T> Update(T item);
        ErrorableResponse<T> Delete(T item);
    }
}
