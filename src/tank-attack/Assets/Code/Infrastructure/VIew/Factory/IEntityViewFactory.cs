using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.View.Factory
{
    public interface IEntityViewFactory
    {
        UniTask<EntityBehaviour> CreateViewFormEntity(GameEntity entity);
        EntityBehaviour CreateViewFormEntityFromPrefab(GameEntity entity);
    }
}