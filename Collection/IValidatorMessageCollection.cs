using System.Collections.Generic;

namespace BasicFormValidator.Collection
{
    public interface IValidatorMessageCollection
    {
        public Dictionary<ValidatorManager.Messages, string> getMessages();
    }
}
