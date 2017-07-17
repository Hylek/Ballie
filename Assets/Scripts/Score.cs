using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Variables
    Text scorer;
    public GameObject reference;
    Player scoreUI;

    // Use this for initialization
    void Start ()
    {
        scorer = GetComponent<Text>();
        scoreUI = reference.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        scorer.text = "Score: " + scoreUI.score;
    }
}
