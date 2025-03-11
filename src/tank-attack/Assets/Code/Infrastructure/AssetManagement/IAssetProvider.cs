using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        UniTask<TObject> LoadAsset<TObject>(string path);
        UniTask<GameObject> LoadAsset(string path);
        UniTask<IList<TObject>> LoadAssets<TObject>(string path);
        UniTask LoadScene(AssetReference scene);
        UniTask LoadScene(string scene);
    }
}