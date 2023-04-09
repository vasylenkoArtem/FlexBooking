using FlexBooking.Domain.Helpers.Contract;
using Microsoft.Extensions.Configuration;

namespace FlexBooking.Domain.Helpers;

public class ConnectionStringHelper : IConnectionStringHelper
{
    private readonly string? _connectionString;
    
    public ConnectionStringHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public string? GetConnectionString()
    {
        return _connectionString;
    }
}

