using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of IOrderRepository using Entity Framework Core
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        /// <summary>
        /// Initializes a new instance of OrderRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public OrderRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Order in the database
        /// </summary>
        /// <param name="entity">An Order and it's details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Order</returns>
        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Deletes an Order from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Order to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Order was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await GetByIdAsync(id, cancellationToken);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// Retrieves all Orders from the database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of immutable Orders</returns>
        public async Task<IReadOnlyList<Order>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken);

            if (orders == null)
                return null;

            return orders;
        }

        /// <summary>
        /// Retrieve an Order by it's Guid Id from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the Order to be retrieved</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A product if it's found or, if not, a default object</returns>
        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return order;
        }

        /// <summary>
        /// Update an Order register replacing it by the new register. 
        /// This changes all the entity.
        /// </summary>
        /// <param name="entity">The new sale entity to be registered</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Creates a new Order, if no equally Order is found beforehand,
        /// otherwise, update the existant product entity by the new one</returns>
        public async Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var existantOrder = await GetByIdAsync(entity.Id, cancellationToken);

            if (existantOrder == null)
                await _context.Orders.AddAsync(entity, cancellationToken);
            else
                _context.Orders.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
