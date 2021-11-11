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
    void LateUpdate()
    {
        Vector3 loc = player.transform.position;
        //loc.x -= 3f;
        loc.z -= 5f;
        loc.y += 18;
        transform.position = loc;
    }
}
