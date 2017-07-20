using UnityEngine;
using UnityEngine.SceneManagement;
/* Copyright @ 2017 Daniel Cumbor */
public class UIManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
