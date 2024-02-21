using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertCommand createAdvertCommand)
    {
        CreatedAdvertResposne createdAdvertResposne = await Mediator.Send(createAdvertCommand);
        return Ok(createdAdvertResposne);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAdvertCommand deleteAdvertCommand = new() { Id = id };
        DeletedAdvertResponse deletedAdvertResponse = await Mediator.Send(deleteAdvertCommand);
        return Ok(deletedAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertCommand updateAdvertCommand)
    {
        UpdatedAdvertResponse updatedAdvertResponse = await Mediator.Send(updateAdvertCommand);
        return Ok(updatedAdvertResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertQuery getListAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertListItemDto> getListAdvertResponse = await Mediator.Send(getListAdvertQuery);
        return Ok(getListAdvertResponse);
    }

    [HttpGet("{id}")]
    async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertQuery getByIdAdvertQuery = new() { Id = id };
        GetByIdAdvertResponse getByIdAdvertResponse = await Mediator.Send(getByIdAdvertQuery);
        return Ok(getByIdAdvertResponse);
    }
}
