using UnityEngine;
/* Copyright @ 2017 Daniel Cumbor */
public class CamFollow : MonoBehaviour
{
    // Variables
    public GameObject player;
    private Player pScript;
    public float camDistance;
    public float camHeight;

    void Start()
    {
        pScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if(pScript.life == 1)
        {
            Vector3 pos = player.transform.position;
            pos.z -= camDistance;
            pos.y += camHeight;
            transform.position = pos;
        }
    }
}
