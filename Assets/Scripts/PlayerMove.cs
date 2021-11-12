using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMesh;
    Camera maincam;
    public AudioClip collect;
    AudioSource _audiosrc;
    // Start is called before the first frame update
    void Start()
    {
      _audiosrc = GetComponent<AudioSource>();
      _navMesh = GetComponent<NavMeshAgent>();
      maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(1)){ //1 is right, 0 is left
        RaycastHit hit;
        if(Physics.Raycast(maincam.ScreenPointToRay(Input.mousePosition), out hit, 300)){
          _navMesh.destination = hit.point; //destination to player for enemies
        }

      }
    }
    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Key")){
        _audiosrc.PlayOneShot(collect);
      }
    }

}
