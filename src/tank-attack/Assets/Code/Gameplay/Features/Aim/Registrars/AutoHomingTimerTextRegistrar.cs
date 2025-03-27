using Code.Infrastructure.View.Registrars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Aim.Registrars
{
    public class AutoHomingTimerTextRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private TMP_Text _text;
            
        public override void RegisterComponents()
        {
            Entity.AddAutoHomingTimerText(_text);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasAutoHomingTimerText)
                Entity.RemoveAutoHomingTimerText();
        }
    }
}