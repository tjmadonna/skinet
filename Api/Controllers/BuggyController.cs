using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _storeContext;

    public BuggyController(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    [HttpGet("notfound")]
    public IActionResult GetNotFoundRequest()
    {
        var thing = _storeContext.Products.Find(42);
        if (thing == null)
            return NotFound(new ApiResponse(404));

        return Ok();
    }

    [HttpGet("servererror")]
    public IActionResult GetServiceError()
    {
        var thing = _storeContext.Products.Find(42);
        var thingToReturn = thing.ToString();
        return Ok();
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public IActionResult GetNotFoundRequest(int id)
    {
        return Ok();
    }
}