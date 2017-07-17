using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject player;
    public float camDistance;
    public float camHeight;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z -= camDistance;
        pos.y += camHeight;
        transform.position = pos;
    }
}
