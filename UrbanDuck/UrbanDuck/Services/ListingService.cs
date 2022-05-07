using System.Linq.Expressions;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace UrbanDuck.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public ListingService(IListingRepository listingRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _listingRepository = listingRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<Listing> GetById(int id)
        {
            return await _listingRepository.GetListingWithData(id);
        }

        public async Task<IEnumerable<Listing>> GetByConditions(Expression<Func<Listing, bool>> expresion)
        {
            return await _listingRepository.FindByConditions(expresion);
        }

        public async Task<IEnumerable<Listing>> GetAll()
        {
            return await _listingRepository.FindAll();
        }

        public async Task<Listing> Create(Listing model)
        {
            return await _listingRepository.Create(model);
        }
        public async Task Delete(int id)
        {
            var model = await GetById(id);
            if (model != null) await _listingRepository.Delete(model);
        }

        public async Task Edit(Listing model)
        {
            await _listingRepository.Edit(model);
        }

        public async Task AddPhoto(PhotoUploadModel model)
        {
            var listing = await GetById(model.listingId);
            listing.photoPath = ProcessUploadedFile(model);
            await Edit(listing);
        }

        private string ProcessUploadedFile(PhotoUploadModel model)
        {
            string uniqueFileName = null;
            if (model.photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //code below prevents the app from crashing when replacing a photo used by more than 1 employee
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.photo.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
    }
}
