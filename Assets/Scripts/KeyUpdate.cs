using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUpdate : MonoBehaviour
{
    public int keynum;
    //public AudioClip collect;
  //  AudioSource _audiosrc;
    // Start is called before the first frame update
    void Start()
    {
      //_audiosrc = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Player")){
        PublicVars.keys[keynum] += 1;
        //_audiosrc.PlayOneShot(collect);
        Destroy(gameObject);
      }
    }
}
