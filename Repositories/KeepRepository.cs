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
      INSERT INTO keeps(name, img, userid, isPrivate, description)
      VALUES(@name, @img, @userid, @isPrivate, @description);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep GetById(int keepid)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = @keepid", new { keepid });
    }

    public bool DeleteKeep(int keepid, string userid)
    {
      int success = _db.Execute(@"DELETE FROM keeps WHERE id = @keepid AND userId = @userid", new { keepid });
      return success != 0;
    }
    public int IncreaseViews(int keepid)
    {
      int success = _db.Execute(@"UPDATE keeps SET views = views+1
      WHERE id = @keepid;", new { keepid });
      return success;
      //SQL UPDATE keeps  SET views =@views
      //WHERE id =@keepid AND userid = @userid
    }
  }
}