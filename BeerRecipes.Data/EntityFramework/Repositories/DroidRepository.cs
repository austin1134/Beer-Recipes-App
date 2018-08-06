using StarWars.Core.Models;
using Microsoft.Extensions.Logging;
using StarWars.Core.Data;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class DroidRepository : BaseRepository<Droid, int>, IDroidRepository
    {
        public DroidRepository() { }

        public DroidRepository(BeerRecipesContext db, ILogger<DroidRepository> logger)
            : base(db, logger)
        {
        }
    }
}
