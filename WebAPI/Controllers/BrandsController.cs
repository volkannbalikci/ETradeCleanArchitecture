using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandResponse createdBrandResponse = await Mediator.Send(createBrandCommand);
        return Ok(createdBrandResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new() { Id = id };
        DeletedBrandResponse deletedBrandResponse = await Mediator.Send(deleteBrandCommand);
        return Ok(deletedBrandResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse updatedBrandResponse= await Mediator.Send(updateBrandCommand);
        return Ok(updatedBrandResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> getListBrandResponse = await Mediator.Send(getListBrandQuery);
        return Ok(getListBrandResponse);
    }
}