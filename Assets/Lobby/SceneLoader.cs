using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer ScreenFader;
    [SerializeField]
    private float Duration;
    float startTime;

    public void LoadScene(int i)
    {
        StartCoroutine(FadeScreen(i));
    }

    IEnumerator FadeScreen(int i)
    {
        ScreenFader.gameObject.SetActive(true);
        while (startTime < Duration)
        {
            ScreenFader.material.SetFloat("_Metallic", Mathf.Lerp(0, 1, startTime / Duration));
            startTime += Time.deltaTime;
            yield return null;
        }
        ScreenFader.material.SetFloat("_Metallic", 1);
        SceneManager.LoadSceneAsync(i);
    }
}
