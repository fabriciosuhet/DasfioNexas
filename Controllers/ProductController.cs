
using DesafioNexas.Entities;
using DesafioNexas.Interface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNexas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductsById(int id)
    {
        var produto = await _productService.ObterProdutoPorIdAsync(id);
        return Ok(produto);
    }

    [HttpPut("{id}/alterar-produto")]
    public async Task<IActionResult> EditProduct([FromBody] Product? product, int id)
    {
        await _productService.ObterProdutoPorIdAsync(id);
        if (product == null)
        {
            return NotFound("Produto nào encontrado");
        }
        await _productService.AlterarProdutoAsync(id, product);
        return Ok("Produto alterado");
    }

    [HttpPost("criar-produto")]
    public async Task<IActionResult> CreateProduct([FromBody] Product? product)
    {
        if (product == null)
        {
            return NotFound("Produto não pode ser nulo");
        }
        
        await _productService.CadastrarProdutoAsync(product);
        return Ok("Produto cadastrado");
    }

    [HttpDelete("deletar-produto/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (id < 0 || id == null)
        {
            return NotFound("O id não foi encontrado");
        }
        await _productService.RemoverProdutoAsync(id);
        return Ok("Produto removido");
    }
}