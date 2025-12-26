
namespace Infrastructure.Postgres.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Domain.Models;

[Table("items")]

public class ItemModel
{
    [Key]
    [Column("id")]
    public required Guid Id { get; set; }

    [Required]
    [Column("title")]
    public required string Title { get; set; }
    [Required]
    [Column("body")]
    public required string Body { get; set; }
    [Required]
    [Column("created_at")]
    public required DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    public Result<Item> ToDomain()
    {
        return Item.Create(Id.ToString(), Title, Body, CreatedAt, UpdatedAt);
    }

    public static ItemModel FromDomain(Item item)
    {
        return new ItemModel
        {
            Id = Guid.Parse(item.Id),
            Title = item.Title,
            Body = item.Body,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };
    }
}