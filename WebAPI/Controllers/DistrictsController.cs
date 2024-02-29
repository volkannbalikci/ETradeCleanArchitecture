using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDistrictCommand createDistrictCommand)
    {
        CreatedDistrictResponse createdDistrictResponse = await Mediator.Send(createDistrictCommand);
        return Ok(createdDistrictResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteDistrictCommand deleteDistrictCommand = new() { Id = id };
        DeletedDistrictResponse deletedDistrictResponse = await Mediator.Send(deleteDistrictCommand);
        return Ok(deletedDistrictResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDistrictCommand updateDistrictCommand)
    {
        UpdatedDistrictResponse updatedDistrictResponse = await Mediator.Send(updateDistrictCommand);
        return Ok(updatedDistrictResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDistrictQuery getListDistrictQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDistrictListItemDto> getListDistrictResponse= await Mediator.Send(getListDistrictQuery);
        return Ok(getListDistrictResponse);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDistrictQuery getByIdDistrictQuery = new() { Id = id };
        GetByIdDistrictResponse getByIdDistrictResponse = await Mediator.Send(getByIdDistrictQuery);
        return Ok(getByIdDistrictResponse);
    }
}
