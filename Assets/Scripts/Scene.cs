using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public CanvasGroup fadePanel; // ���� ȭ�� �г�(CanvasGroup)
    public GameObject Panel;
    public float fadeDuration = 1f; // ���̵� �ð�

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
        fadePanel.alpha = 1f; // ó���� ������ ���� ȭ��

        while (elapsedTime < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // ���� �����
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.alpha = 0f; // ���̵��� �Ϸ�
        Panel.SetActive(false);
    }
}
