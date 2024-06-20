using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishSceneManager : MonoBehaviour
{
    public TextMeshProUGUI storyText; 
    public float typingSpeed = 0.05f; 
    public string[] storyLines; 
    public AudioSource typeSound; 

    private int index = 0;
    private bool isTyping = false;

    public AudioSource keySource;


    public AudioClip key;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    public void PlayTypeSFX(AudioClip clip)
    {
        if (keySource.clip != clip)
        {
            keySource.clip = clip;
            keySource.loop = true;
            keySource.Play();
        }
    }

    public void StopTypeSFX()
    {
        if (keySource.loop)
        {
            keySource.Stop();
            keySource.loop = false;
            keySource.clip = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            if (isTyping)
            {
                CompleteCurrentLine();
            }
            else
            {
                NextLine();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        storyText.text = "";
        foreach (char letter in storyLines[index].ToCharArray())
        {
            storyText.text += letter;

            if (!char.IsWhiteSpace(letter))
            {
                PlayTypeSFX(key);
            }

            yield return new WaitForSeconds(typingSpeed);
        }
        StopTypeSFX();
        isTyping = false;
    }

    void CompleteCurrentLine()
    {
        StopAllCoroutines();
        storyText.text = storyLines[index];
        StopTypeSFX();
        isTyping = false;
    }

    void NextLine()
    {
        if (index < storyLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}