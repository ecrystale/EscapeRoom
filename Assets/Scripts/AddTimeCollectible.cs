using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeCollectible : MonoBehaviour{
    public float amountAdded;

    public AudioClip timeLoseSound;
    public AudioClip timeGainSound;
    AudioSource _audioSource;

    void Start(){
      _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Player")){
        if(amountAdded < 0){
          print("Playing");
          _audioSource.PlayOneShot(timeLoseSound);
        } else {
          print("Playing");
          _audioSource.PlayOneShot(timeGainSound);
        }

        if(PublicVars.timeRemaining + amountAdded < 0){
          PublicVars.timeRemaining = 1;
        } else {
          PublicVars.timeRemaining += amountAdded;
        }
        print("Destroyed");
        Destroy(gameObject);
      }
    }
}
