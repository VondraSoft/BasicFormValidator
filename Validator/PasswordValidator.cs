using BasicFormValidator.Model;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace BasicFormValidator.Validator
{
    class PasswordValidator : AbstractValidator
    {
        public override void Validate(ValidationComponent component)
        {
            PasswordBox control = (PasswordBox)component.Control;

            if (component.Required && control.Password.Length == 0) 
            {
                this.AddRequiredError(component.Name);
            }

            if (component.Required) 
            {
                if (component.Pattern.Length > 0 && !Regex.IsMatch(control.Password, component.Pattern)) 
                {
                    this.AddPaternError(component.Name, component.Pattern);
                }
            }
        }
    }
}
