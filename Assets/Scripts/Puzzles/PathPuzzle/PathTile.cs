using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : MonoBehaviour{

    public bool state = false;
    public Material onMat;
    Material defaultMat;
    Renderer rend;

    public AudioClip press;
    AudioSource _audiosrc;

    void Start(){
        _audiosrc = GetComponent<AudioSource>();
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
        _audiosrc.PlayOneShot(press);
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
