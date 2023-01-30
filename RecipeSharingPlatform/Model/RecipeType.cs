using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.Model
{
    public class RecipeType
    {
        /*
         * ? will remove the warning of not-null when creating a new recipe
         * [Required] Annotations will still gives a error if user incorrectly input a value
         */
        
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        public ICollection<Recipe>? Recipes { get; set; }
    }
}