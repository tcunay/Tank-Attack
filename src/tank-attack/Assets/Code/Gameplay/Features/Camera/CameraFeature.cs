using Code.Gameplay.Features.Camera.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Camera
{
    public sealed class CameraFeature : Feature
    {
        public CameraFeature(ISystemFactory systems)
        {
            Add(systems.Create<CameraFollowHeroSystem>());
        }
    }
}