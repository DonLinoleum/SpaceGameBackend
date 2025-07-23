using SpaceGameBackend.Models;

namespace SpaceGameBackend.Repositories.Interfaces
{
    public interface IScoresRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetTopTenScores();
        Task<T?> GetById(int Id);
        Task<T> AddAsync(T data);
    }
}
