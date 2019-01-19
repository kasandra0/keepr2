using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }
    // POST api/vaults
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> AddVault([FromBody] PreVault preVault)
    {
      preVault.UserId = HttpContext.User.Identity.Name;
      Vault newVault = new Vault(preVault);
      Vault result = _repo.AddVault(newVault);
      return Created("/api/vaults/" + result.Id, result);
    }

  }
}