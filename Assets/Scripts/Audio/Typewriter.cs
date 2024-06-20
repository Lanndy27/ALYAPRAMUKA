using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Typewriter : MonoBehaviour
{
    public Text storyText; 
    public string fullText; 
    public float typeSpeed = 0.05f; 
    public AudioSource typeSound; 

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            storyText.text = currentText;

            // Mainkan suara ketikan
            if (typeSound != null && !char.IsWhiteSpace(fullText[i]))
            {
                typeSound.Play();
            }

            yield return new WaitForSeconds(typeSpeed);
        }
    }
}