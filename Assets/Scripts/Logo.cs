using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public GameObject logoImage;  // �ΰ� �̹��� GameObject
    public CanvasGroup panel;
    public AudioSource logoAudio;      // �ΰ� ȿ����
    public float shrinkDuration = 1f; // �پ��� �� �ɸ��� �ð�
    public float audioFadeDuration = 1f; // ȿ���� ���̵�ƿ� �ð�

    void Start()
    {
        // �ڷ�ƾ ȣ��
        StartCoroutine(LogoSequence());
    }

    IEnumerator LogoSequence()
    {
        // �ΰ� ��ҿ� ȿ���� ���̵�ƿ��� ���ķ� ����
        yield return StartCoroutine(ShrinkLogoAndFadeOutAudio());

        // �� ��ȯ �� ���̵��� ����
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
