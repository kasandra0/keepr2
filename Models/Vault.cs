
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep //Helper class
  {
    // [Required]
    public int Id { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }
    [Required]
    public string UserId { get; set; }
  }
  public class PreVault
  {
    public string Description { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
  }

  public class Vault
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string UserId { get; set; }
    public string Description { get; set; }
  }
}