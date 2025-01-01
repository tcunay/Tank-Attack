using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";
        
        private const string FireButtonKey = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButton() => SimpleInput.GetButtonUp(FireButtonKey);

        protected static Vector2 SimpleInputAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}