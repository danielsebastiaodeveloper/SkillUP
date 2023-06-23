using MySqlConnector;
using System.Data;

namespace SkillUP.Persistence.Contexts;

public class SkillUPDapperDbContext
{
    private readonly string _connectionString;

    public SkillUPDapperDbContext(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException($"{nameof(connectionString)} can't be null.");
        }
        this._connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
       return new MySqlConnection(this._connectionString);
    }
}
