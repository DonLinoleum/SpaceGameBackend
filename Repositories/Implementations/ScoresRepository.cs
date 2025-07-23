using Microsoft.EntityFrameworkCore;
using SpaceGameBackend.Data;
using SpaceGameBackend.Models;
using SpaceGameBackend.Repositories.Interfaces;

namespace SpaceGameBackend.Repositories.Implementations
{
    public class ScoresRepository : IScoresRepository<ScoreModel>
    {
        private readonly ApplicationDBContext _db;
        public ScoresRepository(ApplicationDBContext db) 
        {
            _db = db;
        }

        public async Task<List<ScoreModel>> GetAllAsync()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<List<ScoreModel>> GetTopTenScores()
        {
            return await _db.Scores.OrderByDescending(score => score.Scores).Take(10).ToListAsync();
        }

        public async Task<ScoreModel?> GetById (int Id)
        {
            return await _db.Scores.FirstOrDefaultAsync(score => score.Id == Id);
        }

        public async Task<ScoreModel> AddAsync(ScoreModel data)
        {
            await _db.Scores.AddAsync(data);
            await _db.SaveChangesAsync();
            return data;
        }
    }
}
