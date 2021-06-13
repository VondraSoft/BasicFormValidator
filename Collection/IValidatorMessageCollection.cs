using System.Collections.Generic;

namespace BasicFormValidator.Collection
{
    public interface IValidatorMessageCollection
    {
        Dictionary<ValidatorManager.Messages, string> getMessages();
    }
}
