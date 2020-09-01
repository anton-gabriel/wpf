using System.Globalization;
using System.IO;
using System.Windows.Controls;

namespace TreeViewExplorer.Validators.FolderExplorerValidators
{
    internal sealed class PathDirectoryValidator
        : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string path)
            {
                if (string.IsNullOrEmpty(path) || Directory.Exists(path))
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "Invalid path");
        }
    }
}
