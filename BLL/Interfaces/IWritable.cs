namespace BLL.Interfaces
{
   public interface IWritable<T> where T: class
   {
      bool InsertOrUpdate(T entity);
   }
}
