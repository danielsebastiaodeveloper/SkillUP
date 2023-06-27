using Dapper;
using SkillUP.Domain.Entities;
using SkillUP.Domain.Interfaces.Repositories;
using SkillUP.Persistence.Contexts;

namespace SkillUP.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly SkillUPDapperDbContext dbContext;

    public ClienteRepository(SkillUPDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<long> CreateAsync(Cliente entity, CancellationToken cancellationToken = default)
    {
        var task = await Task.Run(async () =>
        {
            string query = "INSERT INTO Clientes (Name, Email, CreatedBy, CreatedAt, State) VALUES (@Name, @Email, @CreatedBy, @CreatedAt, @State); SELECT LAST_INSERT_ID();";
            using var con = dbContext.CreateConnection();
            var obj = new
            {
                Name = entity.Name,
                @Email = entity.Email,
                @CreatedBy = entity.CreatedBy,
                @CreatedAt = entity.CreatedAt,
                @State = entity.State,

            };
            var result = await con.ExecuteScalarAsync<long>(query, obj);
            return result;
        }, cancellationToken);
        return task;
    }


    public async Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default)
    {
        // Mover la parte de check para un Filter en el controlador.
        var check = await GetEntityByIdAsync(Id);


        if (check is not null)
        {
            var task = await Task.Run(async () =>
            {

                string query = "DELETE FROM Clientes WHERE Id = @Id; SELECT ROW_COUNT();";
                using var con = dbContext.CreateConnection();
                var obj = new
                {
                    @Id = Id
                };
                var result = await con.ExecuteScalarAsync<long>(query, obj);
                return result > 0;
            }, cancellationToken);

            return task;
        }
        return false;
    }

    public Task<IEnumerable<Cliente>> GetAllEntitiesAsync(object? param, CancellationToken cancellationToken = default)
    {
        var task = Task.Run(async () =>
        {
            string query = "SELECT Id, Name, Email, State FROM Clientes;";
            using var con = dbContext.CreateConnection();
            var result = await con.QueryAsync<Cliente>(query, param);
            return result;
        });

        return task;
    }

    public async Task<Cliente> GetEntityByIdAsync(long Id, CancellationToken cancellationToken = default)
    {

        var task = await Task.Run(async () =>
        {

            string query = "SELECT Id, Name, Email, State FROM Clientes WHERE Id = @Id;";
            using var con = dbContext.CreateConnection();
            var obj = new
            {
                @Id = Id
            };
            var result = await con.QueryAsync<Cliente>(query, obj);
            return result.FirstOrDefault();
        });
        return task ?? default!;
    }





    public async Task<bool> UpdateAsync(Cliente entity, long Id, CancellationToken cancellationToken = default)
    {
        // Mover la parte de check para un Filter en el controlador.
        var check = await GetEntityByIdAsync(Id, cancellationToken);

        if (check is not null)
        {
            var task = await Task.Run(async () =>
            {
                string query = "UPDATE Clientes  SET Name = @Name, Email = @Email, CreatedBy = @CreatedBy, CreatedAt = @CreatedAt, State = @State WHERE Id = @Id; SELECT ROW_COUNT();";
                using var con = dbContext.CreateConnection();
                var obj = new
                {
                    Name = entity.Name,
                    @Email = entity.Email,
                    @CreatedBy = check.CreatedBy,
                    @CreatedAt = entity.CreatedAt,
                    @State = entity.State,
                    @Id = Id
                };
                var result = await con.ExecuteScalarAsync<long>(query, obj);
                return result > 0;
            }, cancellationToken);

            return task;
        }

        return false;
    }
}
