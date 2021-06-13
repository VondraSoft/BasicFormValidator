using System;
using System.Collections.Generic;
using BasicFormValidator.Utils;
using BasicFormValidator.Model;

namespace BasicFormValidator.Validator
{
    abstract public class AbstractValidator : IComponentValidator
    {
        protected List<string> errors = new List<string>();
        protected Dictionary<ValidatorManager.Messages, string> messages;

        abstract public void Validate(ValidationComponent component);

        public List<string> GetErrors()
        {
            return this.errors;
        }

        public void ClearErrors()
        {
            this.errors.Clear();
        }

        public void SetMessages(Dictionary<ValidatorManager.Messages, string> messages)
        {
            this.messages = messages;
        }

        protected void AddRequiredError(string componentName)
        {
            this.errors.Add(this.messages[ValidatorManager.Messages.Required].Replace("{component}", componentName));
        }

        protected void AddInvalidLengthError(string componentName, int length, ValidatorManager.Messages dateMessage)
        {
            if (dateMessage != ValidatorManager.Messages.MinLength) {
                throw new ArgumentException(string.Format("Message type {0} is not allowed for InvalidLengthError", dateMessage));
            }

            this.errors.Add(
                this.messages[dateMessage].Replace("{component}", componentName).Replace("{length}", length.ToString())
            );
        }

        protected void AddInvalidDateError(string componentName, DateTime? date, ValidatorManager.Messages dateMessage)
        {
            if (dateMessage != ValidatorManager.Messages.MinDate && dateMessage != ValidatorManager.Messages.MaxDate) {
                throw new ArgumentException(string.Format("Message type {0} is not allowed for InvalidDateError", dateMessage));
            }

            string error = this.messages[dateMessage].Replace("{component}", componentName);
            string dateFormat = StringHelper.GetStringBetweenTwoCharacters(error, '{', '}');
            this.errors.Add(error.Replace("{" + dateFormat + "}", date.Value.ToString(dateFormat)));
        }
    }
}
