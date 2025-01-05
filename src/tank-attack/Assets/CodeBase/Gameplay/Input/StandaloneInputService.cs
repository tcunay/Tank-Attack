﻿using UnityEngine;

namespace CodeBase.Gameplay.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                {
                    axis = UnityAxis();
                }
                
                return axis;
            }
        }

        public override bool IsAttackButton()
        {
            return base.IsAttackButton() || UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }

        private static Vector2 UnityAxis() => 
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}