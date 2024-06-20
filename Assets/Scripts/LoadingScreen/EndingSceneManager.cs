using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public float displayTime = 5f; // Waktu tampilan gambar

    void Start()
    {
        StartCoroutine(WaitAndLoadNextScene());
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(displayTime);
        SceneManager.LoadScene("CreditScene");
    }
}