using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballManager.Model;

namespace FussballManager
{
    public class InputValidation
    {
        private bool[] ValidationResult = new bool[5];

        public void InitValidation()
        {
            for(int i = 0; i < ValidationResult.Length; i++)
            {
                ValidationResult[i] = true;
            }
        }

        public bool ResultOfValidation()
        {
            foreach(bool res in ValidationResult)
            {
                if (res == false)
                    return false;
            }
            return true;
        }

        public bool ValidateName(string input, out string errorText)
        {
            if (input == "")
            {
                errorText = "Name ist ungültig";
                ValidationResult[0] = false;
                return false;
            }
            errorText = "";
            ValidationResult[0] = true;
            return true;
        }

        public bool ValidateFirstName(string input, out string errorText)
        {
            if (input == "")
            {
                errorText = "Vorname ist ungültig";
                ValidationResult[1] = false;
                return false;
            }
            errorText = "";
            ValidationResult[1] = true;
            return true;
        }

        public bool ValidateHeight(string input, out string errorText)
        {
            if (Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int value))
            {
                if (value > 210)
                {
                    errorText = "Eingabe zu Gross (Max: 210)";
                    ValidationResult[2] = false;
                    return false;
                }
                if (value < 150)
                {
                    errorText = "Eingabe zu Klein (Min: 150)";
                    ValidationResult[2] = false;
                    return false;
                }
                errorText = "";
                ValidationResult[2] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                ValidationResult[2] = false;
                return false;
            }
        }

        public bool ValidateGoals(string input, out string errorText)
        {
            if (Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int value))
            {
                if (value < 0)
                {
                    errorText = "Eingabe zu Klein";
                    ValidationResult[3] = false;
                    return false;
                }
                errorText = "";
                ValidationResult[3] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                ValidationResult[3] = false;
                return false;
            }
        }

        public bool ValidatePalyedGames(string input, out string errorText)
        {
            if (Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int value))
            {
                if (value < 0)
                {
                    errorText = "Eingabe zu Klein";
                    ValidationResult[4] = false;
                    return false;
                }
                errorText = "";
                ValidationResult[4] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                ValidationResult[4] = false;
                return false;
            }
        }

    }
}
