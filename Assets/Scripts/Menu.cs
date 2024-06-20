using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject optionsPanel; // Panel Opsi

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Fungsi untuk menampilkan panel opsi
    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    // Fungsi untuk menyembunyikan panel opsi
    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }
}