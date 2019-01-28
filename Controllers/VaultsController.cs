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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }
    // POST api/vaults
    [HttpPost]
    public ActionResult<Vault> AddVault([FromBody] PreVault preVault)
    {
      Vault newVault = new Vault();
      newVault.UserId = HttpContext.User.Identity.Name;
      newVault.Name = preVault.Name;
      newVault.Description = preVault.Description;
      Vault result = _repo.AddVault(newVault);
      return Created("/api/vaults/" + result.Id, result);
    }
    // GET api/vaults -- ALL vaults by user
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetAllVaultsByUser()
    {
      string userid = HttpContext.User.Identity.Name;
      return Ok(_repo.GetAllVaultsByUser(userid));
    }
    // GET api/vaults/5 - Get specific vault
    [HttpGet("{vaultid}")]
    public ActionResult<Vault> GetVault(int vaultid)
    {
      Vault result = _repo.GetVaultById(vaultid);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }
    [HttpDelete("{vaultid}")]
    public ActionResult<string> DeleteVault(int vaultid)
    {
      string userid = HttpContext.User.Identity.Name;
      if (_repo.DeleteVault(vaultid))
      {
        return Ok("Deleted Vault");
      }
      return BadRequest("Cannot to delete Vault!");
    }
  }
}