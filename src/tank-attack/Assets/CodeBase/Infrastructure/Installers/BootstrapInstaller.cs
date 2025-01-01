using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            
        }
        
        private void BindStateMachine()
        {
            //Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
    }
}