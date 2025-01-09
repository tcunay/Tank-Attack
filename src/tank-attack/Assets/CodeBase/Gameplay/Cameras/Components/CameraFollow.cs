using System;
using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Components
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _hero;

        public void Setup(Transform hero)
        {
            _hero = hero;
            transform.parent = hero;
            transform.position = hero.position;
            transform.rotation = hero.rotation;
        }
        
    }
}