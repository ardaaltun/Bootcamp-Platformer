using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;
    public Image heart;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

    }
    public void CollectHeart()
    {
        heart.fillAmount += 0.33f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
