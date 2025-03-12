using Code.Gameplay.Input;
using Code.Gameplay.Input.Services;
using Code.Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Hero.Components
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