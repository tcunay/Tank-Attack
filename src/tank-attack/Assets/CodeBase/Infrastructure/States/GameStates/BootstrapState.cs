using CodeBase.Gameplay.StaticData;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;

namespace CodeBase.Infrastructure.States.GameStates
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