using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdminCommand createAdminCommand)
    {
        CreatedAdminResponse createdAdminResponse= await Mediator.Send(createAdminCommand);
        return Ok(createdAdminResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAdminCommand deleteAdminCommand = new() { Id = id };
        DeletedAdminResponse deletedAdminResponse = await Mediator.Send(deleteAdminCommand);
        return Ok(deletedAdminResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdminCommand updateAdminCommand)
    {
        UpdatedAdminResponse updatedAdminResponse= await Mediator.Send(updateAdminCommand);
        return Ok(updatedAdminResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdminQuery getListAdminQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdminListItemDto> getListAdminResponse= await Mediator.Send(getListAdminQuery);
        return Ok(getListAdminResponse);
    }
}
