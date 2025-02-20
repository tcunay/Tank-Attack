﻿using CodeBase.Gameplay.StaticData;
using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.Infrastructure.States.StateMachine;

namespace CodeBase.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public override async void Enter()
    {
      await _staticDataService.LoadAll();
      
      _stateMachine.Enter<LoadingBattleState>();
    }
  }
}