namespace BLL.Interfaces.Services.Input
{
   public interface IGasComponentsService<T> : IWritable<T>, IDatable<T> where T : class
   {
   }
}
