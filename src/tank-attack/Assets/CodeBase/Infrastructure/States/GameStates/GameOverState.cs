/*using Code.Infrastructure.States.StateInfrastructure;

namespace CodeBase.Infrastructure.States.GameStates
{
    public class GameOverState : SimpleState
    {
        private readonly IWindowService _windowService;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public GameOverState(IWindowService windowService, IAbilityUpgradeService abilityUpgradeService)
        {
            _windowService = windowService;
            _abilityUpgradeService = abilityUpgradeService;
        }
        
        public override void Enter()
        {
            _abilityUpgradeService.Cleanup();
            _windowService.Open(WindowId.GameOverWindow);
        }
    }
}*/