using Application.Features.IndividualUserAdverts.Commands.Create;
using Application.Features.IndividualUserAdverts.Commands.Delete;
using Application.Features.IndividualUserAdverts.Commands.Update;
using Application.Features.IndividualUserAdverts.Queries.GetById;
using Application.Features.IndividualUserAdverts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualUserAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualUserAdvertCommand createIndividualUserAdvertCommand)
    {
        CreatedIndividualUserAdvertResponse createdIndividualUserAdvertResponse = await Mediator.Send(createIndividualUserAdvertCommand);
        return Ok(createdIndividualUserAdvertResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteIndividualUserAdvertCommand deleteIndividualUserAdvertCommand = new() { Id = id };
        DeletedIndividualUserAdvertResponse deletedIndividualUserAdvertResponse = await Mediator.Send(deleteIndividualUserAdvertCommand);
        return Ok(deletedIndividualUserAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualUserAdvertCommand updateIndividualUserAdvertCommand)
    {
        UpdatedIndividualUserAdvertResponse updatedIndividualUserAdvertResponse= await Mediator.Send(updateIndividualUserAdvertCommand);
        return Ok(updatedIndividualUserAdvertResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndividualUserAdvertQuery getListIndividualUserAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListIndividualUserAdvertListItemDto> getListIndividualUserAdvertResponse= await Mediator.Send(getListIndividualUserAdvertQuery);
        return Ok(getListIndividualUserAdvertResponse);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualUserAdvertQuery getByIdIndividualUserAdvertQuery = new() { Id = id };
        GetByIdIndividualUserAdvertResponse getByIdIndividualUserAdvertResponse = await Mediator.Send(getByIdIndividualUserAdvertQuery);
        return Ok(getByIdIndividualUserAdvertResponse);
    }
}
