using System.Collections.Generic;
using BasicFormValidator.Validator;

namespace BasicFormValidator.Collection
{
    class ValidatorCollection : IValidatorCollection
    {
        public Dictionary<ValidatorManager.Validators, AbstractValidator> GetValidators()
        {
            return new Dictionary<ValidatorManager.Validators, AbstractValidator> {
                { ValidatorManager.Validators.TextBox, new TextBoxValidator() },
                { ValidatorManager.Validators.DatePicker, new DatePickerValidator() }
            };
        }
    }
}
