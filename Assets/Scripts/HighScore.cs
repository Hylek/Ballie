using UnityEngine;
using UnityEngine.UI;
/* Copyright @ 2017 Daniel Cumbor */
public class HighScore : MonoBehaviour
{
    // Variables
    private Text timer;
    private static float highscore;
    private string minutes;
    private string seconds;
    public GameObject timerRef;
    private Timer timerScript;

    // Use this for initialization
    void Start ()
    {
        timer = GetComponent<Text>();
        minutes = null;
        seconds = null;
        timerScript = timerRef.GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(timerScript.t > highscore)
        {
            highscore = timerScript.t;
        }

        minutes = ((int)highscore / 60).ToString();
        seconds = (highscore % 60).ToString("f2");

        timer.text = "Highscore: " + minutes + ":" + seconds;
    }
}
