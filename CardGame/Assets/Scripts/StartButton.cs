using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Image image;

    public void GameStart()
    {
        StartCoroutine("NextScene");
    }

    IEnumerator NextScene()
    {
        StartCoroutine(FadeOutCoroutine());
        yield return new WaitForSeconds(1);

        GameManager.gm.stageNum = 1;

        SceneManager.LoadScene("Junho");
    }
    

    IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
