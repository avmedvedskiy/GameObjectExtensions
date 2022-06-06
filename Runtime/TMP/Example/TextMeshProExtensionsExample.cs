using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TMP.Example
{
    #if TMP
    public class TextMeshProExtensionsExample : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public int value;
        public int newValue;
        public float duration;
        public Ease ease;

        
        [ContextMenu(nameof(ToNewValue))]
        public void ToNewValue()
        {
            text.SetSmoothValue(value, newValue, duration).SetEase(ease);
        }
        
        public string convertFormant = "convert Format {0}";
        [ContextMenu(nameof(ToNewValueConvert))]
        public void ToNewValueConvert()
        {
            text.SetSmoothValue(value, newValue, duration, Convert).SetEase(ease);
        }

        private string Convert(int value)
        {
            Debug.Log(Time.time);
            return string.Format(convertFormant,value);
        }
        
        
        public string format = "format {0}";
        [ContextMenu(nameof(ToNewValueFormat))]
        public void ToNewValueFormat()
        {
            text.SetSmoothValue(value, newValue, duration, format).SetEase(ease);
        }

    }
    #endif
}