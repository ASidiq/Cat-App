using CatApp.Models;

namespace CatApp.Interfaces
{
    public interface ICatService
    {
        public Task<List<Cat>> GetCatUrls();
    }
}
