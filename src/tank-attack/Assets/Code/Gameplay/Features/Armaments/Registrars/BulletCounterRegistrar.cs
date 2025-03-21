using Code.Infrastructure.View.Registrars;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Registrars
{
    public class BulletCounterRegistrar: EntityComponentRegistrar
    {
        [SerializeField] private TMP_Text _bulletCounter;
        
        public override void RegisterComponents()
        {
            Entity.AddBulletCounter(_bulletCounter);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasBulletCounter)
                Entity.RemoveBulletCounter();
        }
    }
}