using System;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.Loading
{
  public interface ISceneLoader
  {
    void LoadScene(string name, Action onLoaded = null);
    void LoadScene(AssetReference scene, Action onLoaded = null);
  }
}