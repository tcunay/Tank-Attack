using Code.Gameplay.Features.Compass.View;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Compass.Registrars
{
    public class CompassViewRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private CompassView _view;
        
        public override void RegisterComponents()
        {
            Entity
                .AddCompassView(_view);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasCompassView)
            {
                Entity.RemoveCompassView();
            }
        }
    }
}