using UnityEngine;
/* Copyright @ 2017 Daniel Cumbor */
public class Mover : MonoBehaviour {

    // Variables
    Rigidbody rb;
    public int speed;
    private float deathTimer;
    Player player;
    Material mat;
    private float fadeTime = 3f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
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
            ParticleController.Instance.MoverExplosion(transform.position);
            col.gameObject.SendMessage("IsDead");
        }
    }
}
