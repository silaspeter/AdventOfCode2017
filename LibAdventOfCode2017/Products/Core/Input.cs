using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAdventOfCode2017.Products.Core
{
    using System.ComponentModel.DataAnnotations;
    using LibAdventOfCode2017.Validations;

    public interface IInput
    {

        string Input { get; }
        void Validate();
    }

    public abstract class Input : IInput
    {
        string IInput.Input => throw new NotImplementedException();

        public static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
