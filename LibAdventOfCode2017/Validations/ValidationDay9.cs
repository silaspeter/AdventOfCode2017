using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAdventOfCode2017.Helpers;
using System.Text.RegularExpressions;

namespace LibAdventOfCode2017.Validations
{
    public class ValidationDay9 : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            string input = value.ToString().Trim().CleanUp();
            if (input.ParseInput())
                return ValidationResult.Success;
            else
                return new ValidationResult
                    ("Malformed Input");
        }
    }
}
