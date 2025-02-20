using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public async UniTask<GameObject> LoadAsset(string path)
        {
            return await LoadAsset<GameObject>(path);
        }
        
        public async UniTask<TObject> LoadAsset<TObject>(string path)
        {
            return await Addressables.LoadAssetAsync<TObject>(path).ToUniTask();
        }

        public async UniTask<IList<TObject>> LoadAssets<TObject>(string path)
        {
            return await Addressables.LoadAssetsAsync<TObject>(path).ToUniTask();
        }
    }
}