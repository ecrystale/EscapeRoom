using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
      if(other.gameObject.CompareTag("Player")){
        PublicVars.timeRemaining += 60f;
        Destroy(gameObject);
      }
    }
}
