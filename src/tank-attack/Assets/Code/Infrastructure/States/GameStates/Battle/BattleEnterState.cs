using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Features.Aim;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleEnterState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly ICameraFactory _cameraFactory;
    private readonly IHeroFactory _heroFactory;
    private readonly IEnemyFactory _enemyFactory;
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;

    public BattleEnterState(
      IGameStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider,
      ICameraFactory cameraFactory,
      IHeroFactory heroFactory, 
      IEnemyFactory enemyFactory)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _cameraFactory = cameraFactory;
      _heroFactory = heroFactory;
      _enemyFactory = enemyFactory;
    }
    
    public override void Enter()
    {
      PlaceHero();
      CreateCamera();
      PlaceEnemies();
      
      _stateMachine.Enter<BattleLoopState>();
    }

    private void PlaceHero()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint.position, _levelDataProvider.StartPoint.rotation);
    }
    
    private void CreateCamera()
    {
      _cameraFactory.CreateCamera();
    }

    private void PlaceEnemies()
    {
      foreach (EnemySetup enemySetup in _levelDataProvider.EnemySetups)
      {
        _enemyFactory.CreateEnemy(enemySetup);
      }
    }
  }
}