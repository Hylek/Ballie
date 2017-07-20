using UnityEngine;
/* Copyright @ 2017 Daniel Cumbor */
public class Faller : MonoBehaviour
{
    // Variables
    private float deathTimer;
    private AudioSource bop;
    private BoxCollider box;
    private Renderer ren;

    // Use this for initialization
    void Start ()
    {
        deathTimer = 3;
        bop = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider>();
        ren = GetComponent<Renderer>();
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
        if (col.transform.gameObject.name == "Platform")
        {
           bop.Play();
           box.enabled = false;
           ren.enabled = false;
           ParticleController.Instance.FallerExplosion(transform.position);
        }
        if (col.transform.gameObject.name == "Player")
        {
            col.gameObject.SendMessage("IsDead");
        }
    }
}
