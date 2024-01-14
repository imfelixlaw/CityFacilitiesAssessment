using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services;

public interface IForwarderService
{
    Task<List<Product>> GetProductFromVendor();
}
