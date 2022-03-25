using Business.Interfaces;
using System.Web.Mvc;

namespace Business.BusinessModels
{
   public class ModelStateWrapper : IValidationDictionary
   {
      private ModelStateDictionary _modelState;
      public ModelStateWrapper(ModelStateDictionary modelState)
      {
         _modelState = modelState;
      }
      public bool IsValid
      {
         get { return _modelState.IsValid; }
      }

      public void AddError(string key, string errorMessage)
      {
         _modelState.AddModelError(key, errorMessage);
      }
   }
}
