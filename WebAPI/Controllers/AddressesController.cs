using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetList;
using Application.Features.Brands.Commands;
using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddressCommand)
    {
        CreatedAddressResponse createdAddressResponse = await Mediator.Send(createAddressCommand);
        return Ok(createdAddressResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAddressCommand deleteAddressCommand = new() { Id = id };
        DeletedAddressResponse deletedAddressResponse = await Mediator.Send(deleteAddressCommand);
        return Ok(deletedAddressResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
    {
        UpdatedAddressResponse updatedAddressResponse = await Mediator.Send(updateAddressCommand);
        return Ok(updatedAddressResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAddressQuery getListAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAddressListItemDto> getListAddressResponse = await Mediator.Send(getListAddressQuery);
        return Ok(getListAddressQuery);
    }
}

public class CategoriesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse createdCategoryResponse = await Mediator.Send(createCategoryCommand);
        return Ok(createdCategoryResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCategoryCommand deleteCategoryCommand = new() { Id = id };
        DeletedCategoryResponse deletedCategoryResponse = await Mediator.Send(deleteCategoryCommand);
        return Ok(deleteCategoryCommand);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
    {
        UpdatedAddressResponse updatedAddressResponse = await Mediator.Send(updateAddressCommand);
        return Ok(updatedAddressResponse);
    }

    [HttpGet]
    //public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    //{
    //    GetListCategoryQuery getListCategoryListItemDto = new() {  };
    //    GetListResponse<GetListAddressListItemDto> getListAddressResponse = await Mediator.Send(getListAddressQuery);
    //    return Ok(getListAddressQuery);
    //}
}
