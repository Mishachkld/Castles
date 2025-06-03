using Castles.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Castles.WebAPI.Controllers;

public class CastleController : Controller
{
    [HttpGet]
    public IActionResult Castles()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Castle(Guid id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult CastleCreate(Castle castleNew)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult CastleDelete(Guid id)
    {
        return View();
    }

    [HttpPut]
    public IActionResult CastleUpdate(Castle updatedCastle)
    {
        return Ok();
    }
    
    
}