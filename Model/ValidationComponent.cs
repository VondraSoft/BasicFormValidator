using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BasicFormValidator.Model
{
    public class ValidationComponent
    {
        public Control Control { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public string[] EnumValues { get; set; }
        public string Pattern { get; set; }

        public ValidationComponent(Control control, string name, bool required)
        {
            this.Control = control;
            this.Name = name;
            this.Required = required;
        }

        public ValidationComponent(Control control, string name, bool required, int minLength)
        {
            this.Control = control;
            this.Name = name;
            this.Required = required;
            this.MinLength = minLength;
        }

        public ValidationComponent(Control control, string name, bool required, DateTime? minDate = null, DateTime? maxDate = null)
        {
            this.Control = control;
            this.Name = name;
            this.Required = required;
            this.MinDate = minDate;
            this.MaxDate = maxDate;
        }

        public ValidationComponent(Control control, string name, bool required, string[] enumValues)
        {
            if (control is not TextBox) {
                throw new ArgumentException("Given control must be instance of TextBox");
            }

            this.Control = control;
            this.Name = name;
            this.Required = required;
            this.EnumValues = enumValues;
        }

        public ValidationComponent(Control control, string name, bool required, string pattern)
        {
            this.Control = control;
            this.Name = name;
            this.Required = required;
            this.Pattern = pattern;
        }
    }
}
