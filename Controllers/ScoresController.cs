using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceGameBackend.Models;
using SpaceGameBackend.Repositories.Interfaces;

namespace SpaceGameBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoresRepository<ScoreModel> _scoresRepository;
        public ScoresController (IScoresRepository<ScoreModel> scoresRepository)
        {
            _scoresRepository = scoresRepository;
        }

        [HttpGet(Name = "GetAllScores")]
        public async Task<ActionResult<List<ScoreModel>>> GetAllScores()
        {
            return Ok(await _scoresRepository.GetAllAsync());
        }

        [HttpGet("topten",Name = "GetTopTen")]
        public async Task<ActionResult<List<ScoreModel>>> GetTopTen()
        {
            return Ok(await _scoresRepository.GetTopTenScores());
        }

        [HttpGet("{id}",Name = "GetScoreById")]
        public async Task<ActionResult<ScoreModel>> GetById(int id)
        {
            return Ok(await _scoresRepository.GetById(id));
        }

        [HttpPost(Name = "AddScore")]
        public async Task<ActionResult<ScoreModel>> AddScore(ScoreModel data)
        {
            return Ok(await _scoresRepository.AddAsync(data));
        }
    }
}
