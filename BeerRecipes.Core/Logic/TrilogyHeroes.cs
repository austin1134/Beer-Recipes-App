﻿using System.Threading.Tasks;

namespace StarWars.Core.Logic
{
    public class TrilogyHeroes : ITrilogyHeroes
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IDroidRepository _droidRepository;

        public TrilogyHeroes(IEpisodeRepository episodeRepository, IDroidRepository droidRepository)
        {
            _episodeRepository = episodeRepository;
            _droidRepository = droidRepository;
        }

        public async Task<BeerRecipe> GetHero(int? episodeId)
        {
            const int r2d2Id = 2001;

            if (episodeId.HasValue)
            {
                var episode = await _episodeRepository.Get(episodeId.Value, include: "Hero");
                return episode.Hero;
            }

            var r2d2 = await _droidRepository.Get(r2d2Id);

            return r2d2;
        }
    }
}
