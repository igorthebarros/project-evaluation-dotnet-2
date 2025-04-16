using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Application.Services
{
    /// <summary>
    /// Implementation of IOrderService that holds business logic
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        /// <summary>
        /// Initializes a new instance of OrderService
        /// </summary>
        /// <param name="repository">The Order service</param>
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Apply any business rule and send new Order to the repository
        /// </summary>
        /// <param name="entity">A Order and it's details</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The created Order</returns>
        public async Task<Order> CreateAsync(Order entity, CancellationToken token = default)
        {
            var result = await _repository.CreateAsync(entity, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and delete Order, sendig it to the repository
        /// </summary>
        /// <param name="id">The unique identifier of the Order to delete</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>True if the Order was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var result = await _repository.DeleteAsync(id, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and retrieves all, calling the repository
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>A list of immutable Orders</returns>
        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken token = default)
        {
            var result = await _repository.GetAllAsync(token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and retrieve an Order by it's Guid Id,
        /// calling the repository
        /// </summary>
        /// <param name="id">The unique identifier of the Order to be retrieved</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>An Order if it's found or, if not, a default object</returns>
        public async Task<Order> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var result = await _repository.GetByIdAsync(id, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and update an Order register,
        /// replacing it by the new register.
        /// This changes all the entity.
        /// </summary>
        /// <param name="entity">The new Order entity to be registered</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Creates an new Order, if no equally product is found beforehand,
        /// otherwise, update the existant Order entity by the new one</returns>
        public async Task<Order> UpdateAsync(Order entity, CancellationToken token = default)
        {
            var result = await _repository.UpdateAsync(entity, token);
            return result;
        }
    }
}
