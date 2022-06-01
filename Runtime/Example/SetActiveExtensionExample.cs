using DG.Tweening;
using UnityEngine;

namespace ExtensionsExamples
{
    public sealed class SetActiveExtensionExample : MonoBehaviour
    {
        public Ease customEase;
        [ContextMenu(nameof(Activate))]
        public void Activate()
        {
            gameObject.SetActiveTween(true);
        }
    
        [ContextMenu(nameof(ActivateWithCustomDuration))]
        public void ActivateWithCustomDuration()
        {
            gameObject.SetActiveTween(true,1f).SetEase(customEase);
        }

        [ContextMenu(nameof(Disable))]
        public void Disable()
        {
            gameObject.SetActiveTween(false);
            //await gameObject.SetActiveTween(false).AsyncWaitForCompletion();
        }
        
        
        [ContextMenu(nameof(ActivateCanvasGroup))]
        public void ActivateCanvasGroup()
        {
            if(gameObject.TryGetComponent<CanvasGroup>(out var cg))
                cg.SetActiveTween(true,5f);
        }

        [ContextMenu(nameof(DisableCanvasGroup))]
        public void DisableCanvasGroup()
        {
            if(gameObject.TryGetComponent<CanvasGroup>(out var cg))
                cg.SetActiveTween(false);
        }
        
    }
}
