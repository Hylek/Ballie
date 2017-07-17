using UnityEngine;

public class Faller : MonoBehaviour {

    // Variables
    private float deathTimer;

	// Use this for initialization
	void Start ()
    {
        deathTimer = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.name == "Platform")
        {
           ParticleController.Instance.Explosion(transform.position);
           Destroy(gameObject);
        }
        if (col.transform.gameObject.name == "Player")
        {
            //Destroy(col.gameObject);
            col.gameObject.SendMessage("IsDead");
        }
    }
}
