using System;
using System.Collections.Generic;
using System.Windows.Controls;
using BasicFormValidator.Model;
using BasicFormValidator.Validator;
using BasicFormValidator.Collection;

namespace BasicFormValidator
{
    public class ValidatorManager
    {
        protected List<ValidationComponent> components = new List<ValidationComponent>();
        protected List<string> errors = new List<string>();
        protected Dictionary<Messages, string> messages;
        protected Dictionary<Validators, AbstractValidator> validators;

        public enum Validators
        {
            TextBox,
            DatePicker,
            Password
        }

        public enum Messages
        {
            Required,
            MinLength,
            MinDate,
            MaxDate,
            Enum,
            Pattern
        }

        public ValidatorManager(IValidatorCollection validatorCollection)
        {
            this.InitCollections(validatorCollection);
        }

        public ValidatorManager(IValidatorMessageCollection messageCollection)
        {
            this.InitCollections(null, messageCollection);
        }

        public ValidatorManager(
            IValidatorCollection validatorCollection = null,
            IValidatorMessageCollection messageCollection = null
        )
        {
            this.InitCollections(validatorCollection, messageCollection);
        }

        private void InitCollections(
            IValidatorCollection validatorCollection = null,
            IValidatorMessageCollection messageCollection = null
        )
        {
            this.validators = new ValidatorCollection().GetValidators();
            this.messages = new ValidatorMessageCollection().getMessages();

            if (validatorCollection is not null)
            {
                foreach (var validator in validatorCollection.GetValidators())
                {
                    this.validators[validator.Key] = validator.Value;
                }
            }

            if (messageCollection is not null)
            {
                foreach (var message in messageCollection.getMessages())
                {
                    this.messages[message.Key] = message.Value;
                }
            }
        }

        public ValidatorManager AddComponent(ValidationComponent component)
        {
            this.components.Add(component);
            return this;
        }

        public ValidatorManager SetComponents(List<ValidationComponent> components)
        {
            this.components = components;
            return this;
        }

        public List<string> GetErrors()
        {
            return this.errors;
        }

        public string GetErrorsAsString()
        {
            string errorsString = "";

            this.errors.ForEach(delegate (String error) {
                errorsString += error + "\n";
            });

            return errorsString;
        }

        public void AddErrors(List<string> errors)
        {
            errors.ForEach(delegate (String error) {
                this.errors.Add(error);
            });
        }

        public bool IsValid()
        {
            return this.errors.Count == 0;
        }

        public void ClearErrors()
        {
            this.errors.Clear();
        }

        public bool Validate()
        {
            this.ClearErrors();

            components.ForEach(delegate (ValidationComponent component) {
                this.ValidateComponent(component);
            });

            return this.IsValid();
        }

        protected void ValidateComponent(ValidationComponent component)
        {
            AbstractValidator validator;

            switch (component.Control) {
                case TextBox control:
                    validator = this.validators[Validators.TextBox];
                    break;
                case DatePicker control:
                    validator = this.validators[Validators.DatePicker];
                    break;
                default:
                    throw new ArgumentException(string.Format(
                        "{0} => This component type is not allowed for validation process.",
                        component.Control.GetType()
                    ));
            }

            validator.ClearErrors();
            validator.SetMessages(this.messages);
            validator.Validate(component);
            this.AddErrors(validator.GetErrors());
        }
    }
}
