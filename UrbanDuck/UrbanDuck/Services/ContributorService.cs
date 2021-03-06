using System.Linq.Expressions;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Repositories;

namespace UrbanDuck.Services
{
    public class ContributorService : IContributorService
    {
        private readonly IContributorRepository _contributorRepository;
        private readonly IListingService _listingService;
        public ContributorService(IContributorRepository contributorRepository, IListingService listingService)
        {
            _contributorRepository = contributorRepository;
            _listingService = listingService;
        }

        public async Task<Contributor> GetById(int id)
        {
            return await _contributorRepository.GetContributorWithListings(id);
        }

        public async Task<Contributor> GetByUserId(int id)
        {
            return (await GetByConditions(c => c.UserId == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<Contributor>> GetByConditions(Expression<Func<Contributor, bool>> expresion)
        {
            return await _contributorRepository.FindByConditions(expresion);
        }

        public async Task<IEnumerable<Contributor>> GetAll()
        {
            return await _contributorRepository.FindAll();
        }

        public async Task<Contributor> Create(Contributor model)
        {
            return await _contributorRepository.Create(model);
        }
        public async Task Delete(int id)
        {
            var model = await GetById(id);
            var listingsToDelete = await _listingService.GetByConditions(l => l.ContributorId == id);
            if (listingsToDelete.Count() > 0) foreach (Listing listing in listingsToDelete) await _listingService.Delete(listing.Id);
            if (model != null) await _contributorRepository.Delete(model);
        }

        public async Task Edit(Contributor model)
        {
            await _contributorRepository.Edit(model);
        }
    }
}
