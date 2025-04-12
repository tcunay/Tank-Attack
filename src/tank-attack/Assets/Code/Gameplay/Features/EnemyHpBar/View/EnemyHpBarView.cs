using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.EnemyHpBar.View
{
    public class EnemyHpBarView : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private TMP_Text _hpText;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fillDuration = 0.5f;
        [SerializeField] private float _visibleDuration = 1.5f;

        private Coroutine _currentCoroutine;

        private void Awake()
        {
            Hide();
        }

        public void AnimateTakeDamage(float maxHp, float currentHp, float prevHp)
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            _currentCoroutine = StartCoroutine(TakeDamageAnim(maxHp, currentHp, prevHp));
        }

        private IEnumerator TakeDamageAnim(float maxHp, float currentHp, float prevHp)
        {
            Show();

            float startFill = prevHp / maxHp;
            float targetFill = currentHp / maxHp;
            float elapsed = 0f;

            SetFillAmount(startFill);
            SetHpText(currentHp, maxHp);

            while (elapsed < _fillDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / _fillDuration;
                float currentFill = Mathf.Lerp(startFill, targetFill, t);
                SetFillAmount(currentFill);
                yield return null;
            }

            SetFillAmount(targetFill);
            SetHpText(currentHp, maxHp);

            yield return new WaitForSeconds(_visibleDuration);
            Hide();
        }

        private void SetHpText(float currentHp, float maxHp)
        {
            _hpText.text = $"{Mathf.CeilToInt(currentHp)} / {Mathf.CeilToInt(maxHp)}";
        }

        private void SetFillAmount(float hpPercent)
        {
            _fillImage.fillAmount = Mathf.Clamp01(hpPercent);
        }

        private void Show()
        {
            _canvasGroup.alpha = 1f;
        }

        private void Hide()
        {
            _canvasGroup.alpha = 0f;
        }
    }
}