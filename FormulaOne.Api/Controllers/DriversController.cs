using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{

    public DriversController(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator) : base(mapper, unitOfWork, mediator)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query = new GetDriverQuery(driverId);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var query = new GetAllDriversQuery();
        var driversResult = await _mediator.Send(query);

        return Ok(driversResult);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {

        if (!ModelState.IsValid)
            return BadRequest();
        var command = new CreateDriverInfoRequest(driver);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDrivers([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new UpdateDriverInfoRequest(driver);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverInfoRequest(driverId);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

}