using UnityEngine;
using UnityEngine.UI;
/* Copyright @ 2017 Daniel Cumbor */
public class Timer : MonoBehaviour
{
    // Variables
    private Text timer;
    private float start;
    public float t;
    private static float highscore;
    private string minutes;
    private string seconds;
    public GameObject playerRef;
    private Player playerScript;

    void Start()
    {
        timer = GetComponent<Text>();
        start = Time.time;
        t = 0;
        start = 0;
        minutes = null;
        seconds = null;
        playerScript = playerRef.GetComponent<Player>();
    }

	// Update is called once per frame
	void Update ()
    {
        if(playerScript.life == 1)
        {
            t = start += Time.deltaTime;
        }
        if(playerScript.life == 0)
        {
            highscore = t;
            Debug.Log(highscore);
        }

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        timer.text = "Time: " + minutes + ":" + seconds;
	}
}
