using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePuzzle : MonoBehaviour{

    ArrayList blocks = new ArrayList(); 

    void Start(){
        for(int i = 0; i < gameObject.transform.childCount; i++){
            blocks.Add(gameObject.transform.GetChild(i));
        }
        print(blocks);
    }

    void Update(){
        
    }
}
