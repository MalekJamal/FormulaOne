using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;


public class AchievementsRepository : GenericRepository<Achievements>, IAchievementsRepository
{
    public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<Achievements?> GetDriverAchievements(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetDriverAchievements function error", typeof(AchievementsRepository));
            throw;
        }
    }
    
     public override async Task<IEnumerable<Achievements>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(x => x.AddedDate)
            .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return false;

            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievements achievements)
    {
        
                try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievements.Id);

            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastestLap = achievements.FastestLap;
            result.PolePostion = achievements.PolePostion;
            result.RaceWins = achievements.RaceWins;
            result.WorldChampionship = achievements.WorldChampionship;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(AchievementsRepository));
            throw;
        }
    }
}