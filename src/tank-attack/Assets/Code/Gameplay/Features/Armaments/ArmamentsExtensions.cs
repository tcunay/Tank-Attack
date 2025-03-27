namespace Code.Gameplay.Features.Armaments
{
    public static class ArmamentsExtensions
    {
        private static GameContext GameContext => Contexts.sharedInstance.game;
        
        public static GameEntity Target(this GameEntity effect)
        { 
            return effect.hasDetectedTargetId
                ? GameContext.GetEntityWithId(effect.DetectedTargetId)
                : null;
        }
    }
}