using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate2 : MonoBehaviour
{
    public SampahManager2D sampahManager;
    public string nextSceneName = "Level2"; // Nama scene level 2

    private void Start()
    {
        gameObject.SetActive(false); // Nonaktifkan pintu masuk pada awal permainan
    }

    private void Update()
    {
        if (sampahManager.SampahTerkumpulLengkap())
        {
            sampahManager.SetSemuaSampahTerkumpul();
            gameObject.SetActive(true); // Aktifkan pintu masuk jika semua sampah telah terkumpul
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && sampahManager.semuaSampahTerkumpul)
        {
            // Store the target scene name in PlayerPrefs
            PlayerPrefs.SetString("TargetScene", nextSceneName);
            // Load the loading screen
            SceneManager.LoadScene("LoadingScene3");
        }
    }
}