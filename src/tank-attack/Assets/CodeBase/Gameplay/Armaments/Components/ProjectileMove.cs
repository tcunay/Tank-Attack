using CodeBase.Gameplay.Time;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.Components
{
    public class ProjectileMove : MonoBehaviour
    {
        private const float Speed = 3;
        
        private ITimeService _time;
        
        [Inject]
        private void Construct(ITimeService time)
        {
            _time = time;
        }
        
        public Vector3 MoveDirection { get; set; }

        private void Start()
        {
            gameObject.transform.forward = MoveDirection;
        }

        private void Update()
        {
            transform.Translate(new Vector3(0,0,Speed * _time.DeltaTime));
            Debug.DrawRay(transform.position, MoveDirection, Color.red);
        }

    }
}