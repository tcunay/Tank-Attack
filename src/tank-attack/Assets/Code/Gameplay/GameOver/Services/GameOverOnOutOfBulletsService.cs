using System;
using Code.Gameplay.Armaments.Models;
using Code.Gameplay.Armaments.Services;
using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.StateMachine;
using Zenject;

namespace Code.Gameplay.GameOver.Services
{
    public class GameOverOnOutOfBulletsService : IGameOverOnOutOfBulletsService, IInitializable, IDisposable
    {
        private readonly IWeaponMagazine _bulletMagazine;
        private readonly IGameStateMachine _stateMachine;
        private readonly IBulletsLifeCycleService _bulletsLifeCycleService;

        public GameOverOnOutOfBulletsService(IWeaponMagazine bulletMagazine, IGameStateMachine stateMachine, IBulletsLifeCycleService bulletsLifeCycleService)
        {
            _bulletMagazine = bulletMagazine;
            _stateMachine = stateMachine;
            _bulletsLifeCycleService = bulletsLifeCycleService;
        }

        public void Initialize()
        {
            _bulletMagazine.Changed += OnBulletCountChanged;
            _bulletsLifeCycleService.CountChanged += OnBulletCountChanged;
        }

        public void Dispose()
        {
            _bulletMagazine.Changed -= OnBulletCountChanged;
            _bulletsLifeCycleService.CountChanged -= OnBulletCountChanged;
        }

        private void OnBulletCountChanged()
        {
            if (_bulletMagazine.Count == 0 && _bulletsLifeCycleService.LiveBulletsCount == 0)
            {
                _stateMachine.Enter<LoadingGameOverState>();
            }
        }
    }
}