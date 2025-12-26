namespace Infrastructure.Postgres;

using Infrastructure.Postgres.Models;
using Microsoft.EntityFrameworkCore;

public class ItemsDbContext : DbContext
{
    public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options) { }

    public DbSet<ItemModel> Items => Set<ItemModel>();
}