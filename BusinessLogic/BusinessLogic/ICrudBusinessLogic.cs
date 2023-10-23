namespace BusinessLayer.BusinessLogic
{
    internal interface ICrudBusinessLogic<Entity>
    {
        IEnumerable<Entity> Query(Entity entity);
        IEnumerable<Entity> GetAll();
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void Delete(Entity entity);
    }
}
