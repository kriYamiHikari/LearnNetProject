using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/musics")]
    public class MusicInfoController : ControllerBase
    {
        private readonly ILogger<MusicInfoController> _logger;
        private readonly RoutineDbContext _context;
        

        public MusicInfoController(ILogger<MusicInfoController> logger, RoutineDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<IEnumerable<MusicInfo>>> GetTest(string language)
        {
            IQueryable<MusicInfo> query;
            if (string.IsNullOrWhiteSpace(language))
            {
                query = from item in _context.MusicInfo
                    select item;
            }
            else
            {
                query = from item in _context.MusicInfo
                    where item.Language == language
                    select item;
            }

            var musicInfos = await query.Take(20).ToListAsync();
            return musicInfos;
        }
    }
}