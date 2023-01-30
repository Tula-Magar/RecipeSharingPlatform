using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSharingPlatform.Model
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Please enter a recipe name")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a recipe description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter a recipe Ingredients")]
        public string? Ingredients { get; set; }

        [Required(ErrorMessage = "Please enter a recipe Instructions")]
        public string? Instructions { get; set; }

        [Required(ErrorMessage = "Please enter a recipe Image")]
        public string? ImageUrl { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter a rating between 1 and 5")]
        public int Rating { get; set; }

        public int RecipeTypeId { get; set; }
        public virtual RecipeType? RecipeType { get; set; }
        [ForeignKey("RecipeTypeId")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public virtual ICollection<Comment>? Comment { get; set; }
    }
}
