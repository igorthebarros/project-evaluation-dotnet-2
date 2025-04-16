using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of ICompanyRepository using Entity Framework Core
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Context _context;

        /// <summary>
        /// Initializes a new instance of CompanyRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public CompanyRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Company in the database
        /// </summary>
        /// <param name="entity">A Company and it's details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Company</returns>
        public async Task<Company> CreateAsync(Company entity, CancellationToken cancellationToken = default)
        {
            await _context.Companies.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Deletes a Company from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Company to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Company was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await GetByIdAsync(id, cancellationToken);
            if (order == null)
                return false;

            _context.Companies.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// Retrieves all Companies from the database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of immutable Companies</returns>
        public async Task<IReadOnlyList<Company>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var companies = await _context.Companies.ToListAsync(cancellationToken);

            if (companies == null)
                return null;

            return companies;
        }

        /// <summary>
        /// Retrieve a Company by it's Guid Id from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Company to be retrieved</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A Company if it's found or, if not, a default object</returns>
        public async Task<Company?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return company;
        }

        /// <summary>
        /// Update a Company register replacing it by the new register. 
        /// This changes all the entity.
        /// </summary>
        /// <param name="entity">The new Company entity to be registered</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Creates a new Company, if no equally product is found beforehand,
        /// otherwise, update the existant Company entity by the new one</returns>
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
