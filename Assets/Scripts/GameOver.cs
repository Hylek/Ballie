using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private CanvasGroup fadeGroup;
    private float fadeSpeed = 0.33f;
    private float loadTime;
    private float minTime = 5.0f;

    // Use this for initialization
    void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 0;

        if (Time.time < minTime)
        {
            loadTime = minTime;
        }
        else
        {
            loadTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Fade-in
        if (fadeGroup.alpha < 0.5) //(Time.time < minTime)
        {
            fadeGroup.alpha = 0 + Time.time;
        }
    }
}
