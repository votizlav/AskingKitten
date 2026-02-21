using AskingKitten.Entities.Questions;
using Microsoft.EntityFrameworkCore;

namespace AskingKitten.Infrastructure.Postgresql;

public class QuestionsDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
}