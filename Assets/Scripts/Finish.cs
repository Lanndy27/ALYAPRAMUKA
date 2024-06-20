using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public SampahManager2D sampahManager;
    [SerializeField]
    private string storySceneName = "StoryScene"; // Scene cerita

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(storySceneName);
        }
    }
}