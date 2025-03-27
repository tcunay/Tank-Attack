using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Aim
{
    [Game] public class AutoHoming : IComponent { }
    [Game] public class Aim : IComponent { }
    [Game] public class DetectionTime : IComponent { public float Value; }
    [Game] public class DetectingTargetId : IComponent { public int Value; }
    [Game] public class DetectedTargetId : IComponent { public int Value; }
    [Game] public class MaxDetectingTime : IComponent { public float Value; }
    [Game] public class Icon : IComponent { public Image Value; }
    [Game] public class AutoHomingTimerText : IComponent { public TMP_Text Value; }
}