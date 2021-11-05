using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loc = player.transform.position;
        loc.y += 12;
        loc.z -= 3.7f;
        transform.position = loc;
    }
}
