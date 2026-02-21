using AskingKitten.Infrastructure.Postgresql.Seeders;

namespace AskingKitten.Infrastructure.Postgresql.Seeders;

public class QuestionsSeeder : ISeeder
{
    private readonly QuestionsDbContext _dbContext;

    public QuestionsSeeder(QuestionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // seedeing logic here
    public Task SeedAsync()
    {
        throw new NotImplementedException();
    }
}