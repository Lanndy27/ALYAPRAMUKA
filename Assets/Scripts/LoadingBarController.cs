using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarController : MonoBehaviour
{
    public Slider loadingBar;
    public Vector3 offset;

    public void UpdateLoadingBar(Vector3 sampahPosition, float progress)
    {
        loadingBar.transform.position = Camera.main.WorldToScreenPoint(sampahPosition) + offset;
        loadingBar.value = progress;
    }

    public void ShowLoadingBar(bool show)
    {
        loadingBar.gameObject.SetActive(show);
    }
}