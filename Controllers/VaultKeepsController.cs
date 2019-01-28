
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    //POST api/vaultkeeps -- add keep 
    [HttpPost]
    public VaultKeep Post([FromBody] VaultKeep vk)
    {
      vk.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(vk);
      return result;
    }
    // GET keeps by vaultid
    [HttpGet("{vaultid}")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int vaultid)
    {
      return Ok(_repo.GetKeepsByVaultId(vaultid));
    }
    // Delete keep from vault
    [HttpPut]
    public ActionResult<string> RemoveKeepFromVault([FromBody] VaultKeep vk)
    {
      string userid = HttpContext.User.Identity.Name;
      if (_repo.RemoveKeepFromVault(vk.VaultId, vk.KeepId, userid))
      {
        return Ok("Removed Keep from Vault");
      }
      return BadRequest("Cannot remove Keep from Vault");
    }

  }
}