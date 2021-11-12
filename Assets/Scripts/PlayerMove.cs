using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMesh;
    Camera maincam;
    public AudioClip collect;
    public AudioClip timeLoseSound;
    public AudioClip timeGainSound;
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

      if(Input.GetKeyDown(KeyCode.Escape)){
        Application.Quit();
      }
    }
    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Key")){
        _audiosrc.PlayOneShot(collect, 0.35f);
      }

      if(other.gameObject.CompareTag("Time")){
        if(other.gameObject.GetComponent<AddTimeCollectible>().amountAdded < 0){
          _audiosrc.PlayOneShot(timeLoseSound, 0.35f);
        } else {
          _audiosrc.PlayOneShot(timeGainSound, 0.65f);
        }
      }
    }

}
