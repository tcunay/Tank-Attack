using Code.Gameplay.StaticData;
using Code.Infrastructure.States.GameStates.Home;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;
    private LoadingCurtain _loadingCurtain;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService, LoadingCurtain loadingCurtain)
    {
      _loadingCurtain = loadingCurtain;
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public override async void Enter()
    {
      _loadingCurtain.Show();
      
      await _staticDataService.LoadAll();
      
      _stateMachine.Enter<LoadingHomeScreenState>();
    }
  }
}