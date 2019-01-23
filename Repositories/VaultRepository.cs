using System;
using System.Collections.Generic;
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
    public Vault GetVaultById(int vaultid)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = @vaultid", new { vaultid });
    }
    public IEnumerable<Vault> GetAllVaultsByUser(string userid)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userid", new { userid });
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

    internal bool DeleteVault(int vaultid)
    {
      int success = _db.Execute(@"DELETE FROM vaults WHERE id = @vaultid", new { vaultid });
      return success != 0;
    }
  }
}