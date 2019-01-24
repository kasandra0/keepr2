using System.Collections.Generic;
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
      newKeep.UserId = HttpContext.User.Identity.Name;

      Keep result = _repo.AddKeep(newKeep);
      return Created("/api/keeps/" + result.Id, result);
    }
    // GET api/keeps -- all public keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAllPublicKeeps()
    {
      return Ok(_repo.GetAllPublicKeeps());
    }
    // GET api/keeps/user -- all keeps by user
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetAllUserKeeps()
    {
      string userid = HttpContext.User.Identity.Name;
      return Ok(_repo.GetAllUserKeeps(userid));
    }
    // GET api/keeps/5
    [HttpGet("{keepid}")]
    public ActionResult<Keep> Get(int keepid)
    {
      Keep result = _repo.GetById(keepid);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    // Delete api/keeps
    [HttpDelete("{keepid}")]
    public ActionResult<string> DeleteKeep(int keepid)
    {
      string userid = HttpContext.User.Identity.Name;
      if (_repo.DeleteKeep(keepid, userid))
      {
        return Ok("Deleted Keep");
      }
      return BadRequest("Cannot to delete Keep!");
    }
    [HttpPut("{keepid}/views")]
    public ActionResult<int> IncreaseViews(int keepid)
    {
      int result = _repo.IncreaseViews(keepid);
      return Ok(result);
    }
  }
}