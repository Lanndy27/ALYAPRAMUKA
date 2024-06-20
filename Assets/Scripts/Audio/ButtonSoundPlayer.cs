using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}