using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCountryCommand createCountryCommand)
    {
        CreatedCountryResponse createdCountryResponse = await Mediator.Send(createCountryCommand);
        return Ok(createdCountryResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCountryCommand deleteCountryCommand = new() { Id = id };
        DeletedCountryResponse deletedCountryResponse = await Mediator.Send(deleteCountryCommand);
        return Ok(deletedCountryResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCountryCommand updateCountryCommand)
    {
        UpdatedCountryResponse updatedCountryResponse = await Mediator.Send(updateCountryCommand);
        return Ok(updatedCountryResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCountryQuery getListCountryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCountryListItemDto> getListCountryResponse = await Mediator.Send(getListCountryQuery);
        return Ok(getListCountryResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCountryQuery getByIdCountryQuery = new() { Id = id };
        GetByIdCountryResponse getByIdCountryResponse = await Mediator.Send(getByIdCountryQuery);
        return Ok(getByIdCountryResponse);
    }
}
