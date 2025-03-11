using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.GameOver
{
    public class LoadingGameOverState : SimpleState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadingGameOverState(
            ISceneLoader sceneLoader,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }
        
        public override void Enter()
        {
            _loadingCurtain.Show();
            
            _sceneLoader.LoadSceneAsset(AssetPath.GameOverScene);
        }
    }
}