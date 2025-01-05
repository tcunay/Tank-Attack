using UnityEngine;

namespace CodeBase.Gameplay.Hero.Factory
{
    public interface IHeroFactory
    {
        GameObject CreateHero(Vector3 at);
    }
}