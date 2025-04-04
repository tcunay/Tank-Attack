using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Compass.View
{
    public class CompassView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private RectTransform _markParent;

        public RectTransform MarkParent => _markParent;
    }
}