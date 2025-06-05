using AutoMapper;
using Castles.Application.DTO.WebDto;
using Castles.Application.Interfaces;
using Castles.Application.Service;
using Castles.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Castles.WebAPI.Controllers;

[Route("api")] // Базовый маршрут: /api
[ApiController]
public class CastleController : ControllerBase
{
    private readonly IRepositoryCRUD<Castle> _repository;
    private readonly CastleService _service;

    public CastleController(IRepositoryCRUD<Castle> repository, CastleService service)
    {
        _repository = repository;
        _service = service;
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
        Castle castle;
        try
        {
            castle = await _repository.Get(id);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

        return Ok(castle);
    }

    [HttpPost("castle")]
    public async Task<IActionResult> CastleCreate([FromBody] CreateCastleDto castleNew)
    {
        CastleDetails response;
        try
        {
            response = await _service.CreateCastleAsync(castleNew);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }

    [HttpDelete("castle/{id:guid}")]
    public async Task<IActionResult> CastleDelete(Guid id)
    {
        bool response;
        try
        {
            response = await _repository.Delete(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }

    [HttpPut("castle/{id:guid}")]
    public async Task<IActionResult> CastleUpdate(Guid id, [FromBody] Castle updatedCastle)
    {
        Castle response;
        try
        {
            response = await _repository.Update(id, updatedCastle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }
}