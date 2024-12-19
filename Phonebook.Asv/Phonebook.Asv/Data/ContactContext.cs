using Phonebook.Models;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Data;

internal class ContactContext: DbContext
{
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        optionsBuilder.UseSqlServer(DotNetEnv.Env.GetString("CONNECTION_STRING"));
    }
}