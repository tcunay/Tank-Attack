using Code.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly Vector3 _farAway = new(-999, -999, 0);

        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public async UniTask<EntityBehaviour> CreateViewFormEntity(GameEntity entity)
        {
            Transform parent = entity.hasInstantiateParent ? entity.InstantiateParent : null;
            
            GameObject viewPrefab = await _assetProvider.LoadAsset(entity.ViewPath);

            EntityBehaviour view = CreateView(parent, viewPrefab.GetComponent<EntityBehaviour>());
            
            view.SetEntity(entity);

            return view;
        }

        public EntityBehaviour CreateViewFormEntityFromPrefab(GameEntity entity)
        {
            Transform parent = entity.hasInstantiateParent ? entity.InstantiateParent : null;

            EntityBehaviour viewPrefab = entity.ViewPrefab;

            EntityBehaviour view = CreateView(parent, viewPrefab);

            view.SetEntity(entity);

            return view;
        }
        
        private EntityBehaviour CreateView(Transform parent, EntityBehaviour viewPrefab)
        {
            return parent 
                ? CreateWithParent(parent, viewPrefab) 
                : CreateNoParent(viewPrefab);
        }

        private EntityBehaviour CreateNoParent(EntityBehaviour viewPrefab)
        {
            return _instantiator
                .InstantiatePrefabForComponent<EntityBehaviour>(
                    viewPrefab,
                    position: _farAway,
                    rotation: Quaternion.identity, null);
        }

        private EntityBehaviour CreateWithParent(Transform parent, EntityBehaviour viewPrefab)
        {
            return _instantiator
                .InstantiatePrefabForComponent<EntityBehaviour>(
                    viewPrefab, parent);
        }
    }
}