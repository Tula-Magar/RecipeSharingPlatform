using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.Model
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        public ICollection<Recipe>? Recipes { get; set; }
    }
}