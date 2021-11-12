using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour{

    void Start(){
        GameObject.FindObjectOfType<BackgroundMusic>().GetComponent<BackgroundMusic>().PlayMusic();
    }
}
