using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.Systems
{
    public class SetCameraZoomByInputSystem : IExecuteSystem
    {
        private const float MinFOV = 15f;
        private const float MaxFOV = 80f;
        
        private readonly IGroup<GameEntity> _cameras;
        private readonly IGroup<InputEntity> _inputs;

        public SetCameraZoomByInputSystem(GameContext game, InputContext inputContext)
        {
            _cameras = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Camera, GameMatcher.CameraUnity));

            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(InputMatcher.CameraZoomInput));
        }

        public void Execute()
        {
            foreach (GameEntity camera in _cameras)
            foreach (InputEntity input in _inputs)
            {
                camera.CameraUnity.fieldOfView = Mathf.Lerp(MaxFOV, MinFOV, input.CameraZoomInput);
            }
        }
    }
}