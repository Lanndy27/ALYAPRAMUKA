using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 1.0f; 
    public string nextSceneName; 

    public void PlaySoundAndLoadScene()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            StartCoroutine(WaitAndLoadScene());
        }
        else
        {
            
            LoadScene();
        }
    }

    private IEnumerator WaitAndLoadScene()
    {
        // Tunggu sampai audio clip selesai diputar atau delay habis
        yield return new WaitForSeconds(audioSource.clip.length > delay ? delay : audioSource.clip.length);
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
