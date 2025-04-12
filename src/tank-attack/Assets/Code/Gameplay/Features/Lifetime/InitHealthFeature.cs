using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
    public class InitHealthFeature: Feature
    {
        public InitHealthFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitCurrentHpSystem>());
            
            Add(systems.Create<InitPrevHpSystem>());
        }
    }
}