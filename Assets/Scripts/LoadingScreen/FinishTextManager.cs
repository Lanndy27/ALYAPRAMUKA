using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishTextManager : MonoBehaviour
{
    public TextMeshProUGUI storyText; 
    public float typingSpeed = 0.05f; 
    public string[] storyLines; 
    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        StartCoroutine(TypeLine());
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
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void CompleteCurrentLine()
    {
        StopAllCoroutines();
        storyText.text = storyLines[index];
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
        // Muat scene target yang disimpan di PlayerPrefs
        string targetScene = PlayerPrefs.GetString("TargetScene", "UI");
        SceneManager.LoadScene(targetScene);
    }
}