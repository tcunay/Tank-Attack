using System;
using CodeBase.Gameplay.Armaments.Models;
using CodeBase.Gameplay.Armaments.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Armaments.UI
{
    public class BulletCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        
        private IBulletMagazine _bulletMagazine;

        [Inject]
        private void Construct(IBulletMagazine bulletMagazine)
        {
            _bulletMagazine = bulletMagazine;
        }

        private void Awake()
        {
            _bulletMagazine.Changed += UpdateText;
            UpdateText();
        }

        private void OnDestroy()
        {
            _bulletMagazine.Changed -= UpdateText;
        }

        private void UpdateText()
        {
            int count = Math.Max(0, _bulletMagazine.Count);
            
            _counterText.text = count.ToString();
        }
    }
}