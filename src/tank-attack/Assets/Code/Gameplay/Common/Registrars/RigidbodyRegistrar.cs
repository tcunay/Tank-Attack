using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class RigidbodyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Rigidbody _rigidbody;
        public override void RegisterComponents()
        {
            Entity.AddRigidbody(_rigidbody);
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasRigidbody)
                Entity.RemoveRigidbody();
        }
    }
}