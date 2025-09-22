using Microsoft.AspNetCore.Mvc;
using Rowing.Domain.Entities;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StrokePhasesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<StrokePhase> GetAll()
    {
        return new List<StrokePhase>
        {
            new() { Id = 1, Name = "Catch", KeyFocus = "Blade entry" },
            new() { Id = 2, Name = "Drive", KeyFocus = "Power application" }
        };

    }

    [HttpGet("{id}")]
    public StrokePhase GetById(int id)
    {
        return new StrokePhase {Id = id, Name = "Finish", KeyFocus = "Clean exit" };
    }
}