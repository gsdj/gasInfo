namespace Business.Interfaces.Services
{
   public interface IGasComponentsService<T> : IWritable<T>, IDatable<T> where T : class
   {
   }
}
