using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductResponse createdProductResponse = await Mediator.Send(createProductCommand);
        return Ok(createdProductResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteProductCommand deleteProductCommand= new() { Id = id };
        DeletedProductResponse deletedProductResponse = await Mediator.Send(deleteProductCommand);
        return Ok(deletedProductResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        UpdatedProductResponse updatedProductResponse = await Mediator.Send(updateProductCommand);
        return Ok(updatedProductResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductListItemDto> getListProductResponse = await Mediator.Send(getListProductQuery);
        return Ok(getListProductResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductQuery getByIdProductQuery = new() { Id = id };
        GetByIdProductResponse getByIdProductResponse = await Mediator.Send(getByIdProductQuery);
        return Ok(getByIdProductResponse);
    }
}
