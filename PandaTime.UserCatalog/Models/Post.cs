using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Post : BaseObject
    {
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Required]
        [MaxLength(1024)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public virtual ICollection<Comment> Comments { get; set; }

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
                .Entity<Post>()
                .ToTable("Post");

            modelBuilder
                .Entity<Post>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Post>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");

            // Setup relationships

            modelBuilder
                .Entity<Post>()
                .HasMany(pst => pst.Comments)
                .WithOne(cmt => cmt.Post);
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            
        }
    }
}
