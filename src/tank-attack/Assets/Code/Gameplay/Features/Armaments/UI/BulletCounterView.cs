using System;
using Code.Gameplay.Features.Armaments.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Armaments.UI
{
    public class BulletCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        
        private IWeaponMagazine _bulletMagazine;

        //[Inject]
        private void Construct(IWeaponMagazine bulletMagazine)
        {
            _bulletMagazine = bulletMagazine;
        }

        private void Awake()
        {
            return;
            _bulletMagazine.Changed += UpdateText;
            UpdateText();
        }

        private void OnDestroy()
        {
            return;
            _bulletMagazine.Changed -= UpdateText;
        }

        private void UpdateText()
        {
            int count = Math.Max(0, _bulletMagazine.Count);
            
            _counterText.text = count.ToString();
        }
    }
}