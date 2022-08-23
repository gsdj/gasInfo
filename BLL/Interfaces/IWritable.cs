namespace BLL.Interfaces
{
   //Оставить только Upsert?
   public interface IWritable<T> where T: class
   {
      bool Upsert(T entity);
   }
}
