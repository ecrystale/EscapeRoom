using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePuzzle : MonoBehaviour{

    bool solved = false;
    List<GameObject> blocks = new List<GameObject>();

    void Start(){
        for(int i = 0; i < gameObject.transform.childCount; i++){
            blocks.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void LateUpdate(){
        if(solved){
            for(int i = 0; i < blocks.Count; i++){
                Destroy(blocks[i].GetComponent<HighlightOnHover>());
                Destroy(blocks[i].GetComponent<AlternateBlock>());
            }

            Destroy(GetComponent<AlternatePuzzle>());
        }

        for(int i = 0; i < blocks.Count; i++){
            if(!blocks[i].GetComponent<AlternateBlock>().state){
                return;
            }
        }

        solved = true;
    }

    public List<GameObject> getBlocks(){
        return blocks;
    }
}
