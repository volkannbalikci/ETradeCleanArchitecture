using Application.Features.IndividualUsers.Commands.Create;
using Application.Features.IndividualUsers.Commands.Delete;
using Application.Features.IndividualUsers.Commands.Update;
using Application.Features.IndividualUsers.Queries.GetById;
using Application.Features.IndividualUsers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualUsersController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualUserCommand createIndividualUserCommand)
    {
        CreatedIndividualUserResponse createdIndividualUserResponse = await Mediator.Send(createIndividualUserCommand);
        return Ok(createdIndividualUserResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteIndividualUserCommand deleteIndividualUserCommand= new() { Id = id };
        DeletedIndividualUserResponse deletedIndividualUserResponse = await Mediator.Send(deleteIndividualUserCommand);
        return Ok(deletedIndividualUserResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualUserCommand updateIndividualUserCommand)
    {
        UpdatedIndividualUserReponse updatedIndividualUserReponse = await Mediator.Send(updateIndividualUserCommand);
        return Ok(updatedIndividualUserReponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndividualUserQuery getListIndividualUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListIndividualUserListItemDto> getListIndividualUserResponse= await Mediator.Send(getListIndividualUserQuery);
        return Ok(getListIndividualUserResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualUserQuery getByIdIndividualUserQuery = new() { Id = id };
        GetByIdIndividualUserResponse getByIdIndividualUserResponse = await Mediator.Send(getByIdIndividualUserQuery);
        return Ok(getByIdIndividualUserResponse);
    }
}
