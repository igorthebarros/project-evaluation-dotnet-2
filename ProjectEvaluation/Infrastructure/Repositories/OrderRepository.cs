using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await GetByIdAsync(id, cancellationToken);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IReadOnlyList<Order>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken);

            if (orders == null)
                return null;

            return orders;
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return order;
        }

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
