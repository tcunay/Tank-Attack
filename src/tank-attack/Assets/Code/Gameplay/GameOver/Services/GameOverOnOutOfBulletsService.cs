using System;
using Code.Gameplay.Features.Armaments.Models;
using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.StateMachine;
using Zenject;

namespace Code.Gameplay.GameOver.Services
{
    public class GameOverOnOutOfBulletsService : IGameOverOnOutOfBulletsService, IInitializable, IDisposable
    {
        private readonly IWeaponMagazine _bulletMagazine;
        private readonly IGameStateMachine _stateMachine;

        public GameOverOnOutOfBulletsService(IWeaponMagazine bulletMagazine, IGameStateMachine stateMachine)
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
            /*if (_bulletMagazine.Count == 0 && _bulletsLifeCycleService.LiveBulletsCount == 0)
            {
                _stateMachine.Enter<LoadingGameOverState>();
            }*/
        }
    }
}