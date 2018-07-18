﻿using System;
namespace PandaTime.UserCatalog.Models
{
    public class CoreObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        [Required]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:PandaTime.Core.Entities.BaseEntity"/> is modified.
        /// </summary>
        /// <value><c>true</c> if is modified; otherwise, <c>false</c>.</value>
        public bool IsModified
        {
            get
            {
                return !CreatedAt.Equals(LastModified);
            }
        }
    }
}
