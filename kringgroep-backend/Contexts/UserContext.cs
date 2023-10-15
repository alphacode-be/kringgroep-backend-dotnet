using kringgroep_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace kringgroep_backend.Contexts;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public string DbPath { get; }

    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "kringgroep.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}