using System;
using System.Globalization;

namespace FussballManager
{
    public class InputValidation
    {
        private bool[] _validationResult = new bool[5];

        public void InitValidation()
        {
            for(int i = 0; i < _validationResult.Length; i++)
            {
                _validationResult[i] = true;
            }
        }

        public bool ResultOfValidation()
        {
            foreach(bool res in _validationResult)
            {
                if (res == false)
                    return false;
            }
            return true;
        }

        #region VALIDATION

        public bool ValidateName(string input, out string errorText)
        {
            if (input == "")
            {
                errorText = "Name ist ungültig";
                _validationResult[0] = false;
                return false;
            }
            errorText = "";
            _validationResult[0] = true;
            return true;
        }

        public bool ValidateFirstName(string input, out string errorText)
        {
            if (input == "")
            {
                errorText = "Vorname ist ungültig";
                _validationResult[1] = false;
                return false;
            }
            errorText = "";
            _validationResult[1] = true;
            return true;
        }

        public bool ValidateHeight(string input, out string errorText)
        {
            if (Int32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int value))
            {
                if (value > 210)
                {
                    errorText = "Eingabe zu Gross (Max: 210)";
                    _validationResult[2] = false;
                    return false;
                }
                if (value < 150)
                {
                    errorText = "Eingabe zu Klein (Min: 150)";
                    _validationResult[2] = false;
                    return false;
                }
                errorText = "";
                _validationResult[2] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                _validationResult[2] = false;
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
                    _validationResult[3] = false;
                    return false;
                }
                errorText = "";
                _validationResult[3] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                _validationResult[3] = false;
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
                    _validationResult[4] = false;
                    return false;
                }
                errorText = "";
                _validationResult[4] = true;
                return true;
            }
            else
            {
                errorText = "Eingabe ist ungültig";
                _validationResult[4] = false;
                return false;
            }
        }

        #endregion

    }
}
