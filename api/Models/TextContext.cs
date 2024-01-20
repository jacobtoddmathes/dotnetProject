using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public class TextContext : DbContext
{
    public TextContext(DbContextOptions<TextContext> options)
        : base(options)
    {
    }

    public DbSet<TextItem> TextItems { get; set; } = default!;
}