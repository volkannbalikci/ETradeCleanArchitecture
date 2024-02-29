using Application.Features.Commands.Create;
using Application.Features.UserAddresses.Commands.Create;
using Application.Features.UserAddresses.Commands.Delete;
using Application.Features.UserAddresses.Commands.Update;
using Application.Features.UserAddresses.Queries.GetById;
using Application.Features.UserAddresses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAddressesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserAddressCommand createUserAddressCommand)
    {
        CreatedUserAddressResponse createdUserAddressResponse = await Mediator.Send(createUserAddressCommand);
        return Ok(createdUserAddressResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteUserAddressCommand deleteUserAddressCommand = new() { Id = id };
        DeletedUserAddressResponse deletedUserAddressResponse = await Mediator.Send(deleteUserAddressCommand);
        return Ok(deletedUserAddressResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserAddressCommand updateUserAddressCommand)
    {
        UpdatedUserAddressResponse updatedUserAddressResponse = await Mediator.Send(updateUserAddressCommand);
        return Ok(updatedUserAddressResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserAddressQuey getListUserAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserAddressListItemDto> getListUserAddressResponse = await Mediator.Send(getListUserAddressQuery);
        return Ok(getListUserAddressResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserAddressQuery getByIdUserAddressQuery = new() { Id = id };
        GetByIdUserAddressResponse getByIdUserAddressResponse = await Mediator.Send(getByIdUserAddressQuery);
        return Ok(getByIdUserAddressResponse);
    }
}
