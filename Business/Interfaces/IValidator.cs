namespace Business.Interfaces
{
   public interface IValidator<T> where T : class  
   {
      public bool Validate(T entity);
   }
}
