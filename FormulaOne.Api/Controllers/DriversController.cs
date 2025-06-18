using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null)
            return NotFound("Driver not found!");

        var resullt = _mapper.Map<GetDriverResponse>(driver);

        return Ok(resullt);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _unitOfWork.Drivers.All();

        if (drivers == null)
            return NotFound("Driver not found!");

        return Ok(_mapper.Map<IEnumerable<GetDriverResponse>>(drivers));
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {

        if (!ModelState.IsValid)
            return BadRequest();

        var resullt = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Add(resullt);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { driverId = resullt.Id }, resullt);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDrivers([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null)
            return NotFound("Driver not found!");

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();

    }

}