using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public Slider loadingBar; 
    public float loadingTime = 5f; 

    void Start()
    {
       
        string targetScene = PlayerPrefs.GetString("TargetScene");
        StartCoroutine(LoadSceneWithDelay(targetScene, loadingTime));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        float elapsedTime = 0f;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / delay);
            loadingBar.value = progress;
            yield return null;
        }

        
        SceneManager.LoadScene(sceneName);
    }
}