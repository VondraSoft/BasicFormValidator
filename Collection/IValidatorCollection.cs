using System.Collections.Generic;
using BasicFormValidator.Validator;

namespace BasicFormValidator.Collection
{
    public interface IValidatorCollection
    {
        public Dictionary<ValidatorManager.Validators, AbstractValidator> GetValidators();
    }
}
