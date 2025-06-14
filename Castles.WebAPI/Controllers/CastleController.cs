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
    private readonly ILogger<CastleController> _logger;

    public CastleController(IRepositoryCRUD<Castle> repository, CastleService service, ILogger<CastleController> logger)
    {
        _repository = repository;
        _service = service;
        _logger = logger;
    }

    [HttpGet("castles")]
    public async Task<IActionResult> Castles()
    {
        var castles = await _service.GetCastles();
        return Ok(castles);
    }

    [HttpGet("castle/{id:guid}")]
    public async Task<IActionResult> Castle(Guid id)
    {
        CastleDetails castle;
        try
        {
            castle = await _service.GetCastleWithDetailsAsync(id);
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
            _logger.LogInformation($"Created castle with id: '{response.Id}'");
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
    public async Task<IActionResult> CastleUpdate(Guid id, [FromBody] CastleUpdateDto updatedCastle)
    {
        Castle response;
        try
        {
            response = await _service.UpdateCastleAsync(id, updatedCastle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(response);
    }
}