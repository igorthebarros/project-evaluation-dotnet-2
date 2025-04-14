using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.CreateAsync(entity, cancellationToken);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteAsync(id, cancellationToken);
            return result;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            return result;
        }

        public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateAsync(entity, cancellationToken);
            return result;
        }
    }
}
