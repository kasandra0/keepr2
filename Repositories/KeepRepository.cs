using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }
    public IEnumerable<Keep> GetAllUserKeeps(string userid)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userid", new { userid });
    }

    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps(name, img, userid, isPrivate)
      VALUES(@name, @img, @userid, @isPrivate);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep GetById(int keepid)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = @keepid", new { keepid });
    }

    public bool DeleteKeep(int keepid)
    {
      int success = _db.Execute(@"DELETE FROM keeps WHERE id = @keepid", new { keepid });
      return success != 0;
    }
  }
}