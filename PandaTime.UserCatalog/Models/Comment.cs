using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Comment : BaseObject
    {
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>The post identifier.</value>
        [Required]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the post.
        /// </summary>
        /// <value>The post.</value>
        public Post Post { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Required]
        [MaxLength(1024)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>The author identifier.</value>
        [Required]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public virtual User Author { get; set; }

        public static void SetupModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Comment>()
                .ToTable("Comment");
            
            modelBuilder
                .Entity<Comment>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Comment>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {

        }
    }
}
