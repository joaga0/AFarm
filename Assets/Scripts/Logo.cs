using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public GameObject logoImage;  // 로고 이미지 GameObject
    public CanvasGroup panel;
    public AudioSource logoAudio;      // 로고 효과음
    public float shrinkDuration = 1f; // 줄어드는 데 걸리는 시간
    public float audioFadeDuration = 1f; // 효과음 페이드아웃 시간

    void Start()
    {
        // 코루틴 호출
        StartCoroutine(LogoSequence());
    }

    IEnumerator LogoSequence()
    {
        // 로고 축소와 효과음 페이드아웃을 병렬로 실행
        yield return StartCoroutine(ShrinkLogoAndFadeOutAudio());

        // 씬 전환 후 페이드인 실행
        SceneManager.LoadScene("Start");
    }

    IEnumerator ShrinkLogoAndFadeOutAudio()
    {
        Vector3 initialScale = logoImage.transform.localScale;
        float initialAlpha = panel.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            float t = elapsedTime / shrinkDuration;
            logoImage.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
            panel.alpha = Mathf.Lerp(initialAlpha, 1f, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        logoImage.transform.localScale = Vector3.zero;
        panel.alpha = 1f;

        yield return StartCoroutine(FadeOutAudio());
    }

    IEnumerator FadeOutAudio()
    {
        float startVolume = logoAudio.volume;
        float elapsedTime = 0f;

        while (elapsedTime < audioFadeDuration)
        {
            float t = elapsedTime / audioFadeDuration;
            logoAudio.volume = Mathf.Lerp(startVolume, 0f, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        logoAudio.volume = 0f;
        logoAudio.Stop();
    }
}
