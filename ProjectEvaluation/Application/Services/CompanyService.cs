using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> CreateAsync(Company entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.CreateAsync(entity, cancellationToken);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteAsync(id, cancellationToken);
            return result;
        }

        public async Task<IEnumerable<Company>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result;
        }

        public async Task<Company> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            return result;
        }

        public async Task<Company> UpdateAsync(Company entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateAsync(entity, cancellationToken);
            return result;
        }
    }
}
