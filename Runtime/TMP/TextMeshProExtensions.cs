#if TMP
using System;
using System.Globalization;
using DG.Tweening;
using TMPro;

public static class TextMeshProUGuiExtension
{
    #region int
    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, int value, int newValue, float duration,
        Func<int, string> convert)
    {
        int pValue = 0;
        textMeshPro.text = convert.Invoke(value);
        return
            DOTween
                .To(() => value, x => value = x, newValue, duration)
                .OnUpdate(() =>
                {
                    if (pValue != value)
                    {
                        textMeshPro.text = convert.Invoke(value);
                        pValue = value;
                    }
                })
                .SetEase(Ease.Linear);
    }
    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, int value, int newValue, float duration)
    {
        return textMeshPro.SetSmoothValue(value, newValue, duration, x => x.ToString());
    }

    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, int value, int newValue, float duration,
        string format)
    {
        return textMeshPro.SetSmoothValue(value, newValue, duration, x => string.Format(format, x));
    }
    #endregion

    #region float
    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, float value, float newValue, float duration,
        Func<float, string> convert)
    {
        float pValue = 0;
        textMeshPro.text = convert.Invoke(value);
        return
            DOTween
                .To(() => value, x => value = x, newValue, duration)
                .OnUpdate(() =>
                {
                    if (pValue != value)
                    {
                        textMeshPro.text = convert.Invoke(value);
                        pValue = value;
                    }
                })
                .SetEase(Ease.Linear);
    }
    
    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, float value, float newValue, float duration)
    {
        return textMeshPro.SetSmoothValue(value, newValue, duration, x => x.ToString(CultureInfo.CurrentCulture));
    }
    
    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, float value, float newValue, float duration, CultureInfo info)
    {
        return textMeshPro.SetSmoothValue(value, newValue, duration, x => x.ToString(info));
    }

    public static Tweener SetSmoothValue(this TextMeshProUGUI textMeshPro, float value, float newValue, float duration,
        string format)
    {
        return textMeshPro.SetSmoothValue(value, newValue, duration, x => string.Format(format, x));
    }
    #endregion
}
#endif