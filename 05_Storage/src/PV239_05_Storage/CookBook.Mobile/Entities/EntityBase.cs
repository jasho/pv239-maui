using System.ComponentModel.DataAnnotations;

namespace CookBook.Mobile.Entities;

public record EntityBase
{
    [Key]
    public Guid Id { get; set; }
};