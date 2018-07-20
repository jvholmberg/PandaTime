using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Role : BaseObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public virtual ICollection<Membership> Memberships { get; set; }

        public static void SetupModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Role>()
                .ToTable("Role");

            modelBuilder
                .Entity<Role>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Role>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                new Role
                {
                    Id = 2,
                    Name = "Support",
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                new Role
                {
                    Id = 3,
                    Name = "Moderator",
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                new Role
                {
                    Id = 4,
                    Name = "User",
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                }
            );
        }
    }
}
