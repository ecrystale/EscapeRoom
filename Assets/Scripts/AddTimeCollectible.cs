using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeCollectible : MonoBehaviour{
    public float amountAdded;

    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Player")){

        if(PublicVars.timeRemaining + amountAdded < 0){
          PublicVars.timeRemaining = 1;
        } else {
          PublicVars.timeRemaining += amountAdded;
        }
        Destroy(gameObject);
      }
    }
}
