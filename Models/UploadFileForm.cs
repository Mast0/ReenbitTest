using ReenbitTest.ValidationAttributes;
using System.ComponentModel.DataAnnotations;


namespace ReenbitTest.Models
{
    public class UploadFileForm
    {
        [Required(ErrorMessage ="Please, enter your email.")]
        [EmailAddress(ErrorMessage = "The e-mail is not valid.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address format!")]
        public string? Email { get; set; }
        [Required()]
        [ValidateFile]
        public IFormFileCollection Attachments { get; set; }
    }
}
