using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballManager
{
    public class InputValidation
    {
        private int _maxValue;
        private int _minValue;

        public InputValidation(int maxVal, int minVal)
        {
            _maxValue = maxVal;
            _minValue = minVal;
        }

        public bool ValidateInput(string input)
        {
            int output;
            return Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out output);
        }
    }
}
