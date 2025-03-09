using System;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Loading
{
  public interface ISceneLoader
  {
    void LoadScene(string name, Action onLoaded = null);
    void LoadSceneAsset(AssetReference scene, Action onLoaded = null);
    void LoadSceneAsset(string nextScene, Action onLoaded = null);
  }
}