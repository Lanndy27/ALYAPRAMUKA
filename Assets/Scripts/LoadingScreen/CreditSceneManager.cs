using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneManager : MonoBehaviour
{
    public float displayTime = 10f; // Waktu tampilan kredit

    void Start()
    {
        StartCoroutine(WaitAndLoadNextScene());
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(displayTime);
        SceneManager.LoadScene("UI");
    }
}