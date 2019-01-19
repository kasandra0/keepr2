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

    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps(name, img, userid)
      VALUES(@name, @img, @userid);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep GetById(int keepid)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = @keepid", new { keepid });
    }
  }
}