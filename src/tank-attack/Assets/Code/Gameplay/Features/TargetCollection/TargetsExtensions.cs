namespace Code.Gameplay.Features.TargetCollection
{
    public static class TargetsExtensions
    {
        private static GameContext GameContext => Contexts.sharedInstance.game;

        /*public static GameEntity Producer(this GameEntity effect)
        { 
            return effect.hasProducerId
                ? GameContext.GetEntityWithId(effect.ProducerId)
                : null;
        }*/
        
        public static GameEntity Target(this GameEntity entity)
        {
            return entity.hasTargetId
                ? GameContext.GetEntityWithId(entity.TargetId)
                : null;
        }
    }
}