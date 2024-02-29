using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimResponse createdUserOperationClaimResponse = await Mediator.Send(createUserOperationClaimCommand);
        return Ok(createdUserOperationClaimResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteUserOperationClaimCommand deleteUserOperationClaimCommand = new() { Id = id };
        DeletedUserOperationClaimResponse deletedUserOperationClaimResponse = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(deletedUserOperationClaimResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        UpdatedUserOperationClaimResponse updatedUserOperationClaimResponse = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(updatedUserOperationClaimResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserOperationClaimListItemDto> getListUserOperationClaimResponse = await Mediator.Send(getListUserOperationClaimQuery);
        return Ok(getListUserOperationClaimResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery = new() { Id = id };
        GetByIdUserOperationClaimResponse getByIdUserOpereationClaimResponse = await Mediator.Send(getByIdUserOperationClaimQuery);
        return Ok(getByIdUserOpereationClaimResponse);
    }
}
