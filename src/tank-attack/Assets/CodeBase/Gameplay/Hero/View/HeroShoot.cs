using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Hero.View
{
    public class HeroShoot : MonoBehaviour
    {
        private IInputService _inputService;
        private IShootService _shootService;

        [Inject]
        private void Construct(IInputService inputService, IShootService shootService)
        {
            _shootService = shootService;
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsAttackButton())
            {
                _shootService.Shoot(transform.position ,transform.forward);
            }
        }
    }
    
}