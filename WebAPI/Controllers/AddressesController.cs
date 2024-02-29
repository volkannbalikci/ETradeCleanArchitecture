using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetById;
using Application.Features.Addresses.Queries.GetList;
using Application.Features.Brands.Commands;
using Application.Features.IndividualUserAdverts.Commands.Delete;
using Application.Features.IndividualUserAdverts.Commands.Update;
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
        return Ok(getListAddressResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAddressQuery getByIdAddressQuery = new() { Id = id };
        GetByIdAddressResponse getByIdAddressResponse = await Mediator.Send(getByIdAddressQuery);
        return Ok(getByIdAddressResponse);
    }
}
