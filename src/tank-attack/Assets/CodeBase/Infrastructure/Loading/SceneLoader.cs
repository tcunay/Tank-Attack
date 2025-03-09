using System;
using System.Collections;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Common;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Loading
{
  public class SceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IAssetProvider _assetProvider;

    public SceneLoader(ICoroutineRunner coroutineRunner, IAssetProvider assetProvider)
    {
      _coroutineRunner = coroutineRunner;
      _assetProvider = assetProvider;
    }

    public void LoadScene(string name, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(Load(name, onLoaded));

    public async void LoadSceneAsset(AssetReference nextScene, Action onLoaded = null)
    {
      await _assetProvider.LoadScene(nextScene);
      onLoaded?.Invoke();
    }
    
    public async void LoadSceneAsset(string nextScene, Action onLoaded = null)
    {
      await _assetProvider.LoadScene(nextScene);
      onLoaded?.Invoke();
    }

    private IEnumerator Load(string nextScene, Action onLoaded)
    {
      if (SceneManager.GetActiveScene().name == nextScene)
      {
        onLoaded?.Invoke();
        yield break;
      }

      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

      while (!waitNextScene.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}