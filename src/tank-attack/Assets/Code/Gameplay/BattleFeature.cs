using Code.Common.Systems.Destruct;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.Camera;
using Code.Gameplay.Features.EndLevel;
using Code.Gameplay.Features.EndLevel.Systems;
using Code.Gameplay.Features.Hero;
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
            
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());
            
            Add(systems.Create<ArmamentsFeature>());
            
            Add(systems.Create<MovementFeature>());
            
            Add(systems.Create<CollectTargetsFeature>());
            
            Add(systems.Create<DeathFeature>());
            
            Add(systems.Create<EnemyFeature>());
            
            Add(systems.Create<EndLevelFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
            

            /*Add(systems.Create<HeroFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<DeathFeature>());

            Add(systems.Create<LootingFeature>());
            Add(systems.Create<LevelUpFeature>());

            Add(systems.Create<MovementFeature>());

            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<ArmamentFeature>());

            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<EffectApplicationFeature>());

            Add(systems.Create<EnchantFeature>());
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<StatsFeature>());

            Add(systems.Create<GameOverOnHeroDeathSystem>());


            Add(systems.Create<ProcessDestructedFeature>());*/
        }
    }
}