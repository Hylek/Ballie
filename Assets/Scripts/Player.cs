using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
/* Copyright @ 2017 Daniel Cumbor */
public class Player : MonoBehaviour
{
    // Variables
    private Rigidbody rb;
    private SphereCollider sc;
    private Renderer ren;
    private static int plays;
    private bool playOver = false;
    private bool coverPlay;

    public float speed = 0.33f;
    [HideInInspector]
    public bool rightPressed;
    [HideInInspector]
    public bool leftPressed;
    public int score;
    [HideInInspector]
    public int life;
    public CanvasGroup retry;
    public CanvasGroup quit;
    public CanvasGroup timerScoreCG;
    public CanvasGroup timerCG;
    public CanvasGroup highscoreCG;
    public CanvasGroup cover;
    public Button retryButton;
    public Button quitButton;
    public Button moveLeft;
    public Button moveRight;
    public Text timer;
    public Text timerScore;
    public Image coverHold;

    // Use this for initialization
    void Start ()
    {
        coverPlay = true;
        if(plays == 2 || plays == 4)
        {
            ShowAd();
        }
        retryButton.interactable = false;
        quitButton.interactable = false;
        life = 1;
        rb = GetComponent<Rigidbody>();
        ren = GetComponent<Renderer>();
        sc = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(coverHold.enabled && coverPlay)
        {
            cover.alpha -= 0.05f;
            if(cover.alpha == 0)
            {
                coverPlay = false;
            }
        }

        if (leftPressed)
        {
            rb.AddForce(Vector2.left * speed);
        }

        if (rightPressed)
        {
            rb.AddForce(Vector2.right * speed);
        }

        if(life == 0)
        {
            retry.alpha += 0.01f;
            quit.alpha += 0.01f;
            timerScoreCG.alpha += 0.01f;
            timerCG.alpha -= 0.01f;
            highscoreCG.alpha += 0.01f;
            if (cover.alpha < 0.5)
            {
                cover.alpha += 0.01f;
            }
            GameOver();
        }
        if(plays == 5)
        {
            plays = 0;
        }
    }

    public void ShowAd()
    {
        var options = new ShowOptions { resultCallback = AdResult };
        if(Advertisement.IsReady())
        {
            Time.timeScale = 0;
            Advertisement.Show(options);
        }
    }

    private void AdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad shown properly!");
                Time.timeScale = 1;
                // Potential reward here!
                break;
            case ShowResult.Failed:
                Debug.Log("The ad failed to show");
                Time.timeScale = 1;
                break;
            case ShowResult.Skipped:
                Debug.Log("The player chose to skip the ad");
                Time.timeScale = 1;
                break;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.transform.gameObject.name == "Platform")
        {
            life = 0;
        }
    }

    public void AddScore()
    {
        score += 5;
    }

    public void IsDead()
    {
        life = 0;
        ParticleController.Instance.PlayerDeath(transform.position);
        ren.enabled = false;
    }

    private void GameOver()
    {
        if(!playOver)
        {
            plays += 1;
            playOver = true;
        }
        timer.enabled = false;
        timerScore.enabled = true;
        sc.enabled = false;
        retryButton.interactable = true;
        quitButton.interactable = true;
        moveLeft.interactable = false;
        moveRight.interactable = false;
        if (plays == 5)
        {
            plays = 0;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void MoveLeft()
    {
        leftPressed = true;
    }

    public void MoveRight()
    {
        rightPressed = true;
    }
    public void LeftUp()
    {
        leftPressed = false;
    }
    public void RightUp()
    {
        rightPressed = false;
    }
}
