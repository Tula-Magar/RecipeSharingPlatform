using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Email")]
        public string? Email { get; set; }

        public byte[]? Image { get; set; }

        //public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Recipe>? Recipes { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}