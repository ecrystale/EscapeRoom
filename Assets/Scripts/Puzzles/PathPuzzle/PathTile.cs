using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : MonoBehaviour{

    public bool state = false;
    public Material onMat;
    Material defaultMat;
    Renderer rend;

    void Start(){
        rend = GetComponent<Renderer>();
        defaultMat = rend.material;

        if(gameObject.name == "start"){
            state = true;
        }
    }

    void Update(){
        if(!state){
            rend.material = defaultMat;
        } else {
            rend.material = onMat;
        }
    }

    void OnMouseDown(){
        bool adj = transform.parent.gameObject.GetComponent<PathPuzzle>().isAdjacent(gameObject);
        if(!adj){
            transform.parent.gameObject.GetComponent<PathPuzzle>().reset();
        } else {
            state = true;
            transform.parent.gameObject.GetComponent<PathPuzzle>().setLast(gameObject);
        }
    }

    public void reset(){
        if(gameObject.name == "start"){
            state = true;
            transform.parent.gameObject.GetComponent<PathPuzzle>().setLast(gameObject);
        } else {
            state = false;
        }
    }
}
