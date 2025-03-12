using Code.Gameplay.Input.Services;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<InputEntity> _inputs;

        public EmitInputSystem(InputContext inputContext, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = inputContext.GetGroup(InputMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.ReplaceCameraZoomInput(_inputService.CameraZoomAxis);

                input.isAttackInput = _inputService.IsAttackButton();
                
                if (_inputService.HasAxisInput())
                {
                    input.ReplaceAxisInput(_inputService.Axis);
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                } 
            }
        }
    }
}