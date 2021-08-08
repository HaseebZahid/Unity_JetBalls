using UnityEngine;

public class TweenRectTransformPosition : Tween
{

    [Header("Settings_TweenPosition")]

    [Tooltip("Position of this object at 0")]
    [SerializeField] public Vector2 position0;

    [Tooltip("Position of this object at 1")]
    [SerializeField] public Vector2 position1;

    RectTransform rectTransform;

    protected override void AssignTweenValueOnLerp(float lerpVariable)
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        rectTransform.anchoredPosition = Vector2.LerpUnclamped(position0, position1, lerpVariable);
    }
}
