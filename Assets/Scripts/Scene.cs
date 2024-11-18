using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public CanvasGroup fadePanel; // 검은 화면 패널(CanvasGroup)
    public GameObject Panel;
    public float fadeDuration = 1f; // 페이드 시간

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("Class1");
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        fadePanel.alpha = 1f; // 처음에 완전히 검은 화면

        while (elapsedTime < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // 점점 밝아짐
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.alpha = 0f; // 페이드인 완료
        Panel.SetActive(false);
    }
}
