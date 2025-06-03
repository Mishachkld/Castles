using Castles.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Castles.WebAPI.Controllers;

[Route("api")] // Базовый маршрут: /api
[ApiController]
public class CastleController : ControllerBase
{
    [HttpGet("castles")] // Явный абсолютный путь
    public IActionResult Castles()
    {
        var castles = new List<Castle>()
        {
            new Castle()
            {
                Id = Guid.NewGuid(),
                Name = "King 1",
                Description = "King 1 description",
            },
            new Castle()
            {
                Id = Guid.NewGuid(),
                Name = "King 2",
                Description = "King 2 description",
            }
        };
        return Ok(castles);
    }

    [HttpGet("{id:guid}")]
    public IActionResult Castle(Guid id)
    {
        return Ok(new Castle()
        {
            Id = id,
            Name = "Dynamic King",
            Description = "Description for " + id
        });
    }

    [HttpPost]
    public IActionResult CastleCreate([FromBody] Castle castleNew)
    {
        return Ok(castleNew);
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