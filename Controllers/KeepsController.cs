using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;

    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }
    // POST api/keeps
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      Keep result = _repo.AddKeep(newKeep);
      return Created("/api/keep/" + result.Id, result);
    }
    // GET api/keeps/5
    public ActionResult<Keep> Get(int keepid)
    {
      Keep result = _repo.GetById(keepid);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
  }
}