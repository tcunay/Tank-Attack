using System;
using CodeBase.Gameplay.Armaments.Models;
using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.GameOver.Systems;
using CodeBase.Infrastructure.States.GameStates.GameOver;
using CodeBase.Infrastructure.States.StateMachine;
using Zenject;

namespace CodeBase.Gameplay.GameOver.Services
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