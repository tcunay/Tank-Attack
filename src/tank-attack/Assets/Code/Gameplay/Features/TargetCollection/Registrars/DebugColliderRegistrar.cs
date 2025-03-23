using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Registrars
{
    public class DebugColliderRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Collider collider = GetComponent<Collider>();

            if (collider != null)
            {
                Entity.AddDebugCollider(collider);
            }
        }

        public override void UnRegisterComponents()
        {
            if (Entity.hasDebugCollider)
                Entity.RemoveDebugCollider();
        }
    }
}