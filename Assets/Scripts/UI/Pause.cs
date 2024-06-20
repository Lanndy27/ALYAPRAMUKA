using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public AudioSource audioSource; // Komponen AudioSource untuk memainkan suara
    public AudioClip buttonClickSound; // AudioClip untuk suara tombol yang diklik
    public GameObject pauseMenuUI; // Referensi ke UI menu pause

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        // Menampilkan UI menu pause
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }

        // Memainkan suara tombol diklik jika ada
        PlayButtonClickSound();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        // Menyembunyikan UI menu pause
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        // Memainkan suara tombol diklik jika ada
        PlayButtonClickSound();
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        // Menyembunyikan UI menu pause
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        // Memainkan suara tombol diklik jika ada
        PlayButtonClickSound();

        // Pindah ke scene "UI" setelah suara selesai
        StartCoroutine(LoadUISceneAfterSound());
    }

    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    private IEnumerator LoadUISceneAfterSound()
    {
        yield return new WaitForSecondsRealtime(buttonClickSound.length);

        // Memuat kembali ke scene "UI"
        SceneManager.LoadScene("UI");
    }
}