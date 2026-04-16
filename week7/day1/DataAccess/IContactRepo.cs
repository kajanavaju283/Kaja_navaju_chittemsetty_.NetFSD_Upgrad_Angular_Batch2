namespace AppDemo.DataAccess
{
    public interface IContactRepo<TEntity>
    {
        List<TEntity> ShowContacts();
        TEntity GetContactById(int id);
        bool AddContact(TEntity entity);
    }
}
