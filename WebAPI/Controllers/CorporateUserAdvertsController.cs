using Application.Features.CorporateUserAdverts.Commands.Create;
using Application.Features.CorporateUserAdverts.Commands.Delete;
using Application.Features.CorporateUserAdverts.Commands.Update;
using Application.Features.CorporateUserAdverts.Queries.GetById;
using Application.Features.CorporateUserAdverts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateUserAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateUserAdvertCommand createCorporateUserAdvertCommand)
    {
        CreatedCorporateUserAdvertResponse createdCorporateUserAdvertResponse = await Mediator.Send(createCorporateUserAdvertCommand);
        return Ok(createdCorporateUserAdvertResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCorporateUserAdvertCommand deleteCorporateUserAdvertCommand = new() { Id = id };
        DeletedCorporateUserAdvertResponse deletedCorporateUserAdvertResponse = await Mediator.Send(deleteCorporateUserAdvertCommand);
        return Ok(deletedCorporateUserAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateUserAdvertCommand updateCorporateUserAdvertCommand)
    {
        UpdatedCorporateUserAdvertResponse updatedCorporateUserAdvertResponse = await Mediator.Send(updateCorporateUserAdvertCommand);
        return Ok(updatedCorporateUserAdvertResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateUserAdvertQuery getListCorporateUserAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCorporateUserAdvertListItemDto> getListCorporateUserAdvertResponse = await Mediator.Send(getListCorporateUserAdvertQuery);
        return Ok(getListCorporateUserAdvertResponse);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateUserAdvertQuery getByIdCorporateUserAdvertQuery = new() { Id = id };
        GetByIdCorporateUserAdvertResponse getByIdCorporateUserAdvertResponse = await Mediator.Send(getByIdCorporateUserAdvertQuery);
        return Ok(getByIdCorporateUserAdvertResponse);
    }
}
