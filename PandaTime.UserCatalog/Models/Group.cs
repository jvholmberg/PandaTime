using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Group : BaseObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PandaTime.UserCatalog.Models.Group"/> is private.
        /// </summary>
        /// <value><c>true</c> if private; otherwise, <c>false</c>.</value>
        [Required]
        public bool Personal { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [MaxLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>The memberships.</value>
        public ICollection<Membership> Memberships { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public ICollection<Post> Posts { get; set; }

        public static void SetupModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Group>()
                .ToTable("Group");

            modelBuilder
                .Entity<Group>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Group>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");

            // Setup Relationships

            modelBuilder
                .Entity<User>()
                .HasOne(usr => usr.Language)
                .WithMany(lng => lng.Users);
            
            modelBuilder
                .Entity<Group>()
                .HasMany(grp => grp.Posts)
                .WithOne(pst => pst.Group);
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                // Admin
                new Group
                {
                    Id = 1,
                    Personal = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Support
                new Group
                {
                    Id = 2,
                    Personal = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Moderator
                new Group
                {
                    Id = 3,
                    Personal = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // User
                new Group
                {
                    Id = 4,
                    Personal = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Inactive User
                new Group
                {
                    Id = 5,
                    Personal = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                
                // Public Group
                new Group
                {
                    Id = 6,
                    Personal = false,
                    Name = "Public Group",
                    Description = "This is a public group",
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                }
            );
        }
    }
}
