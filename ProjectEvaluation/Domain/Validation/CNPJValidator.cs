using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validation
{
    public class CNPJValidator : AbstractValidator<string>
    {
        public CNPJValidator() 
        {
            RuleFor(cnpj => cnpj)
                .NotEmpty().WithMessage("CNPJ cannot be empty.")
                .Must(BeNumericOnly).WithMessage("CNPJ must be numeric characters only.")
                .Must(HaveFourteenDigits).WithMessage("CNPJ must have 14 digits.")
                .Matches(@"^\d{14}$").WithMessage("CNPJ format is invalid.")
                .Must(BeValidCNPJ).WithMessage("Invalid CNPJ.");
        }

        private static string RemoveCharactersDifferentThanNumeric(string cnpj)
        {
            return Regex.Replace(cnpj, "[^0-9]", "");
        }

        private static bool BeNumericOnly(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = RemoveCharactersDifferentThanNumeric(cnpj);
            return Regex.IsMatch(cnpj, @"^\d+$");
        }

        private static bool HaveFourteenDigits(string cnpj)
        {            
            if (string.IsNullOrEmpty(cnpj))
                return false;


            cnpj = RemoveCharactersDifferentThanNumeric(cnpj);
            return cnpj.Length == 14;
        }

        private bool BeValidCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = RemoveCharactersDifferentThanNumeric(cnpj);

            if (cnpj.Length != 14)
                return false;

            var firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temporaryCNPJ, digit;
            int sum, leftover = 0;

            // Calculate first twelve digits
            temporaryCNPJ = cnpj.Substring(0, 12);
            sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(temporaryCNPJ[i].ToString()) * firstMultiplier[i];

            //leftover = sum % 11;
            //leftover = leftover < 2 ? 0 : 11 - leftover;
            //digit = leftover.ToString();

            digit = CalculateCNPJDigit(sum, leftover);

            temporaryCNPJ += digit;
            sum = 0;

            // Calculate first thriteen digits
            for (int i = 0; i < 13; i++)
                sum += int.Parse(temporaryCNPJ[i].ToString()) * secondMultiplier[i];

            //leftover = sum % 11;
            //leftover = leftover < 2 ? 0 : 11 - leftover;
            //digit += leftover.ToString();

            digit = CalculateCNPJDigit(sum, leftover);

            return cnpj.EndsWith(digit);
        }

        private static string CalculateCNPJDigit(int sum, int leftover)
        {
            leftover = sum % 11;
            leftover = leftover < 2 ? 0 : 11 - leftover;
            return leftover.ToString();
        }
    }
}
