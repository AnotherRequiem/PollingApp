using Microsoft.EntityFrameworkCore;
using PollingApp.Entities;

public class ApplicationDbContext: DbContext
{
    public DbSet<Poll> Polls { get; set; }

    public DbSet<Answer> Answers { get; set; }
}