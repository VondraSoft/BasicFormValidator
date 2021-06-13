using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFormValidator.Model;

namespace BasicFormValidator.Validator
{
    public interface IComponentValidator
    {
        public void Validate(ValidationComponent component);
    }
}
