using System.Collections;
using UnityEngine;
using NPLH;

[RequireComponent(typeof(CanvasGroup))]
public class UIFadeInOut : Actor, IStarter
{
    [SerializeField]
    private float _timeToFade = 0.5f;
    private bool _isFaded;

    private CanvasGroup _canvasGroup;
    public void StartLocal()
    {
        Initialize();
    }
    public void Initialize() 
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0.0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _isFaded = true;
    }

    private IEnumerator FadeRoutine(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
    {
        float counter = 0.0f;

        while (counter < _timeToFade)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / _timeToFade);

            yield return null;
        }

        _canvasGroup.interactable = !_canvasGroup.interactable;
    }
    public void Fade()
    {
        StopAllCoroutines();

        StartCoroutine(FadeRoutine(_canvasGroup, _canvasGroup.alpha, _isFaded ? 1 : 0));

        _isFaded = !_isFaded;
        _canvasGroup.blocksRaycasts = !_canvasGroup.blocksRaycasts;
    }
}
