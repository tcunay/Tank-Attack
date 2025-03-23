using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _heroPoint;
        [SerializeField] public EnemySetup[] _enemiesSetups;

        private ILevelDataProvider _levelDataProvider;
        
        public EnemySetup[] EnemiesSetups => _enemiesSetups;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(_heroPoint);
            _levelDataProvider.SetEnemySetups(_enemiesSetups);
        }
    }
}