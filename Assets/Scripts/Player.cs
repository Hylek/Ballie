using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/* Copyright @ 2017 Daniel Cumbor */
public class Player : MonoBehaviour {

    // Variables
    private Rigidbody rb;
    private SphereCollider sc;
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
    public Button retryButton;
    public Button quitButton;
    public Button moveLeft;
    public Button moveRight;
    private Renderer ren;

    // Use this for initialization
    void Start ()
    {
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
            retry.alpha += 0.1f;
            quit.alpha += 0.1f;
            GameOver();
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
        sc.enabled = false;
        retryButton.interactable = true;
        quitButton.interactable = true;
        moveLeft.interactable = false;
        moveRight.interactable = false;
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
