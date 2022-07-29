using DG.Tweening;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class TweenButton : Button
    {
        [SerializeField] private float _downScale = 0.9f;
        [SerializeField] private float _duration = 0.1f;
        [SerializeField] private Ease _downEase = Ease.OutBack;
        [SerializeField] private Ease _upEase = Ease.OutBack;

        private Tweener _downTween;
        private Tweener _upTween;

        private Vector3? _initialScale = null;

        private Vector3 InitialScale
        {
            get
            {
                _initialScale ??= transform.localScale;
                return (Vector3)_initialScale;
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (_downTween == null)
            {
                _downTween = transform
                    .DOScale(InitialScale * _downScale, _duration).SetEase(_downEase)
                    .SetAutoKill(false);
            }
            else
            {
                _downTween.Restart();
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (_upTween == null)
            {
                _upTween = transform.DOScale(InitialScale, _duration)
                    .SetEase(_upEase)
                    .SetAutoKill(false);
            }
            else
            {
                _upTween.Restart();
            }
        }
#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            transition = Transition.None;
        }
#endif

    }
}