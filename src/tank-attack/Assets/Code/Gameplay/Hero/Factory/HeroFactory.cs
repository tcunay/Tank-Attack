using Code.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticData;

        public HeroFactory(IInstantiator instantiator, IStaticDataService staticData)
        {
            _instantiator = instantiator;
            _staticData = staticData;
        }
        
        public GameObject CreateHero(Vector3 at)
        {
            return _instantiator
                .InstantiatePrefab(_staticData.HeroPrefab(), at, Quaternion.identity, null);
        }
    }
}