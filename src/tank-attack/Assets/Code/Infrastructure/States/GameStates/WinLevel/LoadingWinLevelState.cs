using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.WinLevel
{
    public class LoadingWinLevelState : SimpleState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingWinLevelState(
            ISceneLoader sceneLoader,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }
        
        public override void Enter()
        {
            _loadingCurtain.Show();
            
            _sceneLoader.LoadSceneAsset(AssetPath.WinLevelScene);
        }
    }
}