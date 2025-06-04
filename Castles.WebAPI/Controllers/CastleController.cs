using AutoMapper;
using Castles.Application.Interfaces;
using Castles.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Castles.WebAPI.Controllers;

[Route("api")] // Базовый маршрут: /api
[ApiController]
public class CastleController : ControllerBase
{
    private readonly IRepositoryCRUD<Castle> _repository;

    public CastleController(IRepositoryCRUD<Castle> repository)
    {
        _repository = repository;
    }

    [HttpGet("castles")] // Явный абсолютный путь
    public async Task<IActionResult> Castles()
    {
        var castles = await _repository.GetAll();
        return Ok(castles);
    }

    [HttpGet("castle/{id:guid}")]
    public async Task<IActionResult> Castle(Guid id)
    {
        var castle = await _repository.Get(id);
        return Ok(castle);
    }

    [HttpPost("castle")]
    public async Task<IActionResult> CastleCreate([FromBody] Castle castleNew)
    {
        var response = await _repository.Add(castleNew);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult CastleDelete(Guid id)
    {
        return Ok($"Deleted {id}");
    }

    [HttpPut("{id:guid}")]
    public IActionResult CastleUpdate(Guid id, [FromBody] Castle updatedCastle)
    {
        return Ok(updatedCastle);
    }
}