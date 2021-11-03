using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMesh;
    Camera maincam;
    // Start is called before the first frame update
    void Start()
    {
      _navMesh = GetComponent<NavMeshAgent>();
      maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0)){ //1 is right, 0 is left
        RaycastHit hit;
        if(Physics.Raycast(maincam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
          _navMesh.destination = hit.point; //destination to player for enemies
        }

      }
    }
}
