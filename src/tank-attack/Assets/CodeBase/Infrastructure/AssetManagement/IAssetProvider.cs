using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        UniTask<TObject> LoadAsset<TObject>(string path);
        UniTask<GameObject> LoadAsset(string path);
        UniTask<IList<TObject>> LoadAssets<TObject>(string path);
    }
}