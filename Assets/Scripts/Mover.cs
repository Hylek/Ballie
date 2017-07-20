using UnityEngine;
/* Copyright @ 2017 Daniel Cumbor */
public class Mover : MonoBehaviour
{
    // Variables
    private Rigidbody rb;
    private AudioSource blop;
    public int speed;
    private float deathTimer;
    private Player player;
    private Material mat;
    private float fadeTime = 3f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        blop = GetComponent<AudioSource>();
        deathTimer = 7;
    }

    void Update()
    {
        deathTimer -= Time.deltaTime;

        mat = GetComponent<Renderer>().material;
        Color col = mat.color;
        if(mat.color.a < 1)
        {
            mat.color = mat.color = new Color(col.r, col.g, col.b, col.a + (fadeTime * Time.deltaTime));
        }

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.AddForce(Vector3.back * speed);
        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.name == "Player")
        {
            blop.Play();
            ParticleController.Instance.MoverExplosion(transform.position);
            col.gameObject.SendMessage("IsDead");
        }
    }
}
