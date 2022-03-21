using System;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Mobile.Core.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}