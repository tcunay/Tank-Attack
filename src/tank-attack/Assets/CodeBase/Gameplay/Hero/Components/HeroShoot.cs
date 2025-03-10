using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Hero.Components
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
            
            Debug.DrawRay(transform.position, transform.forward, Color.blue);

        }
    }
    
}