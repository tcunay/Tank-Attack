using Code.Gameplay.Features.EnemyHpBar.View;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.EnemyHpBar.Registrars
{
    public class EnemyHpBarRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnemyHpBarView _view;
        
        public override void RegisterComponents()
        {
            Entity
                .AddEnemyHpBarView(_view);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasEnemyHpBarView)
            {
                Entity.RemoveEnemyHpBarView();
            }
        }
    }
}