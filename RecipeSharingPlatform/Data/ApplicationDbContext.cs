using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Model;

namespace RecipeSharingPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }

        /*
         * I want to delete all the comments that is associate with recipe 
         * when a recipe is deleted 
         * But not the rest of data such as user, recipe type, category
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Comment)
                .WithOne(c => c.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
            .HasMany(r => r.Recipes)
            .WithOne(u => u.User)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Comments)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasMany(r => r.Recipes)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.NoAction);
        }

        /* 
         * The OnDelete(DeleteBehavior.Cascade) setting that 
         * I have defined above will only delete the comments associated with a specific recipe 
         * when that recipe is deleted. It will not delete comments associated with other recipes.
         */

    }
}
