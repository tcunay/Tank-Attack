using UnityEngine;

namespace Code.Gameplay.Hero.Factory
{
    public interface IHeroFactory
    {
        GameObject CreateHero(Vector3 at);
    }
}