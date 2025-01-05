using CodeBase.Gameplay.Time;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.View
{
    public class ProjectileMove : MonoBehaviour
    {
        private ITimeService _time;

        private const float Speed = 3;
        
        public Vector3 MoveDirection { get; set; }

        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }
        
        private void Update()
        {
            transform.Translate(new Vector3(0,0,Speed * _time.DeltaTime));
            Debug.DrawRay(transform.position, MoveDirection, Color.red);
        }

    }
}