using Code.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Aim.Registrars
{
    public class IconRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Image _icon;
            
        public override void RegisterComponents()
        {
            Entity.AddIcon(_icon);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasIcon)
                Entity.RemoveIcon();
        }
    }
}