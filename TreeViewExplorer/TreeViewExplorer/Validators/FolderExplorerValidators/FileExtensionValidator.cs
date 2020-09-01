using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TreeViewExplorer.Validators.FolderExplorerValidators
{
    internal sealed class FileExtensionValidator
        : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string extension && extension != null)
            {
                if (string.IsNullOrEmpty(extension) || Regex.IsMatch(extension, @"^\w+$"))
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "Unsupported characters");
        }
    }
}
