using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Vault GetById(int vaultid)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = @vaultid", new { vaultid });
    }
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults(name, description, userid)
      VALUES(@name, @description, @userid);
      SELECT LAST_INSERT_ID();
      ", newVault);
      newVault.Id = id;
      return newVault;
    }
  }
}