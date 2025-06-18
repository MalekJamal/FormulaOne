namespace FormulaOne.Entities.Dtos.Responese;


public class DriverAchievementsResponse
{
    public Guid DriverId { get; set; }
    public int WorldChampionship { get; set; }
    public int FastestLap { get; set; }
    public int PolePostion { get; set; }
    public int Wins { get; set; }
}
