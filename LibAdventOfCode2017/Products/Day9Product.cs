using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibAdventOfCode2017.Products
{
    using LibAdventOfCode2017.Validations;
    using LibAdventOfCode2017.Products.Core;
    using System.ComponentModel.DataAnnotations;
    using LibAdventOfCode2017.Helpers;

    public class Day9Product : Input
    {
        private string _input;
        [ValidationDay9]
        public string Input { get { return _input; } }
        public Day9Product(string input)
        {
            _input = input;
        }

        public object Process()
        {
            Validate();

            int total = 0;
            string input = _input;
            input = input.CleanUp();
            int i = 0;
            int tmpScr = 0;
            // input = input.Replace(",", string.Empty);
            while (i <= input.Length - 1)
            {
                var c = input[i];
                if (c == '{') { tmpScr++; i++; }
                else if (c == '}') { total += tmpScr; tmpScr--; i++; }
                else { i++; }
            }


            return total;
        }



        public override void Validate()
        {
            ICollection<ValidationResult> results = null;
            if (!Validate(this, out results))
            {
                throw new Exception(String.Join("\n", results.Select(o => o.ErrorMessage)));
            }

        }
    }
}
