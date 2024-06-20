using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public GameObject deathAnimation;

    public GameObject disableAudio;

    public GameObject disableText;

    public GameObject disablePause;

    void Start()
    {
        PlayerController.OnDeath += OnDeath;
    }
    
    public void OnDeath()
    {
        Debug.Log("Death");
        if (deathAnimation != null)
        {
            StartCoroutine(HandleDeathEffect());
        }
    }
    private IEnumerator HandleDeathEffect()
    {
        disablePause.SetActive(false);
        disableText.SetActive(false);
        disableAudio.SetActive(false);
        deathAnimation.SetActive(true);
        yield return new WaitForSeconds(5f);
        deathAnimation.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

