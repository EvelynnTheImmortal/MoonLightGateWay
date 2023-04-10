using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    
    private Coroutine lastcoroutine;
    private Coroutine newCoroutine;
    

    public GameObject canvas;
    public GameObject titleFadeCanvas;

    [SerializeField] private Image _image;
    [SerializeField] private float _fadeDuration = 2f;
    void Start()
    {
        Color tempColor = _image.color;
        tempColor.a = 0f;
        _image.color = tempColor;
        lastcoroutine = StartCoroutine(FadeImage(0f, 1f));
    }
    

    

    private IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        Color tempColor = _image.color;
        tempColor.a = startAlpha;
        _image.color = tempColor;

        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / _fadeDuration);
            tempColor.a = alpha;
            _image.color = tempColor;
            yield return null;
        }

        tempColor.a = endAlpha;
        _image.color = tempColor;

        if (_image.color.a == 1f)
        {
            Debug.Log("Transition1");
            newCoroutine = StartCoroutine(FadeImage(1f, 0f));
            StopCoroutine(lastcoroutine);
        }
        else if (_image.color.a == 0f)
        {
            Debug.Log("Transition2");
            canvas.SetActive(true);
            titleFadeCanvas.SetActive(false);
            StopCoroutine(newCoroutine);
        }
    }


}
