using System;
using CodeBase.Gameplay.Armaments.Models;
using CodeBase.Gameplay.GameOver.Systems;
using CodeBase.Infrastructure.States.GameStates.GameOver;
using CodeBase.Infrastructure.States.StateMachine;
using Zenject;

namespace CodeBase.Gameplay.GameOver.Services
{
    public class GameOverOnMagazineEmptyService : IGameOverOnMagazineEmptyService, IInitializable, IDisposable
    {
        private readonly IBulletMagazine _bulletMagazine;
        private readonly IGameStateMachine _stateMachine;

        public GameOverOnMagazineEmptyService(IBulletMagazine bulletMagazine, IGameStateMachine stateMachine)
        {
            _bulletMagazine = bulletMagazine;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _bulletMagazine.Changed += OnBulletCountChanged;
        }

        public void Dispose()
        {
            _bulletMagazine.Changed -= OnBulletCountChanged;
        }

        private void OnBulletCountChanged()
        {
            if (_bulletMagazine.Count == 0)
            {
                _stateMachine.Enter<LoadingGameOverState>();
            }
        }
    }
}