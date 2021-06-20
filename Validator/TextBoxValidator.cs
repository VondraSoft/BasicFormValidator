using BasicFormValidator.Model;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace BasicFormValidator.Validator
{
    class TextBoxValidator : AbstractValidator
    {
        public override void Validate(ValidationComponent component)
        {
            TextBox control = (TextBox)component.Control;

            if (component.Required && control.Text.Length == 0) {
                this.AddRequiredError(component.Name);
            }

            if (component.Required) {
                if (component.MinLength != 0 && control.Text.Length < component.MinLength) {
                    this.AddInvalidLengthError(component.Name, component.MinLength, ValidatorManager.Messages.MinLength);
                }

                if (component.EnumValues.Length > 0) {
                    bool inEnumeration = false;

                    foreach (string value in component.EnumValues) 
                    {
                        if (control.Text == value) {
                            inEnumeration = true;
                            break;
                        }
                    }

                    if (!inEnumeration) {
                        this.AddEnumError(component.Name, component.EnumValues);
                    }
                }

                if (component.Pattern.Length > 0) {
                    if (!Regex.IsMatch(control.Text, component.Pattern)) {
                        this.AddPaternError(component.Name, component.Pattern);
                    }
                }
            }
        }
    }
}
