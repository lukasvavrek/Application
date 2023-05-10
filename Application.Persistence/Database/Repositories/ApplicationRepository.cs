using Application.Domain.Models;
using Application.Domain.Repositories;

namespace Application.Persistence.Database.Repositories;

public class ApplicationRepository : BaseRepository<ApplicationDao>, IApplicationRepository 
{
    public ApplicationRepository(ApplicationContext dbContext) : base(dbContext)
    { }
    
    // Here we will have the possibility to implement custom repo methods.
}