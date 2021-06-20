using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFormValidator.Collection
{
    class ValidatorMessageCollection : IValidatorMessageCollection
    {
        public Dictionary<ValidatorManager.Messages, string> getMessages()
        {
            return new Dictionary<ValidatorManager.Messages, string> 
            {
                { ValidatorManager.Messages.Required, "{component} - This field is required."  },
                { ValidatorManager.Messages.MinDate, "{component} - Date must be from {yyyy-MM-dd}" },
                { ValidatorManager.Messages.MaxDate, "{component} - Date must be to {yyyy-MM-dd}" },
                { ValidatorManager.Messages.MinLength, "{component} - The minimum length is {length} chars" },
                { ValidatorManager.Messages.Enum, "{component} - The value must be from the enumeration - {enumeration}" },
                { ValidatorManager.Messages.Pattern, "{component} - The value must following the pattern - {pattern}" }
            };
        }
    }
}
