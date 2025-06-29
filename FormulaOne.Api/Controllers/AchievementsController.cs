using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responese;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;


public class AchievementsController : BaseController
{
    public AchievementsController(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator) : base(mapper, unitOfWork, mediator)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievements(driverId);

        if (driverAchievements == null)
            return NotFound("Achievements not found");

        var resullt = _mapper.Map<DriverAchievementsResponse>(driverAchievements);

        return Ok(resullt);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievements([FromBody] CreateDriverAchievementsRequest achievements)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Achievements>(achievements);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }


    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementsRequest achievements)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Achievements>(achievements);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}