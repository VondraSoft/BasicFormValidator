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
            DatePicker
        }

        public enum Messages
        {
            Required,
            MinLength,
            MinDate,
            MaxDate
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
            if (validatorCollection is null) {
                validatorCollection = new ValidatorCollection();
            }

            if (messageCollection is null) {
                messageCollection = new ValidatorMessageCollection();
            }

            this.validators = validatorCollection.GetValidators();
            this.messages = messageCollection.getMessages();
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

            validator.SetMessages(this.messages);
            validator.Validate(component);
            this.AddErrors(validator.GetErrors());
        }
    }
}
