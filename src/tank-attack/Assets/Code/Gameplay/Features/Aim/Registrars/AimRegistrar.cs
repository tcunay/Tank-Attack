using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Aim.Registrars
{
    public class AimRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.isAim = true;
        }

        public override void UnRegisterComponents()
        {
            if (Entity.isAim)
                Entity.isAim = false;
        }
    }
}