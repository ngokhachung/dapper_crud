using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using webApp.Models;

public class CustomerRepositoy : ICustomerRepository
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;

    public CustomerRepositoy(IConfiguration configuration, IDbConnection dbConnection)
    {
        _configuration = configuration;
        _dbConnection = dbConnection;
    }
    public async Task<int> AddAsync(Customer customer)
    {
        var sql = "INSERT INTO Customer (firstName, lastName, email, dob) VALUES (@FirstName, @LastName, @Email, @DOB)";
        return await _dbConnection.ExecuteAsync(sql, customer);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Customer WHERE ID = @ID";

        var result = await _dbConnection.ExecuteAsync(sql, new { ID = id });
        return result;
    }

    public async Task<IReadOnlyList<Customer>> GetAllAsync()
    {
        var sql = "SELECT * FROM Customer";
        var result = await _dbConnection.QueryAsync<Customer>(sql);
        return result.ToList();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Customer WHERE ID = @ID";
        var result = await _dbConnection.QuerySingleOrDefaultAsync<Customer>(sql, new { ID = id });
        return result ?? null;
    }

    public async Task<int> UpdateAsync(Customer entity)
    {
        var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, Email = @Email WHERE ID = @ID";
        var result = await _dbConnection.ExecuteAsync(sql, entity);
        return result;
    }
}