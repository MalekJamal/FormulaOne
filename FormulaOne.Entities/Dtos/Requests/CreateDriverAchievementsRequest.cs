namespace FormulaOne.Entities.Dtos.Requests;

public class CreateDriverAchievementsRequest
{
    public Guid DriverId { get; set; }
    public int WorldChampionship { get; set; }
    public int FastestLap { get; set; }
    public int PolePostion { get; set; }
    public int Wins { get; set; }
}