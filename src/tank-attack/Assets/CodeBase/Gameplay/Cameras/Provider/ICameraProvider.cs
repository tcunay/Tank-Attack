using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Provider
{
  public interface ICameraProvider
  {
    Camera MainCamera { get; }
    float WorldScreenHeight { get; }
    float WorldScreenWidth { get; }
    void SetMainCamera(Camera camera);
  }
}