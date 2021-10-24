
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NovoBanco.Aplicacao.Shared
{
    public static class UtilExtensions
    {
        public static IList<ValidationResult> ValidarPropriedades(this object o)
        {
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(o, null, null);
            Validator.TryValidateObject(o, context, validationResult, true);
            return validationResult;
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetEnumName(this Enum value)
        {
            return value.ToString();
        }

        public static int GetEnumValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static T GetEnumValue<T>(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return default(T);

            return (T)Enum.Parse(typeof(T), value.RemoveDiacritics(), true);
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
