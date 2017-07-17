using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Variables
    private Text timer;
    private float start;
    private float t;
    private string minutes;
    private string seconds;

    void Start()
    {
        timer = GetComponent<Text>();
        start = Time.time;
        t = 0;
        start = 0;
        minutes = null;
        seconds = null;
    }

	// Update is called once per frame
	void Update ()
    {
        t = start += Time.deltaTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        timer.text = "Time: " + minutes + ":" + seconds;
	}
}
