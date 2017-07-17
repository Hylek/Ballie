using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Variables
    Text timer;
    private float start;

    void Start()
    {
        timer = GetComponent<Text>();
        start = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float t = start += Time.deltaTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timer.text = "Time: " + minutes + ":" + seconds;
	}
}
