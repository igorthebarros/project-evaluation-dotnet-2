using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Application.Services
{
    /// <summary>
    /// Implementation of ICompanyService that holds business logic
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        /// <summary>
        /// Initializes a new instance of CompanyService
        /// </summary>
        /// <param name="repository">The Company repository</param>
        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Apply any business rule and send new Company to the repository
        /// </summary>
        /// <param name="entity">A Company and it's details</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The created Company</returns>
        public async Task<Company> CreateAsync(Company entity, CancellationToken token = default)
        {
            var result = await _repository.CreateAsync(entity, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and delete Company, sendig it to the repository
        /// </summary>
        /// <param name="id">The unique identifier of the Company to delete</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>True if the Company was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var result = await _repository.DeleteAsync(id, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and retrieves all, calling the repository
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>A list of immutable Companies</returns>
        public async Task<IEnumerable<Company>> GetAllAsync(CancellationToken token = default)
        {
            var result = await _repository.GetAllAsync(token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and retrieve a Company by it's Guid Id,
        /// calling the repository
        /// </summary>
        /// <param name="id">The unique identifier of the Company to be retrieved</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>A Company if it's found or, if not, a default object</returns>
        public async Task<Company> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var result = await _repository.GetByIdAsync(id, token);
            return result;
        }

        /// <summary>
        /// Apply any business rule and update a Company register,
        /// replacing it by the new register.
        /// This changes all the entity.
        /// </summary>
        /// <param name="entity">The new Company entity to be registered</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Creates a new Company, if no equally product is found beforehand,
        /// otherwise, update the existant Company entity by the new one</returns>
        public async Task<Company> UpdateAsync(Company entity, CancellationToken token = default)
        {
            var result = await _repository.UpdateAsync(entity, token);
            return result;
        }
    }
}
