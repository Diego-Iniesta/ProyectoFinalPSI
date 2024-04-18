using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{
    public Image newsImage;
    public Sprite[] newsSprites;
    public float newsDuration = 4f;
    public float transitionDuration = 0.5f;
    private int currentNewsIndex = 0;
    void Start()
    {
        StartCoroutine(ShowNextNewsItem());
    }

    IEnumerator ShowNextNewsItem()
    {
        while (true)
        {
            LeanTween.alpha(newsImage.rectTransform, 0f, transitionDuration).setEase(LeanTweenType.easeOutQuad);
            yield return new WaitForSeconds(transitionDuration);
            newsImage.sprite = newsSprites[currentNewsIndex];
            LeanTween.alpha(newsImage.rectTransform, 1f, 0f);
            LeanTween.scale(newsImage.rectTransform, Vector3.zero, 0f);
            LeanTween.scale(newsImage.rectTransform, Vector3.one, transitionDuration).setEase(LeanTweenType.easeOutBounce);
            yield return new WaitForSeconds(newsDuration);
            currentNewsIndex = (currentNewsIndex + 1) % newsSprites.Length;
        }
    }
}
