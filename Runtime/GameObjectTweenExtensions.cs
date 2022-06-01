using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public static class GameObjectTweenExtensions
{
    private const float DEFAULT_TWEEN_DURATION = 0.33f;
    private const Ease DEFAULT_TWEEN_ACTIVE_EASE = Ease.OutBack;
    private const Ease DEFAULT_TWEEN_DISABLE_EASE = Ease.InBack;
    /// <summary>
    /// Animated activation of gameobject with scale from one to zero
    /// </summary>
    public static Tween SetActiveTween(this GameObject gameObject, bool value, float duration = DEFAULT_TWEEN_DURATION)
    {
        if (gameObject.activeSelf == value)
            return null;
        
        if(value)
            gameObject.SetActive(true);
        
        var endValue = value ? Vector3.one  : Vector3.zero;
        Ease ease = value ? DEFAULT_TWEEN_ACTIVE_EASE : DEFAULT_TWEEN_DISABLE_EASE;
        Tween t = gameObject.transform.DOScale(endValue, duration).SetEase(ease);
        if (!value)
            t.OnComplete(() => gameObject.SetActive(false));

        return t;
    }
    
    /// <summary>
    /// Animated activation of CanvasGroup with Fade from one to zero
    /// </summary>
    public static Tween SetActiveTween(this CanvasGroup canvasGroup, bool value, float duration = DEFAULT_TWEEN_DURATION)
    {
        var endValue = value ? 1f  : 0f;
        Ease ease = value ? DEFAULT_TWEEN_ACTIVE_EASE : DEFAULT_TWEEN_DISABLE_EASE;
        Tween t = canvasGroup.DOFade(endValue, duration).SetEase(ease);
        return t;
    }
        
    /// <summary>
    /// Animated activation of CanvasGroup with Fade from one to zero
    /// </summary>
    public static Tween SetActiveTween(this Image image, bool value, float duration = DEFAULT_TWEEN_DURATION)
    {
        var endValue = value ? 1f  : 0f;
        Ease ease = value ? DEFAULT_TWEEN_ACTIVE_EASE : DEFAULT_TWEEN_DISABLE_EASE;
        Tween t = image.DOFade(endValue, duration).SetEase(ease);
        return t;
    }
    
}
