using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate3 : MonoBehaviour
{
    public SampahManager2D sampahManager;

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
            // Simpan nama scene target (UI) di PlayerPrefs
            PlayerPrefs.SetString("TargetScene", "UI");
            // Pindah ke scene cerita (FinishScene)
            SceneManager.LoadScene("FinishScene");
        }
    }
}