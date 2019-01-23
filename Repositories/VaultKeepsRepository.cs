
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultid)
    {
      return _db.Query<Keep>($@"
      SELECT * From vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultid);
      ", new { vaultid });
    }
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps(vaultId, keepId, userId)
       VALUES (@vaultId, @keepId, @UserId);
       SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }
    public bool RemoveKeepFromVault(int vid, int kid, string userid)
    {
      int success = _db.Execute(@"DELETE FROM vaultkeeps
       WHERE (vaultId = @vid AND keepId = @kid AND userId = @userid)", new { vid, kid, userid });
      return success != 0;
    }
  }
}