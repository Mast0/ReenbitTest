using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ReenbitTest.ValidationAttributes
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string[] AllowedFileExtentions = [".docx"];

            var files = value as IFormFileCollection;

            if (files == null)
            {
                return false;
            }
            else if (files.Count == 0) 
                // if file not chosen
            {
                ErrorMessage = "Please, chose file to upload.";
                return false;
            }

            foreach (var file in files)
            {
                if (!AllowedFileExtentions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    // if file have not .docx format
                {
                    ErrorMessage = "Please upload Your File of type: " + string.Join(", ", AllowedFileExtentions);
                    return false;
                }
            }
            return true;
        }
    }
}
