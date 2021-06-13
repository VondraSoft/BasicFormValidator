using System;
using BasicFormValidator.Model;
using System.Windows.Controls;

namespace BasicFormValidator.Validator
{
    class DatePickerValidator : AbstractValidator
    {
        public override void Validate(ValidationComponent component)
        {
            DatePicker control = (DatePicker)component.Control;
            if (component.Required && control.SelectedDate is null) {
                this.AddRequiredError(component.Name);
            }

            if (component.Required) {
                if (component.MinDate is DateTime && control.SelectedDate < component.MinDate) {
                    this.AddInvalidDateError(component.Name, component.MinDate, ValidatorManager.Messages.MinDate);
                }

                if (component.MaxDate is DateTime && control.SelectedDate > component.MaxDate) {
                    this.AddInvalidDateError(component.Name, component.MaxDate, ValidatorManager.Messages.MaxDate);
                }
            }
        }
    }
}
