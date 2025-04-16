using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Context _context;

        public CompanyRepository(Context context)
        {
            _context = context;
        }

        public async Task<Company> CreateAsync(Company entity, CancellationToken cancellationToken = default)
        {
            await _context.Companies.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await GetByIdAsync(id, cancellationToken);
            if (order == null)
                return false;

            _context.Companies.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IReadOnlyList<Company>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var companies = await _context.Companies.ToListAsync(cancellationToken);

            if (companies == null)
                return null;

            return companies;
        }

        public async Task<Company?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return company;
        }

        public async Task<Company> UpdateAsync(Company entity, CancellationToken cancellationToken = default)
        {
            var existantCompany = await GetByIdAsync(entity.Id, cancellationToken);

            if (existantCompany == null)
                await _context.Companies.AddAsync(entity, cancellationToken);
            else
                _context.Companies.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
