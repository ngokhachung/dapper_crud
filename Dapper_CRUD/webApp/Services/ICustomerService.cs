using webApp.Models;

namespace webApp.Services
{
    public interface ICustomerService
    {
        Task<int> AddAsync(Customer customer);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<int> UpdateAsync(Customer entity);
    }
}
