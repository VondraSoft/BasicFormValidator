using BasicFormValidator.Model;
using System.Windows.Controls;

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
            }
        }
    }
}
