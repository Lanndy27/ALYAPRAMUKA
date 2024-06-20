using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public string uiSceneName = "UI"; // Nama scene UI

    public void QuitGame()
    {
        // Memainkan suara klik jika ada
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        // Memuat kembali ke scene UI setelah suara selesai
        StartCoroutine(LoadUISceneAfterSound());
    }

    private IEnumerator LoadUISceneAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);

        // Memuat kembali ke scene UI
        SceneManager.LoadScene(uiSceneName);
    }
}