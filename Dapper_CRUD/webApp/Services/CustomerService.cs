using webApp.Models;

namespace webApp.Services
{
    public class CustomerService(IUnitOfWork unitOfWork) : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> AddAsync(Customer customer) 
            => await _unitOfWork.Cusomers.AddAsync(customer);

        public Task<int> DeleteAsync(int id)
             => _unitOfWork.Cusomers.DeleteAsync(id);
        public Task<IReadOnlyList<Customer>> GetAllAsync()
            => _unitOfWork.Cusomers.GetAllAsync();
            
        public Task<Customer?> GetByIdAsync(int id)
            => _unitOfWork.Cusomers.GetByIdAsync(id);

        public Task<int> UpdateAsync(Customer entity)
            => _unitOfWork.Cusomers.UpdateAsync(entity);
    }
}
