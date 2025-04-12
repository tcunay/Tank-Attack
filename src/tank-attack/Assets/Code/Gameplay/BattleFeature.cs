using Code.Common.Systems.Destruct;
using Code.Gameplay.Features.Aim;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.Camera;
using Code.Gameplay.Features.Compass;
using Code.Gameplay.Features.EndLevel;
using Code.Gameplay.Features.EndLevel.Systems;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());

            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<InitHealthFeature>());
            
            Add(systems.Create<HeroFeature>());
            
            Add(systems.Create<CameraFeature>());
            
            Add(systems.Create<EnemyFeature>());
            
            Add(systems.Create<CompassFeature>());
            
            Add(systems.Create<AimFeature>());
            Add(systems.Create<ArmamentsFeature>());
            
            Add(systems.Create<MovementFeature>());
            
            Add(systems.Create<CollectTargetsFeature>());
            
            Add(systems.Create<DamageFeature>());
            
            Add(systems.Create<DeathFeature>());
            
            Add(systems.Create<EndLevelFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}