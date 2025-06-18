namespace FormulaOne.Entities.DbSet;

public class Achievements : BaseEntity
{
    public int RaceWins { get; set; }
    public int PolePostion { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverId { get; set; }

    public virtual Driver? Driver  { get; set; }
}