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
            return new Dictionary<ValidatorManager.Messages, string> {
                { ValidatorManager.Messages.Required, "Požadovaná položka je povinná - {component}"  },
                { ValidatorManager.Messages.MinDate, "Zadané datum musí být od {YYYY-MM-dd}" }
            };
        }
    }
}
