using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class User : BaseObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether User is activated.
        /// </summary>
        /// <value><c>true</c> if activated; otherwise, <c>false</c>.</value>
        [Required]
        public bool Activated { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [MaxLength(256)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [MaxLength(256)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the language identifier.
        /// </summary>
        /// <value>The language identifier.</value>
        [Required]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>The memberships.</value>
        public virtual ICollection<Membership> Memberships { get; set; }

        public static void SetupModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .ToTable("User");

            modelBuilder
                .Entity<User>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<User>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                // Admin
                new User
                {
                    Id = 1,
                    Activated = true,
                    Email = "admin@forkyfork.com",
                    Password = "123",
                    FirstName = "Admin",
                    LastName = "User",
                    LanguageId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Support
                new User
                {
                    Id = 2,
                    Activated = true,
                    Email = "support@forkyfork.com",
                    Password = "123",
                    FirstName = "Support",
                    LastName = "User",
                    LanguageId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Moderator
                new User
                {
                    Id = 3,
                    Activated = true,
                    Email = "moderator@forkyfork.com",
                    Password = "123",
                    FirstName = "Moderator",
                    LastName = "User",
                    LanguageId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // User
                new User
                {
                    Id = 4,
                    Activated = true,
                    Email = "user1@forkyfork.com",
                    Password = "123",
                    FirstName = "User",
                    LastName = "Active",
                    LanguageId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Inactive User
                new User
                {
                    Id = 5,
                    Activated = false,
                    Email = "user2@forkyfork.com",
                    Password = "123",
                    FirstName = "User",
                    LastName = "Inactive",
                    LanguageId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                }
            );
        }
    }
}
