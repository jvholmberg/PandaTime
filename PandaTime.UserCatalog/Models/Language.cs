using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PandaTime.UserCatalog.Models
{
    public class Language : BaseObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [MaxLength(32)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PandaTime.UserCatalog.Models.Language"/> is default.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public bool Default { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public virtual ICollection<User> Users { get; set; }

        public static void ConfigureTable(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Language>()
                .ToTable("Language");

            modelBuilder
                .Entity<Language>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("current_timestamp");

            modelBuilder
                .Entity<Language>()
                .Property(x => x.LastModified)
                .HasDefaultValueSql("current_timestamp");
        }

        public static void CreateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language {
                    Id = 1,
                    Name = "English",
                    Code = "en",
                    Default = true,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                },
                new Language {
                    Id = 2,
                    Name = "Swedish",
                    Code = "sv",
                    Default = false,
                    CreatedAt = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow
                }
            );

        }
    }
}
