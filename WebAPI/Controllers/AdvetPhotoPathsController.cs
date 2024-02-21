using Application.Features.AdvertPhotoPaths.Commands.Create;
using Application.Features.AdvertPhotoPaths.Commands.Delete;
using Application.Features.AdvertPhotoPaths.Commands.Update;
using Application.Features.AdvertPhotoPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvetPhotoPathsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertPhotoPathCommand createAdvertPhotoPathCommand)
    {
        CreatedAdvertPhotoPathResponse createdAdvertPhotoPathResponse = await Mediator.Send(createAdvertPhotoPathCommand);
        return Ok(createdAdvertPhotoPathResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAdvertPhotoPathCommand deleteAdvertPhotoPathCommand = new() { Id = id };
        DeletedAdvertPhotoPathResponse deletedAdminResponse = await Mediator.Send(deleteAdvertPhotoPathCommand);
        return Ok(deletedAdminResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertPhotoPathCommand updateAdvertPhotoPathCommand)
    {
        UpdatedAdvertPhotoPathResponse updatedAdvertPhotoPathResponse= await Mediator.Send(updateAdvertPhotoPathCommand);
        return Ok(updatedAdvertPhotoPathResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertPhotoPathQuery getListAdvertPhotoPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertPhotoPathListItemDto> getListAdvertPhotoPathResponse= await Mediator.Send(getListAdvertPhotoPathQuery);
        return Ok(getListAdvertPhotoPathResponse);
    }
}