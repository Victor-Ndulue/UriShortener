using Microsoft.EntityFrameworkCore;
using UriShortener.Models;

namespace UriShortener.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions options): base(options)
    {        
    }
    public DbSet<UriDetail> UriDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UriDetail>(m =>
        {
            m.HasKey(x => x.Id);
            //m.Property(x => x.UniqueCode).ValueGeneratedOnAdd().HasMaxLength(5);
            //m.HasAlternateKey(x => x.UniqueCode);
        });
    }
}
