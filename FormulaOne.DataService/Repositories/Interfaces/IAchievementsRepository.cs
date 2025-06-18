using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repositories.Interfaces;

public interface IAchievementsRepository: IGenericRepository<Achievements>
{
    Task<Achievements?> GetDriverAchievements(Guid driverId);

}