using BLL.DTO.Input;
using BLL.Interfaces;
using System;

namespace BLL.Models.Validators
{
   public class PressureDefaultValidator : IValidator<PressureDTO>
   {
      IValidationDictionary _validationDictionary;
      public PressureDefaultValidator(IValidationDictionary validation)
      {
         _validationDictionary = validation;
      }
      public bool Validate(PressureDTO entity)
      {
         if (entity.Value < 500)
            _validationDictionary.AddError("Value", "Incorrect value of atmospheric pressure");
         if (entity.Date >= DateTime.Now.AddDays(1))
            _validationDictionary.AddError("Date", "Incorrect value of Date");
         return _validationDictionary.IsValid;
      }
   }
}
