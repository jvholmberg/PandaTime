using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Membership : BaseObject
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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Role Role { get; set; }

        public static void SetupModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Membership>()
                .ToTable("Membership");

            modelBuilder
                .Entity<Membership>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Membership>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");

            // Setup relationships

            modelBuilder
                .Entity<Membership>()
                .HasOne(msp => msp.Group)
                .WithMany(grp => grp.Memberships);
            
            modelBuilder
                .Entity<Membership>()
                .HasOne(msp => msp.User)
                .WithMany(usr => usr.Memberships);
            
            modelBuilder
                .Entity<Membership>()
                .HasOne(msp => msp.Role)
                .WithMany(rle => rle.Memberships);
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasData(
                // Admin
                new Membership
                {
                    Id = 1,
                    GroupId = 1,
                    RoleId = 1,
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Support
                new Membership
                {
                    Id = 2,
                    GroupId = 2,
                    RoleId = 2,
                    UserId = 2,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Moderator
                new Membership
                {
                    Id = 3,
                    GroupId = 3,
                    RoleId = 3,
                    UserId = 3,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // User
                new Membership
                {
                    Id = 4,
                    GroupId = 4,
                    RoleId = 4,
                    UserId = 4,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Inactive User
                new Membership
                {
                    Id = 5,
                    GroupId = 5,
                    RoleId = 4,
                    UserId = 5,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },


                // User (Public Group, Admin)
                new Membership
                {
                    Id = 6,
                    GroupId = 6,
                    RoleId = 1,
                    UserId = 4,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                // Inactive User (Public Group, User)
                new Membership
                {
                    Id = 7,
                    GroupId = 6,
                    RoleId = 4,
                    UserId = 5,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                }
            );
        }
    }
}
